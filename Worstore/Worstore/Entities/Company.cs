using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Worstore.Entities;

namespace Data.EntitiesModel
{
    [Table("Company")]
    public class Company
    {
        public int CompanyId{get;set;}

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public String Name{get;set;}

        [ForeignKey("User")]
        [Required]
        public string FkUser { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
