using DapperORM.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperORM.App.Services
{
    public interface IBookService
    {
        Task<CUDMessage> Save(IEnumerable<InputBook> newBooks);
        Task<IEnumerable<Book>> GetByIDs(IEnumerable<int> ids);
        Task<IEnumerable<Book>> GetByDBNames(IEnumerable<string> dbnames);
        Task<CUDMessage> DeleteByIDs(IEnumerable<int> ids);
    }
}
