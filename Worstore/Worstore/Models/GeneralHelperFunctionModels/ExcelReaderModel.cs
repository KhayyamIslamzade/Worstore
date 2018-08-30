using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worstore.Models.GeneralHelperFunctionModels
{
    public class ExcelSheet
    {
        public string SheetLabel { get; set; }
        public List<ExcelRow> ExcelRow { get; set; }
        public List<string> ExcelHeader { get; set; }
    }
    public class ExcelRow
    {

        public List<string> ExcelCell { get; set; }

    }

}
