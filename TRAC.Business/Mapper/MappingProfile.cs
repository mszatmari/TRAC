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

            CreateMap<AnswerDTO, Answer>();

            CreateMap<AnswerDefinition, AnswerDefinitionDTO>();

            CreateMap<AnswerDefinitionDTO, AnswerDefinition>();

            CreateMap<Checklist, ChecklistDTO>();

            CreateMap<ChecklistDTO, ChecklistDTO>();

            CreateMap<ChecklistDefinition, ChecklistDefinitionDTO>();

            CreateMap<ChecklistDefinitionDTO, ChecklistDefinition>();

            CreateMap<ChecklistDefinitionStatus, ChecklistDefinitionStatusDTO>();

            CreateMap<ChecklistDefinitionStatusDTO, ChecklistDefinitionStatus>();

            CreateMap<ChecklistStatus, ChecklistStatusDTO>();

            CreateMap<ChecklistStatusDTO, ChecklistStatus>();

            CreateMap<MailTemplate, MailTemplateDTO>();

            CreateMap<MailTemplateDTO, MailTemplate>();

            CreateMap<QuestionDefinition, QuestionDefinitionDTO>();

            CreateMap<QuestionDefinitionDTO, QuestionDefinition>();

            CreateMap<QuestionDisplayCondition, QuestionDisplayConditionDTO>();

            CreateMap<QuestionDisplayConditionDTO, QuestionDisplayCondition>();

            CreateMap<Report, ReportDTO>();

            CreateMap<ReportDTO, Report>();

            CreateMap<SectionDefinition, SectionDefinitionDTO>();

            CreateMap<SectionDefinitionDTO, SectionDefinition>();

            CreateMap<Staff, StaffDTO>();

            CreateMap<StaffDTO, Staff>();

            CreateMap<WBS, WBSDTO>();

            CreateMap<WBSDTO, WBS>();
        }
    }
}
