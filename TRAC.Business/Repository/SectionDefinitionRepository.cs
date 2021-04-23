using AutoMapper;
using Microsoft.Extensions.Logging;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository
{
    public class SectionDefinitionRepository : GenericRepository<SectionDefinition, SectionDefinitionDTO>, ISectionDefinitionRepository
    {
        public SectionDefinitionRepository(TRACContext context, IMapper mapper, ILogger<SectionDefinitionRepository> logger) : base(context, mapper, logger)
        {
        }
       
    }
}