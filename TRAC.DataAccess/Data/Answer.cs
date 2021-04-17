using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.DataAccess.Data
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int ChecklistId { get; set; }
        public int? AnswerDefinitionId { get; set; }
        public int QuestionDefinitionId { get; set; }

        [ForeignKey("ChecklistId")]
        public virtual Checklist Checklist { get; set; }
        [ForeignKey("AnswerDefinitionId")]
        public virtual AnswerDefinition AnswerDefinition { get; set; }
        [ForeignKey("QuestionDefinitionId")]
        public virtual QuestionDefinition QuestionDefinition { get; set; }

    }
}
