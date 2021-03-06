﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Worstore.Helpers.Enums;

namespace Worstore.Entities
{
    [Table("Group")]
    public class Group
    {
        public Group()
        {
            Status = (int)GeneralEnums.RecordStatus.Active;
            Word = new HashSet<Word>();
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
        [ForeignKey("SpokenLanguage")]
        [Required]
        public int FkLanguage { get; set; }

        [ForeignKey("User")]
        [Required]
        public string FkUser { get; set; }

        public ApplicationUser User { get; set; }
        public SpokenLanguage SpokenLanguage { get; set; }

        public ICollection<Word> Word { get; set; }
    }
}
