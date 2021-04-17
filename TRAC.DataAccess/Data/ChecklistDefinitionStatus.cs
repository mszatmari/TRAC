using System;
using System.Collections.Generic;

namespace TRAC.DataAccess.Data
{
    public class ChecklistDefinitionStatus
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }

        public virtual List<ChecklistDefinition> ChecklistDefinitions { get; set; }

        public ChecklistDefinitionStatus()
        {
            ChecklistDefinitions = new List<ChecklistDefinition>();
        }
    }
}
