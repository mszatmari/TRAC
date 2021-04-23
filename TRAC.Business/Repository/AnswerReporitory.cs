using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class AnswerReporitory : GenericRepository<Answer, AnswerDTO>, IAnswerRepository
    {
        public AnswerReporitory(TRACContext context, IMapper mapper,ILogger<AnswerReporitory> logger) : base(context, mapper, logger)
        {
        }
    }
}
