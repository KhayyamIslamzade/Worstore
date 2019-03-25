using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Worstore.AccessLayer.Entity;
using Worstore.BusinnessLayer.Abstract;
using Worstore.Entities;
using Worstore.Helpers.Functions;
using Worstore.Models;
using Worstore.Models.GeneralHelperFunctionModels;
using Worstore.Models.GeneralModels;
using Worstore.Models.HomeViewModels;
using Worstore.Services;
using static Worstore.Helpers.Functions.GeneralHelperFunctions;

namespace Worstore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly WordHelperFunctions Functions = new WordHelperFunctions();


        private readonly Repository<SpokenLanguage> languagesRepository;
        private readonly Repository<Word> wordRepository;
        private readonly Repository<Group> groupRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public DatabaseContext _db { get; }
        //private readonly UserManager<ApplicationUser> _manager;
        private readonly UserResolverService _manager;

        public HomeController(DatabaseContext dbContext, UserResolverService manager,
            IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _db = dbContext;
            _hostingEnvironment = hostingEnvironment;
            _manager = manager;
            _mapper = mapper;
            languagesRepository = new Repository<SpokenLanguage>(_db, _manager);
            wordRepository = new Repository<Word>(_db, _manager);
            groupRepository = new Repository<Group>(_db, _manager);
        }



        public IActionResult Index()
        {
            Console.WriteLine("dasdasd");
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                Languages = languagesRepository.List().Select(x => new SpokenLanguageViewModel() { Label = x.Label, Id = x.Id }).OrderBy(x => x.Label).ToList(),
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddWord(WordViewModel wordModel)
        {
            //var user = await GetCurrentUser();
            if (ModelState.IsValid)
            {
                Word word = _mapper.Map<Word>(wordModel);
                var list = Functions.StringToList(wordModel.MeaningsString);
                word.Meanings = list;



                wordRepository.Insert(word);


            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult AddExcelFile(IFormFile excelFile)
        {
            List<ExcelSheet> excelData = ResolveExcelFile(excelFile, _hostingEnvironment.WebRootPath);  //Helper -> GeneralHelperFunctions

            return View("Index");
        }

        [HttpPost]
        public IActionResult ReadExcelFile(IFormFile excelFile)
        {


            try
            {
                ReadExcelFileViewModel model = new ReadExcelFileViewModel()
                {
                    excelData = ResolveExcelFile(excelFile, _hostingEnvironment.WebRootPath), //Helper -> GeneralHelperFunctions,
                    Languages = languagesRepository.List().Select(x => new SpokenLanguageViewModel() { Label = x.Label, Id = x.Id }).OrderBy(x => x.Label).ToList()
                };
                return PartialView("_PartialDataTableList", model);
            }
            catch (Exception e)
            {
                return PartialView("_PartialError");
            }

        }
        [HttpPost]
        public IActionResult AddExcelFileContent(List<ExcelFileOptionsDatas> data, IFormFile excelFile)
        {

            if (ModelState.IsValid && excelFile != null)
            {


                try
                {
                    List<ExcelSheet> excelData = ResolveExcelFile(excelFile, _hostingEnvironment.WebRootPath);
                    List<Group> newDatas = new List<Group>();

                    foreach (var sheet in excelData)
                    {
                        ExcelFileOptionsDatas option = data.FirstOrDefault(x => x.OldSheetLabel == sheet.SheetLabel);
                        Group group = new Group();
                        group.FkLanguage = option.SheetLanguage;
                        group.Label = option.NewSheetLabel;
                        group.DateCreated = DateTime.Now;
                        group.FkUser = _db.Users.FirstOrDefault(c => c.UserName == _manager.GetUser())?.Id;



                        int indexOfWordClmn = sheet.ExcelHeader.IndexOf(option.WordColumnName);
                        int indexOfMeaningClmn = sheet.ExcelHeader.IndexOf(option.MeaningsColumnName);
                        int indexOfPronunciationClmn = sheet.ExcelHeader.IndexOf(option.PronunciationColumnName);
                        int indexOfTagClmn = sheet.ExcelHeader.IndexOf(option.TagColumnName);

                        foreach (var item in sheet.ExcelRow)
                        {
                            Word word = new Word();
                            word.Label = item.ExcelCell[indexOfWordClmn];
                            word.Meanings = Functions.StringToList(item.ExcelCell[indexOfMeaningClmn]);
                            foreach (var meaning in word.Meanings)
                            {
                                meaning.DateCreated = DateTime.Now;

                            }
                            word.Pronunciation = item.ExcelCell[indexOfPronunciationClmn];
                            word.Tag = item.ExcelCell[indexOfTagClmn];
                            word.DateCreated = DateTime.Now;
                            group.Word.Add(word);

                        }

                        _db.Groups.Add(group);



                    }

                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }



            }

            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Test()
        {


            //HomeIndexViewModel model = new HomeIndexViewModel()
            //{
            //    Languages = languagesRepository.List().Select(x => new SpokenLanguageViewModel() { Label = x.Label, Id = x.Id }).OrderBy(x => x.Label).ToList(),
            //};
            return View();

        }

        public PartialViewResult GetGameWord()
        {
            GameWordViewModel gameData = _mapper.Map<GameWordViewModel>(wordRepository.GetRandomEntity(c => c.Id));


            return PartialView("Partials/Test/_PartialTest", gameData);
        }

        [HttpPost]
        public JsonResult CheckWordTruth(int wordId, string meaning)
        {

            try
            {
                Word word = _db.Word.Include(c => c.Meanings).Include(c => c.Answers).FirstOrDefault(m => m.Id == wordId);
                if (word != null)
                {
                    WordComparsion comparsion = new WordComparsion();

                    bool isTrue = word.Meanings.Any(c => comparsion.Compare(c.Label, meaning));
                    string message = "";
                    if (isTrue)
                        message = "Brilliant!";
                    else
                        message = "Better next time";

                    word.Answers.Add(new Answer()
                    {
                        DateCreated = DateTime.Now,
                        IsTestTrue = isTrue,
                        Reply = meaning
                    });
                    _db.SaveChanges();

                    return Json(new JsonResultResponse() { Response = isTrue, Message = message });
                }
                else
                {
                    return Json(new JsonResultResponse() { Response = false, Message = "Ohh nooo.What are u doing Bro?!" });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Json(new JsonResultResponse() { Response = true, Message = "U are amazing bro!" });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
