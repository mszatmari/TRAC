using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.DataAccess.Data
{
    public class SectionDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChecklistDefinitionId { get; set; }
        public int SectionOrder { get; set; }

        [ForeignKey("ChecklistDefinitionId")]
        public virtual ChecklistDefinition ChecklistDefinition { get; set; }

        public virtual List<QuestionDefinition> QuestionDefinitions { get; set; }

        public SectionDefinition()
        {
            QuestionDefinitions = new List<QuestionDefinition>();
        }
    }
}
