using DapperORM.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperORM.App.Services
{
    public interface IDataAccessService<T, TInput>
    {
        Task<CUDMessage> Save(IEnumerable<TInput> newItems, string storedProcedureName = null, string spInputParamName = null, string sqlInputTypeName = null);
        Task<IEnumerable<T>> GetByIDs(IEnumerable<int> ids);
        Task<IEnumerable<T>> GetByDBNames(IEnumerable<string> dbnames);
        Task<CUDMessage> DeleteByIDs(IEnumerable<int> ids);
    }
}
