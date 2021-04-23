using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class ChecklistStatusRepository : GenericRepository<ChecklistStatus, ChecklistStatusDTO>, IChecklistStatusRepository
    {
        public ChecklistStatusRepository(TRACContext context, IMapper mapper, ILogger<ChecklistStatusRepository> logger) : base(context, mapper, logger)
        {
        }
    }
}