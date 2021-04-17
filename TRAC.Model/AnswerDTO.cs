namespace TRAC.Model
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public int ChecklistId { get; set; }
        public int? AnswerDefinitionId { get; set; }
        public int QuestionDefinitionId { get; set; }

        public virtual ChecklistDTO Checklist { get; set; }

        public virtual AnswerDefinitionDTO AnswerDefinition { get; set; }

        public virtual QuestionDefinitionDTO QuestionDefinition { get; set; }

    }
}
