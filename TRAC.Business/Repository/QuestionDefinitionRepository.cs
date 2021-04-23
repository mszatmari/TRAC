using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class QuestionDefinitionRepository : GenericRepository<QuestionDefinition, QuestionDefinitionDTO>, IQuestionDefinitionRepository
    {
        public QuestionDefinitionRepository(TRACContext context, IMapper mapper, ILogger<QuestionDefinitionRepository> logger) : base(context, mapper, logger)
        {
        }
    }
}