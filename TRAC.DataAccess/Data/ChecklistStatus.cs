using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TRAC.DataAccess.Data  
{
    public class ChecklistStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        [Required]
        public string Label { get; set; }

        public virtual List<Checklist> Checklists { get; set; }

        public ChecklistStatus()
        {
            Checklists = new List<Checklist>();
        }
    }
}
