using System.ComponentModel.DataAnnotations;

namespace Worstore.Models.HomeViewModels
{
    public class ExcelFileOptionsDatas
    {
        [Required]
        public string OldSheetLabel { get; set; }
        [Required]
        public string NewSheetLabel { get; set; }

        public int SheetLanguage { get; set; } //FkSpokenLanguage
        [Required]
        public string WordColumnName { get; set; }
        [Required]
        public string MeaningsColumnName { get; set; }
        [Required]
        public string PronunciationColumnName { get; set; }
        [Required]
        public string TagColumnName { get; set; }
    }
}
