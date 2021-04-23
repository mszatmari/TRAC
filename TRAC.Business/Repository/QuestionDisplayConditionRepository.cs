using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class QuestionDisplayConditionRepository : GenericRepository<QuestionDisplayCondition, QuestionDisplayConditionDTO>, IQuestionDisplayConditionRepository
    {
        public QuestionDisplayConditionRepository(TRACContext context, IMapper mapper, ILogger<QuestionDisplayConditionRepository> logger) : base(context, mapper, logger)
        {
        }
    }
}