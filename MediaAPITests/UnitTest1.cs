using MediaAPI;
using MediaAPI.services;
using MediaAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Shared;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;

namespace MediaAPITests
{

    public class Tests
    {
        private DatabaseService service;
        private MultiMediaAppContext context;

        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<MultiMediaAppContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            context = new MultiMediaAppContext(options);
            service = new DatabaseService(context);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task MakeAndConfirmUser()
        {

            User userList = new User()
            {
                FirstName = "Test",
                LastName = "McTesty",
                Username = "Test@test.com",
            };
            service.PostUserAsync(userList);
            var list = await service.GetUserList();
            Assert.AreEqual(1, list.Count());
        }



        [TearDown]
         public void TearDown()
         {
             context.Database.EnsureDeleted();
             context.Dispose();
         }
    }
}