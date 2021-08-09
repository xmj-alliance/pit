using Dapper;
using DapperORM.App.Database;
using DapperORM.App.Library;
using DapperORM.App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DapperORM.App.Services
{
    public class BookService: IBookService
    {
        private readonly IDBContext dbContext;

        public BookService(
            IDBContext dbContext
        )
        {
            this.dbContext = dbContext;
        }

        public async Task<CUDMessage> Save(IEnumerable<InputBook> newBooks)
        {

            var booksTable = DataTableUtility.FromObjects(newBooks);

            long rowsAffected = -1;
            try
            {
                rowsAffected = await dbContext.Connection.ExecuteAsync(
                    "[P_Mutation_SaveBooks]",
                    new { inputBooks = booksTable.AsTableValuedParameter("[InputBooks]") },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception e)
            {
                return new CUDMessage(
                    Ok: false,
                    NumAffected: rowsAffected,
                    Message: $"Failed to save books: {e.Message}"
                );
            }

            return new CUDMessage(
                Ok: true,
                NumAffected: rowsAffected,
                Message: "yes"
            );

        }

        public async Task<IEnumerable<Book>> GetByIDs(IEnumerable<int> ids)
        {
            var idTable = DataTableUtility.FromValues(ids, "Id");
            IEnumerable<Book> books;

            try
            {
                books = await dbContext.Connection.QueryAsync<Book>(
                    "[P_Query_GetBooksByIDs]",
                    new { ids = idTable.AsTableValuedParameter("[IntList]") },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to retrieve books: {e.Message}");
                return null;
            }

            return books;
        }

        public async Task<IEnumerable<Book>> GetByDBNames(IEnumerable<string> dbnames)
        {
            var dbNameTable = DataTableUtility.FromValues(dbnames, "Key");
            IEnumerable<Book> books;

            try
            {
                books = await dbContext.Connection.QueryAsync<Book>(
                    "[P_Query_GetBooksByDBNames]",
                    new { dbnames = dbNameTable.AsTableValuedParameter("[KeyList]") },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to retrieve books: {e.Message}");
                return null;
            }

            return books;
        }

        public async Task<CUDMessage> DeleteByIDs(IEnumerable<int> ids)
        {
            var idTable = DataTableUtility.FromValues(ids, "Id");
            long rowsAffected = -1;
            try
            {
                rowsAffected = await dbContext.Connection.ExecuteAsync(
                    "[P_Mutation_DeleteBooksByIDs]",
                    new { ids = idTable.AsTableValuedParameter("[IntList]") },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to delete books: {e.Message}");
                return null;
            }

            return new CUDMessage(
                Ok: true,
                NumAffected: rowsAffected,
                Message: "yes"
            );

        }

    }
}