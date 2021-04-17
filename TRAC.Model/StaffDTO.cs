using System;
using System.Collections.Generic;

namespace TRAC.Model
{
    public class StaffDTO
    {
        public int StaffId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual List<ChecklistDTO> CreatorChecklists { get; set; }
        public virtual List<ChecklistDTO> ValidatorChecklists { get; set; }
        public StaffDTO()
        {
            CreatorChecklists = new List<ChecklistDTO>();
            ValidatorChecklists = new List<ChecklistDTO>();
        }
    }
}
