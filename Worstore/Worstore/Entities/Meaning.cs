using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Worstore.Helpers.Enums;

namespace Worstore.Entities
{
    public class Meaning
    {
        public Meaning()
        {
            Status = (int)GeneralEnums.RecordStatus.Active;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Label { get; set; }

        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        [ForeignKey("Word")]
        [Required]
        public int FkWord { get; set; }
        public Word Word { get; set; }
    }
}
