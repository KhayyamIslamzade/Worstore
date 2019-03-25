using System.Collections.Generic;

namespace Worstore.Models.GeneralHelperFunctionModels
{
    public class ExcelSheet
    {
        public string SheetLabel { get; set; } //group
        public List<string> ExcelHeader { get; set; }
        public List<ExcelRow> ExcelRow { get; set; }

    }
    public class ExcelRow
    {

        public List<string> ExcelCell { get; set; }

    }

}
