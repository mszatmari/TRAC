using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TRAC.Model
{
    public class ChecklistStatusDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Label { get; set; }

        public virtual List<ChecklistDTO> Checklists { get; set; }

        public ChecklistStatusDTO()
        {
            Checklists = new List<ChecklistDTO>();
        }
    }
}
