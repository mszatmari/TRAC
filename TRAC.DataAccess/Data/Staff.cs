using System;
using System.Collections.Generic;

namespace TRAC.DataAccess.Data
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual List<Checklist> CreatorChecklists { get; set; }
        public virtual List<Checklist> ValidatorChecklists { get; set; }
        public Staff()
        {
            CreatorChecklists = new List<Checklist>();
            ValidatorChecklists = new List<Checklist>();
        }
    }
}
