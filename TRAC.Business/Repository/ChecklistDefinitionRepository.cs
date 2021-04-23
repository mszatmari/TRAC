using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class ChecklistDefinitionRepository : GenericRepository<ChecklistDefinition, ChecklistDefinitionDTO>, IChecklistDefinitionRepository
    {
        public ChecklistDefinitionRepository(TRACContext context, IMapper mapper, ILogger<ChecklistDefinitionRepository> logger) : base(context, mapper,logger)
        {
        }
    }
}