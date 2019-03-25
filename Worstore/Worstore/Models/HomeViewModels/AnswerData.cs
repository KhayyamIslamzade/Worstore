using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Worstore.Helpers.Enums;

namespace Worstore.Models.HomeViewModels
{
    public class AnswerData
    {


        [Required]
        [StringLength(255)]
        public string Reply { get; set; }

        public int FkWord { get; set; }





    }
}
