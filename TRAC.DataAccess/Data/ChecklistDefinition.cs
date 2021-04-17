using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.DataAccess.Data
{
    public class ChecklistDefinition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ChecklistDefinitionStatusId { get; set; }

        [ForeignKey("ChecklistDefinitionId")]
        public virtual ChecklistDefinitionStatus ChecklistDefinitionStatus { get; set; }

        public virtual List<SectionDefinition> Sectiondefinitions { get; set; }
        public virtual List<Checklist> Checklists { get; set; }

        public ChecklistDefinition()
        {
            Sectiondefinitions = new List<SectionDefinition>();
            Checklists = new List<Checklist>();
        }
    }
}
