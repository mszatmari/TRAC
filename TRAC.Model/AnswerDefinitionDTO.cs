using System.Collections.Generic;

namespace TRAC.Model
{
    public class AnswerDefinitionDTO
    {
        public AnswerDefinitionDTO()
        {
            Answers = new List<AnswerDTO>();
            QuestionDisplayConditions = new List<QuestionDisplayConditionDTO>();
        }
        public int Id { get; set; }
        public string Label { get; set; }
        public int QuestionDefinitionId { get; set; }
        public int InvolveTax { get; set; }

        public virtual QuestionDefinitionDTO QuestionDefinition { get; set; }
        public virtual List<QuestionDisplayConditionDTO> QuestionDisplayConditions { get; set; }
        public virtual List<AnswerDTO> Answers { get; set; }
    }
}
