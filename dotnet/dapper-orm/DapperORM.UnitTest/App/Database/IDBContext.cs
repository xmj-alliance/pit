using System.Data;
using System.Threading.Tasks;

namespace DapperORM.App.Database
{
    public interface IDBContext
    {
        IDbConnection Connection { get; }
        Task<bool> Drop();
        Task<bool> Create();
    }
}