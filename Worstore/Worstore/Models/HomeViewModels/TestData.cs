using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Worstore.Models.HomeViewModels
{
    public class TestData
    {
        public List<ExcelFileOptionsDatas> fileOptions { get; set; }
        public IFormFile excelFila { get; set; }
    }
}
