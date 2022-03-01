using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<ChecklistDefinitionDTO>> GetAllWithStatus()
        {
            return await List(orderBy: a => a.OrderBy(b => b.Id), includeProperties: new List<System.Linq.Expressions.Expression<Func<ChecklistDefinition, object>>>() { a => a.ChecklistDefinitionStatus });
        }
    }
}