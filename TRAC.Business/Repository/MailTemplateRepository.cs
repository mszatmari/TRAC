using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class MailTemplateRepository : GenericRepository<MailTemplate, MailTemplateDTO>, IMailTemplateRepository
    {
        public MailTemplateRepository(TRACContext context, IMapper mapper, ILogger<MailTemplateRepository> logger) : base(context, mapper, logger)
        {
        }
    }
}