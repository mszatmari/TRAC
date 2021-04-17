using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.DataAccess.Data
{
    public class AnswerDefinition
    {
        public AnswerDefinition()
        {
            Answers = new List<Answer>();
            QuestionDisplayConditions = new List<QuestionDisplayCondition>();
        }
        public int Id { get; set; }
        public string Label { get; set; }
        public int QuestionDefinitionId { get; set; }
        public int InvolveTax { get; set; }

        [ForeignKey("QuestionDefinitionId")]
        public virtual QuestionDefinition QuestionDefinition { get; set; }
        public virtual List<QuestionDisplayCondition> QuestionDisplayConditions { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}
