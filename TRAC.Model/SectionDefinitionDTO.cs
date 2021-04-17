using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.Model
{
    public class SectionDefinitionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChecklistDefinitionId { get; set; }
        public int SectionOrder { get; set; }

        public virtual ChecklistDefinitionDTO ChecklistDefinition { get; set; }

        public virtual List<QuestionDefinitionDTO> QuestionDefinitions { get; set; }

        public SectionDefinitionDTO()
        {
            QuestionDefinitions = new List<QuestionDefinitionDTO>();
        }
    }
}
