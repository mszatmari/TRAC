using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.DataAccess.Data
{
    public class Checklist
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

        [ForeignKey("ChecklistDefinitionId")]
        public virtual ChecklistDefinition ChecklistDefinition { get; set; }
        [ForeignKey("CheckListStatusId")]
        public virtual ChecklistStatus ChecklistStatus { get; set; }
        [ForeignKey("ReportId")]
        public virtual Report Report { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Creator { get; set; }
        [ForeignKey("ValidatorId")]
        public virtual Staff Validator { get; set; }

        public virtual List<Answer> Answers { get; set; }


        public Checklist()
        {
            Answers = new List<Answer>();
        }


    }
}
