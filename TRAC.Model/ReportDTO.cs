using System;
using System.Collections.Generic;

namespace TRAC.Model
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public string ReportName { get; set; }

        public virtual List<ChecklistDTO> Checklists { get; set; }

        public ReportDTO()
        {
            Checklists = new List<ChecklistDTO>();
        }
    }
}
