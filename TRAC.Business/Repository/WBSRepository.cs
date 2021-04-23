using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class WBSRepository : GenericRepository<WBS, WBSDTO>, IWBSRepository
    {
        public WBSRepository(TRACContext context, IMapper mapper, ILogger<WBSRepository> logger) : base(context, mapper, logger)
        {
        }
    }
}