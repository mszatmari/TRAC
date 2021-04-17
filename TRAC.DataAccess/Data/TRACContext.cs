using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TRAC.DataAccess.Data
{
    public class TRACContext : DbContext
    {
       public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerDefinition> AnswerDefinitions { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistDefinition> ChecklistDefinitions { get; set; }
        public DbSet<ChecklistDefinitionStatus> ChecklistDefinitionStatuses { get; set; }
        public DbSet<ChecklistStatus> ChecklistStatuses { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<QuestionDefinition> QuestionDefinitions { get; set; }
        public DbSet<QuestionDisplayCondition> QuestionDisplayConditions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SectionDefinition> SectionDefinitions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<WBS> WBs { get; set; }

        public TRACContext(DbContextOptions<TRACContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.Entity<QuestionDisplayCondition>()
            .HasKey(t => new { t.AnswerDefinitionId, t.QuestionToDisplayId });

            _ = modelBuilder.Entity<QuestionDefinition>()
                .HasMany(a => a.QuestionDisplayConditions)
                .WithOne(a => a.QuestionDefinition)
                .HasForeignKey(a => a.QuestionToDisplayId);

            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasMany(a => a.QuestionDisplayConditions)
                .WithOne(a => a.AnswerDefinition)
                .HasForeignKey(a => a.AnswerDefinitionId);

            _ = modelBuilder.Entity<Staff>()
                .HasMany(a => a.CreatorChecklists)
                .WithOne(a => a.Creator)
                .HasForeignKey(a => a.StaffId);

            _ = modelBuilder.Entity<Staff>()
                .HasMany(a => a.ValidatorChecklists)
                .WithOne(a => a.Validator)
                .HasForeignKey(a => a.ValidatorId);

            _ = modelBuilder.Entity<ChecklistStatus>()
                .HasData(new ChecklistStatus { Id = 1, Code = "IN_PROGRESS", Label = "In progress" });
            _ = modelBuilder.Entity<ChecklistStatus>()
                .HasData(new ChecklistStatus { Id = 2, Code = "ClOSED", Label = "Closed" });
            _ = modelBuilder.Entity<ChecklistStatus>()
                .HasData(new ChecklistStatus { Id = 3, Code = "PENDING_VALIDATION", Label = "Pending Validation" });

            _ = modelBuilder.Entity<ChecklistDefinitionStatus>()
              .HasData(new ChecklistDefinitionStatus { Id = 2, Code = "OPEN", Label = "Open" });
            _ = modelBuilder.Entity<ChecklistDefinitionStatus>()
                .HasData(new ChecklistDefinitionStatus { Id = 1, Code = "ClOSED", Label = "Closed" });

            _ = modelBuilder.Entity<ChecklistDefinition>()
                .HasData(new ChecklistDefinition { ChecklistDefinitionStatusId = 2, Id = 1, Title = "Checklist 1" });

            _ = modelBuilder.Entity<SectionDefinition>()
                .HasData(new SectionDefinition { Id = 1, ChecklistDefinitionId = 1, Name = "Section 1", SectionOrder = 1 });

            _ = modelBuilder.Entity<SectionDefinition>()
                .HasData(new SectionDefinition { Id = 2, ChecklistDefinitionId = 1, Name = "Section 2", SectionOrder = 2 });

            _ = modelBuilder.Entity<SectionDefinition>()
                .HasData(new SectionDefinition { Id = 3, ChecklistDefinitionId = 1, Name = "Section 3", SectionOrder = 3 });

            _ = modelBuilder.Entity<QuestionDefinition>()
                .HasData(new QuestionDefinition { Id = 1, IsAlwaysDisplayed = true, SectionDefinitionId = 1, Title = "Question 1", QuestionOrder = 1 });
            _ = modelBuilder.Entity<QuestionDefinition>()
                .HasData(new QuestionDefinition { Id = 2, IsAlwaysDisplayed = true, SectionDefinitionId = 1, Title = "Question 2", QuestionOrder = 2 });
            _ = modelBuilder.Entity<QuestionDefinition>()
                .HasData(new QuestionDefinition { Id = 3, IsAlwaysDisplayed = true, SectionDefinitionId = 2, Title = "Question 3", QuestionOrder = 1 });
            _ = modelBuilder.Entity<QuestionDefinition>()
                .HasData(new QuestionDefinition { Id = 4, IsAlwaysDisplayed = true, SectionDefinitionId = 2, Title = "Question 4", QuestionOrder = 2 });
            _ = modelBuilder.Entity<QuestionDefinition>()
                .HasData(new QuestionDefinition { Id = 5, IsAlwaysDisplayed = true, SectionDefinitionId = 3, Title = "Question 5", QuestionOrder = 1 });
            _ = modelBuilder.Entity<QuestionDefinition>()
                .HasData(new QuestionDefinition { Id = 6, IsAlwaysDisplayed = true, SectionDefinitionId = 3, Title = "Question 6", QuestionOrder = 2 });

            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 1, InvolveTax = 0, QuestionDefinitionId = 1, Label = "Yes" });
            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 2, InvolveTax = 0, QuestionDefinitionId = 1, Label = "No" });

            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 3, InvolveTax = 0, QuestionDefinitionId = 2, Label = "Yes" });
            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 4, InvolveTax = 0, QuestionDefinitionId = 2, Label = "No" });

            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 5, InvolveTax = 0, QuestionDefinitionId = 3, Label = "Yes" });
            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 6, InvolveTax = 0, QuestionDefinitionId = 3, Label = "No" });

            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 7, InvolveTax = 0, QuestionDefinitionId = 4, Label = "Yes" });
            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 8, InvolveTax = 0, QuestionDefinitionId = 4, Label = "No" });

            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 9, InvolveTax = 0, QuestionDefinitionId = 5, Label = "Yes" });
            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 10, InvolveTax = 0, QuestionDefinitionId = 5, Label = "No" });

            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 11, InvolveTax = 0, QuestionDefinitionId = 6, Label = "Yes" });
            _ = modelBuilder.Entity<AnswerDefinition>()
                .HasData(new AnswerDefinition { Id = 12, InvolveTax = 0, QuestionDefinitionId = 6, Label = "No" });





        }
    }
}
