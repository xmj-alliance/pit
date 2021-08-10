using DapperORM.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperORM.App.Services
{
    public interface IBookService : IDataAccessService<Book, InputBook>
    {
    }
}
