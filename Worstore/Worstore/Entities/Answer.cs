using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Worstore.Helpers.Enums;

namespace Worstore.Entities
{
    [Table("Answer")]
    public class Answer
    {
        public Answer()
        {
            Status = (int)GeneralEnums.RecordStatus.Active;
            IsTestTrue = false;

            //TODO: DEFINE ENUM CLASS
            TestType = 1;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Reply { get; set; }
        public int TestType { get; set; }
        public bool IsTestTrue { get; set; }

        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }


        [ForeignKey("Word")]
        public int FkWord { get; set; }
        public Word Word { get; set; }





    }
}
