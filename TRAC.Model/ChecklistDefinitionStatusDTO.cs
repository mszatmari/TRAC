using System;
using System.Collections.Generic;

namespace TRAC.Model
{
    public class ChecklistDefinitionStatusDTO
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }

        public virtual List<ChecklistDefinitionDTO> ChecklistDefinitions { get; set; }

        public ChecklistDefinitionStatusDTO()
        {
            ChecklistDefinitions = new List<ChecklistDefinitionDTO>();
        }
    }
}
