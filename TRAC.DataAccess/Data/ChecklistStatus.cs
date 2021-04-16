using System;
using System.ComponentModel.DataAnnotations;

namespace TRAC.DataAccess
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
    }
}
