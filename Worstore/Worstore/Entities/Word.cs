using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Worstore.Helpers.Functions;

namespace Worstore.Entities
{
    [Table("Word")]
    public class Word
    {
   
        [Key]
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


        [ForeignKey("Group")]
        [Required]
        public int FkGroup { get; set; }

        public virtual ICollection<Meaning> Meanings { get; set; }

        public virtual Group Group { get; set; }





    }
}
