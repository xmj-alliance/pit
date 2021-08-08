using DapperORM.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.App.Services
{
    public interface IBookService
    {
        Task<CUDMessage> Add(IEnumerable<InputBook> newBooks);
        Task<IEnumerable<Book>> GetByIDs(IEnumerable<int> ids);
        Task<IEnumerable<Book>> GetByDBNames(IEnumerable<string> dbnames);
    }
}
