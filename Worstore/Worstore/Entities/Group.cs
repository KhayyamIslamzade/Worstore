using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Worstore.Entities
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Label { get; set; }


        [ForeignKey("SpokenLanguage")]
        [Required]
        public int FkLanguage { get; set; }

        [ForeignKey("User")]
        [Required]
        public string FkUser { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual SpokenLanguage SpokenLanguage { get; set; }

        public virtual ICollection<Word> Word { get; set; }
    }
}
