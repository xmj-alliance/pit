using Dapper;
using DapperORM.App.Database;
using DapperORM.App.Library;
using DapperORM.App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.App.Services
{
    public class DataAccessService<T, TInput> : IDataAccessService<T, TInput>
    {
        private readonly IDBContext dbContext;
        public string ItemName { get; } // Must be provided from constructor. e.g. book
        public string ItemPluralName { get; } // (Optional) Calculate from ItemName if not provided. e.g. book -> books
        public string TableName { get; } // (Optional) Calculate from ItemPluralName or ItemName if not provided. e.g. book -> Books

        public DataAccessService(
            IDBContext dbContext,
            string ItemName,
            string ItemPluralName = null,
            string TableName = null
        )
        {
            this.dbContext = dbContext;
            this.ItemName = ItemName;
            this.ItemPluralName = string.IsNullOrEmpty(ItemPluralName) ? $"{ItemName}s": ItemPluralName;
            this.TableName = string.IsNullOrEmpty(TableName) ? $"{this.ItemPluralName.First().ToString().ToUpper()}{this.ItemPluralName[1..]}" : TableName;
        }

        public async Task<CUDMessage> Save(IEnumerable<TInput> newItems, string storedProcedureName = null, string spInputParamName = null, string sqlInputTypeName = null)
        {

            // Guess SP name, input param name and input type name if not provided
            string spNameToUse = string.IsNullOrEmpty(storedProcedureName) ?
                    $"[P_Mutation_Save{TableName}]":
                    storedProcedureName;

            string inputParamNameToUse = string.IsNullOrEmpty(spInputParamName) ?
                    $"@input{TableName}" :
                    sqlInputTypeName;

            string inputTypeToUse = string.IsNullOrEmpty(sqlInputTypeName) ?
                    $"[Input{TableName}]" :
                    sqlInputTypeName;

            var itemTable = DataTableUtility.FromObjects(newItems);

            long rowsAffected = -1;

            var parameters = new DynamicParameters();
            parameters.Add(inputParamNameToUse, itemTable.AsTableValuedParameter(inputTypeToUse));

            try
            {
                rowsAffected = await dbContext.Connection.ExecuteAsync(
                    spNameToUse,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception e)
            {
                return new CUDMessage(
                    Ok: false,
                    NumAffected: rowsAffected,
                    Message: $"Failed to save {ItemPluralName}: {e.Message}"
                );
            }

            return new CUDMessage(
                Ok: true,
                NumAffected: rowsAffected,
                Message: $"Successfully saved {itemTable.Rows.Count} {ItemPluralName}."
            );
        }

        public async Task<IEnumerable<T>> GetByIDs(IEnumerable<int> ids)
        {
            IEnumerable<T> items;

            try
            {
                items = await dbContext.Connection.QueryAsync<T>(
                    "[P_Query_GetItems]",
                    new
                    {
                        tableName = TableName,
                        ids = string.Join(',', ids),
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to retrieve {ItemPluralName}: {e.Message}");
                return null;
            }

            return items;
        }

        public async Task<IEnumerable<T>> GetByDBNames(IEnumerable<string> dbnames)
        {
            IEnumerable<T> items;

            var quotedDBNames = (
                from dbname in dbnames
                select $"'{dbname}'"
            );

            try
            {
                items = await dbContext.Connection.QueryAsync<T>(
                    "[P_Query_GetItems]",
                    new
                    {
                        tableName = TableName,
                        dbNames = string.Join(',', quotedDBNames),
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to retrieve {ItemPluralName}: {e.Message}");
                return null;
            }

            return items;
        }

        public async Task<CUDMessage> DeleteByIDs(IEnumerable<int> ids)
        {
            long rowsAffected = -1;
            try
            {
                rowsAffected = await dbContext.Connection.ExecuteAsync(
                    "[P_Mutation_DeleteItems]",
                    new
                    {
                        tableName = TableName,
                        ids = string.Join(',', ids),
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception e)
            {
                return new CUDMessage(
                    Ok: false,
                    NumAffected: rowsAffected,
                    Message: $"Failed to delete {ItemPluralName}: {e.Message}"
                );
            }

            return new CUDMessage(
                Ok: true,
                NumAffected: rowsAffected,
                Message: "yes"
            );
        }

    }
}
