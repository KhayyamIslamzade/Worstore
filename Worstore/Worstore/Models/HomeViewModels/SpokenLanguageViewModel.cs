using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Worstore.Entities;

namespace Worstore.Models.GeneralModels
{
    public class SpokenLanguageViewModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Label { get; set; }

        public virtual List<Word> Words { get; set; }
    }
}
