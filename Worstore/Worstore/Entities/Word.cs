using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Worstore.Helpers.Enums;

namespace Worstore.Entities
{
    [Table("Word")]
    public class Word
    {
        public Word()
        {
            Status = (int)GeneralEnums.RecordStatus.Active;
            Meanings = new HashSet<Meaning>();
            Answers = new HashSet<Answer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Label { get; set; }
        [StringLength(255)]
        public string Pronunciation { get; set; }
        [StringLength(255)]
        public string Tag { get; set; }

        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }


        [ForeignKey("Group")]
        public int FkGroup { get; set; }

        public ICollection<Meaning> Meanings { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Group Group { get; set; }





    }
}
