using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class ReportRepository : GenericRepository<Report, ReportDTO>, IReportRepository
    {
        public ReportRepository(TRACContext context, IMapper mapper, ILogger<ReportRepository> logger) : base(context, mapper, logger)
        {
        }
    }
}