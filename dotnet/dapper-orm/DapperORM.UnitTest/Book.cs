using DapperORM.App.Database;
using DapperORM.App.Models;
using DapperORM.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Respawn;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DapperORM.UnitTest
{
    public class BookTest : IClassFixture<ServiceFixture>, IAsyncLifetime
    {
        private readonly IDBContext dbContext;
        private readonly IBookService bookService;
        private readonly IHost testHost;
        private readonly Checkpoint checkpoint = new();

        public BookTest(ServiceFixture fixture)
        {
            testHost = fixture.TestHost;
            dbContext = testHost.Services.GetService<IDBContext>();
            bookService = testHost.Services.GetService<IBookService>();
        }

        [Theory(DisplayName = "Book Crud Test")]
        [ClassData(typeof(BookData))]
        public async void Crud(List<InputBook> newBooks)
        {
            CUDMessage addMessage = await bookService.Add(newBooks);

            Assert.True(addMessage.Ok);
            Assert.Equal(addMessage.NumAffected, newBooks.Count);

            var dbnames = (
                from newBook in newBooks
                select newBook.DBName
            );

            var booksInDB = await bookService.GetByDBNames(dbnames);
            Assert.Equal(booksInDB.Count(), newBooks.Count);
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public Task DisposeAsync() => checkpoint.Reset(dbContext.Connection as DbConnection);
    }

    public class BookData : TheoryData<List<InputBook>>
    {
        public BookData()
        {
            Add(new List<InputBook>() {
                new InputBook(
                    DBName: "book-StoryMixups",
                    Title: "Story Mix-ups",
                    Rating: 1.1f
                ),
            });
        }

    }
}