using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Worstore.Models;
using Microsoft.AspNetCore.Mvc;
using Worstore.AccessLayer.Entity;
using Worstore.BusinnessLayer.Abstract;
using Worstore.Models.GeneralModels;
using Worstore.Entities;
using Worstore.Helpers.Functions;
using Worstore.Models.GeneralHelperFunctionModels;
using Worstore.Models.HomeViewModels;
using Worstore.Services;
using static Worstore.Helpers.Functions.GeneralHelperFunctions;

namespace Worstore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly WordHelperFunctions Functions=new WordHelperFunctions();


        private readonly Repository<SpokenLanguage> languagesRepository ;
        private readonly Repository<Word> wordRepository ;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public DatabaseContext _db { get; }
        //private readonly UserManager<ApplicationUser> _manager;
        private readonly UserResolverService _manager;

        public HomeController(DatabaseContext dbContext, UserResolverService manager ,
            IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _db = dbContext;
            _hostingEnvironment = hostingEnvironment;
            _manager = manager;
            _mapper = mapper;
            languagesRepository =new Repository<SpokenLanguage>(_db, _manager);
            wordRepository = new Repository<Word>(_db, _manager);
        }

      

        //public async Task<ApplicationUser> GetCurrentUser()
        //{
        //    return await _manager.GetUserAsync(HttpContext.User);
        //}


        public IActionResult Index()
        {
            Console.WriteLine("dasdasd");
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                Languages = languagesRepository.List().Select(x => new SpokenLanguageViewModel() { Label = x.Label, Id = x.Id }).OrderBy(x=>x.Label).ToList(),
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
            List<ExcelSheet> excelData= ResolveExcelFile(excelFile , _hostingEnvironment.WebRootPath);  //Helper -> GeneralHelperFunctions
            
            return View("Index");
        }

        [HttpPost]
        [Route("Upload")]
        public JsonResult ReadExcelFile(IFormFile excelFile)
        {
            List<ExcelSheet> excelData = ResolveExcelFile(excelFile, _hostingEnvironment.WebRootPath);  //Helper -> GeneralHelperFunctions



            return new JsonResult(excelData);
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
            //ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
