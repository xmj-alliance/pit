using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.App.Database
{
    public class DBContext : IDBContext, IDisposable
    {
        public string DatabaseName = "DapperORM_Test";
        public IDbConnection Connection { get; set; }

        public DBContext()
        {
            Connection = new SqlConnection($"myconn to db");
        }

        public async Task<bool> Drop()
        {
            await Connection.ExecuteAsync($@"

                USE tempdb;
                DECLARE @SQL nvarchar(1000);
                IF EXISTS (SELECT 1 FROM sys.databases WHERE [name] = N'{DatabaseName}')
                BEGIN
                    SET @SQL = N'USE [{DatabaseName}];

                                 ALTER DATABASE {DatabaseName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                                 USE [tempdb];

                                 DROP DATABASE {DatabaseName};';
                    EXEC (@SQL);
                END;

            ");

            return true;
        }

        public async Task<bool> Create()
        {
            using (var masterConnection = new SqlConnection("my conn str to master db"))
            {
                await masterConnection.ExecuteAsync($@"
                    CREATE DATABASE {DatabaseName}  
                ");
            }
                
            return true;
        }

        public void Dispose()
        {
            Connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
