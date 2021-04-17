using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.DataAccess.Data
{
    public class QuestionDefinition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsAlwaysDisplayed { get; set; }
        public int? SectionDefinitionId { get; set; }
        public int QuestionOrder{ get; set; }

        [ForeignKey("SectionDefinitionId")]
        public virtual SectionDefinition SectionDefinition { get; set; }

        public virtual List<AnswerDefinition> AnswerDefinitions { get; set; }
        public virtual List<QuestionDisplayCondition> QuestionDisplayConditions { get; set; }
        public virtual List<Answer> Answers { get; set; }

        public QuestionDefinition()
        {
            AnswerDefinitions = new List<AnswerDefinition>();
            QuestionDisplayConditions = new List<QuestionDisplayCondition>();
            Answers = new List<Answer>();
        }
    }
}
