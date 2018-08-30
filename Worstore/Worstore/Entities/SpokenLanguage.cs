using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Worstore.Entities
{
    [Table("SpokenLanguage")]
    public class SpokenLanguage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Label { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public string FlagUrl { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
