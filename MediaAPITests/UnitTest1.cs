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
        private IQueryable<Category> categories;

        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<MultiMediaAppContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            context = new MultiMediaAppContext(options);
            service = new DatabaseService(context);

            categories = new List<Category>()
            {
                new Category 
                { 
                    Id = 1,
                    Category1 = "video"
                },
                new Category
                {
                    Id = 2,
                    Category1 = "audio"
                },
                new Category
                {
                    Id = 1,
                    Category1 = "visual"
                },
            }.AsQueryable();

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
            Assert.AreEqual("Test", list[0].FirstName);
        }
        [Test]
        public async Task GetMediaEmptyList()
        {
            
            var list = await service.GetAllMedia();
            Assert.AreEqual(0, list.Count());
        }
        [Test]
        public async Task GetMediaOneItem()
        {
            Media media = new Media()
            {
                Id = 1,
                MediaKey = "Test",
                DateUpload = DateTime.Now,
                UserId = 1,
            };
            User userList = new User()
            {
                FirstName = "Test",
                LastName = "McTesty",
                Username = "Test@test.com",
                Id = 1,
            };
            service.PostUserAsync(userList);

            service.PostMediaAsync(media);
            var list = await service.GetAllMedia();
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