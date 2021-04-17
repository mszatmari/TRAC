using System;
using System.Collections.Generic;

namespace TRAC.DataAccess.Data
{
    public class Report
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public string ReportName { get; set; }

        public virtual List<Checklist> Checklists { get; set; }

        public Report()
        {
            Checklists = new List<Checklist>();
        }
    }
}
