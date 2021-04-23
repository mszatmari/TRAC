using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class StaffRepository : GenericRepository<Staff, StaffDTO>, IStaffRepository
    {
        public StaffRepository(TRACContext context, IMapper mapper, ILogger<StaffRepository> logger) : base(context, mapper, logger)
        {
        }
    }
}