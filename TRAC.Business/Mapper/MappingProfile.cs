using System;
using System.Collections.Generic;
using AutoMapper;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Answer, AnswerDTO>();
            CreateMap<IEnumerable<Answer>, IEnumerable<AnswerDTO>>();

            CreateMap<AnswerDTO, Answer>();
            CreateMap<IEnumerable<AnswerDTO>, IEnumerable<Answer>>();

            CreateMap<AnswerDefinition, AnswerDefinitionDTO>();
            CreateMap<IEnumerable<AnswerDefinition>, IEnumerable<AnswerDefinitionDTO>>();

            CreateMap<AnswerDefinitionDTO, AnswerDefinition>();
            CreateMap<IEnumerable<AnswerDefinitionDTO>, IEnumerable<AnswerDefinition>>();

            CreateMap<Checklist, ChecklistDTO>();
            CreateMap<IEnumerable<Checklist>, IEnumerable<ChecklistDTO>>();

            CreateMap<ChecklistDTO, ChecklistDTO>();
            CreateMap<IEnumerable<ChecklistDTO>, IEnumerable<ChecklistDTO>>();

            CreateMap<ChecklistDefinition, ChecklistDefinitionDTO>();
            CreateMap<IEnumerable<ChecklistDefinition>, IEnumerable<ChecklistDefinitionDTO>>();

            CreateMap<ChecklistDefinitionDTO, ChecklistDefinition>();
            CreateMap<IEnumerable<ChecklistDefinitionDTO>, IEnumerable<ChecklistDefinition>>();

            CreateMap<ChecklistDefinitionStatus, ChecklistDefinitionStatusDTO>();
            CreateMap<IEnumerable<ChecklistDefinitionStatus>, IEnumerable<ChecklistDefinitionStatusDTO>>();

            CreateMap<ChecklistDefinitionStatusDTO, ChecklistDefinitionStatus>();
            CreateMap<IEnumerable<ChecklistDefinitionStatusDTO>, IEnumerable<ChecklistDefinitionStatus>>();

            CreateMap<ChecklistStatus, ChecklistStatusDTO>();
            CreateMap<IEnumerable<ChecklistStatus>, IEnumerable<ChecklistStatusDTO>>();

            CreateMap<ChecklistStatusDTO, ChecklistStatus>();
            CreateMap<IEnumerable<ChecklistStatusDTO>, IEnumerable<ChecklistStatus>>();

            CreateMap<MailTemplate, MailTemplateDTO>();
            CreateMap<IEnumerable<MailTemplate>, IEnumerable<MailTemplateDTO>>();

            CreateMap<MailTemplateDTO, MailTemplate>();
            CreateMap<IEnumerable<MailTemplateDTO>, IEnumerable<MailTemplate>>();

            CreateMap<QuestionDefinition, QuestionDefinitionDTO>();
            CreateMap<IEnumerable<QuestionDefinition>, IEnumerable<QuestionDefinitionDTO>>();

            CreateMap<QuestionDefinitionDTO, QuestionDefinition>();
            CreateMap<IEnumerable<QuestionDefinitionDTO>, IEnumerable<QuestionDefinition>>();

            CreateMap<QuestionDisplayCondition, QuestionDisplayConditionDTO>();
            CreateMap<IEnumerable<QuestionDisplayCondition>, IEnumerable<QuestionDisplayConditionDTO>>();

            CreateMap<QuestionDisplayConditionDTO, QuestionDisplayCondition>();
            CreateMap<IEnumerable<QuestionDisplayConditionDTO>, IEnumerable<QuestionDisplayCondition>>();

            CreateMap<Report, ReportDTO>();
            CreateMap<IEnumerable<Report>, IEnumerable<ReportDTO>>();

            CreateMap<ReportDTO, Report>();
            CreateMap<IEnumerable<ReportDTO>, IEnumerable<Report>>();

            CreateMap<SectionDefinition, SectionDefinitionDTO>();
            CreateMap<IEnumerable<SectionDefinition>, IEnumerable<SectionDefinitionDTO>>();

            CreateMap<SectionDefinitionDTO, SectionDefinition>();
            CreateMap<IEnumerable<SectionDefinitionDTO>, IEnumerable<SectionDefinition>>();

            CreateMap<Staff, StaffDTO>();
            CreateMap<IEnumerable<Staff>, IEnumerable<StaffDTO>>();

            CreateMap<StaffDTO, Staff>();
            CreateMap<IEnumerable<StaffDTO>, IEnumerable<Staff>>();

            CreateMap<WBS, WBSDTO>();
            CreateMap<IEnumerable<WBS>, IEnumerable<WBSDTO>>();

            CreateMap<WBSDTO, WBS>();
            CreateMap<IEnumerable<WBSDTO>, IEnumerable<WBS>>();
        }
    }
}
