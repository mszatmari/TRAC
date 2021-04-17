using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.DataAccess.Data
{
    public class QuestionDisplayCondition
    {
        [Key]
        [Column(Order = 1)]
        public int QuestionToDisplayId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int AnswerDefinitionId { get; set; }

        public virtual AnswerDefinition AnswerDefinition { get; set; }

        public virtual QuestionDefinition QuestionDefinition { get; set; }


    }
}
