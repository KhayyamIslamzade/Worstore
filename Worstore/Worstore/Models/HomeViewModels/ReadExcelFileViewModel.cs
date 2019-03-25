using System.Collections.Generic;
using Worstore.Models.GeneralHelperFunctionModels;
using Worstore.Models.GeneralModels;

namespace Worstore.Models.HomeViewModels
{
    public class ReadExcelFileViewModel
    {
        public List<SpokenLanguageViewModel> Languages { get; set; }
        public List<ExcelSheet> excelData { get; set; }
    }
}
