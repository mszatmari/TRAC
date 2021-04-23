using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class ChecklistDefinitionStatusRepository : GenericRepository<ChecklistDefinitionStatus, ChecklistDefinitionStatusDTO>, IChecklistDefinitionStatusRepository
    {
        public ChecklistDefinitionStatusRepository(TRACContext context, IMapper mapper, ILogger<ChecklistDefinitionStatusRepository> logger) : base(context, mapper, logger)
        {
        }
    }
}