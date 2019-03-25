using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Worstore.Helpers.Enums;

namespace Worstore.Entities
{
    [Table("SpokenLanguage")]
    public class SpokenLanguage
    {

        public SpokenLanguage()
        {
            Status = (int)GeneralEnums.RecordStatus.Active;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Label { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public string FlagUrl { get; set; }

        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }


        public ICollection<Group> Groups { get; set; }
    }
}
