using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class ChecklistRepository : GenericRepository<Checklist, ChecklistDTO>, IChecklistRepository
    {
        public ChecklistRepository(TRACContext context, IMapper mapper, ILogger<ChecklistRepository> logger) : base(context, mapper, logger)
        {
        }
    }
}