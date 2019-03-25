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
    public class GameWordViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }




    }
}
