using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class AnswerDefinitionRepository : GenericRepository<AnswerDefinition, AnswerDefinitionDTO>, IAnswerDefinitionRepository
    {
        public AnswerDefinitionRepository(TRACContext context, IMapper mapper, ILogger<AnswerDefinitionRepository> logger) : base(context, mapper,logger)
        {
        }

    }
}