using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Worstore.Entities
{
    public class Meaning
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Label { get; set; }

        [BindNever]
        [StringLength(30)]
        public string AddedTime { get; set; }

        [ForeignKey("Word")]
        [Required]
        public int FkWord { get; set; }
        public virtual Word Word { get; set; }
    }
}
