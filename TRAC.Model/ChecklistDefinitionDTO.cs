using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.Model
{
    public class ChecklistDefinitionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ChecklistDefinitionStatusId { get; set; }

        public virtual ChecklistDefinitionStatusDTO ChecklistDefinitionStatus { get; set; }

        public virtual List<SectionDefinitionDTO> Sectiondefinitions { get; set; }
        public virtual List<ChecklistDTO> Checklists { get; set; }

        public ChecklistDefinitionDTO()
        {
            Sectiondefinitions = new List<SectionDefinitionDTO>();
            Checklists = new List<ChecklistDTO>();
        }
    }
}
