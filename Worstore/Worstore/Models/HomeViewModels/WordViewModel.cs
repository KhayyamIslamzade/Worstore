using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Worstore.Entities;
using Worstore.Helpers.Functions;
using static Worstore.Helpers.Functions.GeneralHelperFunctions;

namespace Worstore.Models.HomeViewModels
{
    public class WordViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Label { get; set; }
        [StringLength(100)]
        public string Pronunciation { get; set; }
        [StringLength(50)]
        public string Tag { get; set; }

        [BindNever]
        [StringLength(30)]
        public string AddedTime { get; set; }

        [Required]
        public int FkGroup { get; set; }

        [Required]
        public int FkLanguage { get; set; }

        [Required]
        public virtual string MeaningsString { get; set; }


       public WordViewModel()
        {
           
            AddedTime = DateTimeNow_InFormat(); //Helper -> GeneralHelperFunctions
        }


    }
}
