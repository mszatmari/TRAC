using System.Collections.Generic;
using System.Threading.Tasks;
using TRAC.DataAccess.Data;
using TRAC.Model;

namespace TRAC.Business.Repository.IRepository
{
    public interface IChecklistDefinitionRepository : IGenericRepository<ChecklistDefinition, ChecklistDefinitionDTO>
    {
        Task<IEnumerable< ChecklistDefinitionDTO>> GetAllWithStatus();
    }
   
}
