using System;
using System.ComponentModel.DataAnnotations;

namespace TRAC.Model
{
    public class CheclistStatusDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        [Required]
        public string Label { get; set; }
    }
}
