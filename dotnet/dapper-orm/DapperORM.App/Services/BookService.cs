using Dapper;
using DapperORM.App.Database;
using DapperORM.App.Library;
using DapperORM.App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperORM.App.Services
{
    public class BookService: DataAccessService<Book, InputBook>, IBookService
    {
        private readonly IDBContext dbContext;

        public BookService(
            IDBContext dbContext
        ): base(
            dbContext,
            "book"
        )
        {
            this.dbContext = dbContext;
        }

    }
}