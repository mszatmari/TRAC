using System;
using System.Collections.Generic;

namespace TRAC.Model
{
    public class ChecklistDTO
    {

        public int Id { get; set; }
        public string EntityName { get; set; }
        public DateTime StartDate { get; set; }
        public int ChecklistDefinitionId { get; set; }
        public int StaffId { get; set; }
        public int CheckListStatusId { get; set; }
        public int? ReportId { get; set; }
        public int FinancialYear { get; set; }
        public string RejectedComment { get; set; }
        public bool IsDeleted { get; set; }
        public int? ValidatorId { get; set; }

        public virtual ChecklistDefinitionDTO ChecklistDefinition { get; set; }
        public virtual ChecklistStatusDTO ChecklistStatus { get; set; }
        public virtual ReportDTO Report { get; set; }
        public virtual StaffDTO Creator { get; set; }
        public virtual StaffDTO Validator { get; set; }

        public virtual List<AnswerDTO> Answers { get; set; }


        public ChecklistDTO()
        {
            Answers = new List<AnswerDTO>();
        }


    }
}
