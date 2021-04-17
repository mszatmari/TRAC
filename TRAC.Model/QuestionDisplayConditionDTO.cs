using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.Model
{
    public class QuestionDisplayConditionDTO
    {
        public int QuestionToDisplayId { get; set; }
        public int AnswerDefinitionId { get; set; }
        public virtual AnswerDefinitionDTO AnswerDefinition { get; set; }
        public virtual QuestionDefinitionDTO QuestionDefinition { get; set; }


    }
}
