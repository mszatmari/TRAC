using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.Model
{
    public class QuestionDefinitionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsAlwaysDisplayed { get; set; }
        public int? SectionDefinitionId { get; set; }
        public int QuestionOrder{ get; set; }

        public virtual SectionDefinitionDTO SectionDefinition { get; set; }

        public virtual List<AnswerDefinitionDTO> AnswerDefinitions { get; set; }
        public virtual List<QuestionDisplayConditionDTO> QuestionDisplayConditions { get; set; }
        public virtual List<AnswerDTO> Answers { get; set; }

        public QuestionDefinitionDTO()
        {
            AnswerDefinitions = new List<AnswerDefinitionDTO>();
            QuestionDisplayConditions = new List<QuestionDisplayConditionDTO>();
            Answers = new List<AnswerDTO>();
        }
    }
}
