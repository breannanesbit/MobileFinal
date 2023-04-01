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

        private static User MakeTestUser()
        {
            return new User()
            {
                FirstName = "Test",
                LastName = "McTesty",
                Username = "Test@test.com",
            };
        }

        private static Media MakeVideoMedia()
        {
            return new Media()
            {
                Id = 1,
                MediaKey = "Test",
                DateUpload = DateTime.Now,
                UserId = 1,
            };
        }

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
        public async Task MakeAndConfirmUser()
        {
            await service.PostUserAsync(MakeTestUser());
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
            Media media = MakeVideoMedia();

            await service.PostUserAsync(MakeTestUser());

            await service.PostMediaAsync(media);

            var list = await service.GetAllMedia();

            Assert.AreEqual(1, list.Count());
        }

        [Test]
        public async Task GetOneUsersMedia()
        {
            await service.PostUserAsync(MakeTestUser());
            await service.PostMediaAsync(MakeVideoMedia());
            List<Media> list = service.GetAllUserMedia(1);
            Assert.AreEqual(1, list.Count());
        }
        [Test]
        public async Task GetOneUsersMediaWith2Media()
        {
            await service.PostUserAsync(MakeTestUser());
            await service.PostMediaAsync(MakeVideoMedia());
            await service.PostMediaAsync(new Media()
            {
                Id = 2,
                MediaKey = "AAH",
                UserId = 1,
                DateUpload = DateTime.Now,
            });
            List<Media> list = service.GetAllUserMedia(1);
            Assert.AreEqual(2, list.Count());
        }

        [Test]
        public async Task GetOneUsersMediaWith0Media()
        {
            await service.PostUserAsync(MakeTestUser());
            await service.PostMediaAsync(MakeVideoMedia());
            await service.PostMediaAsync(new Media()
            {
                Id = 2,
                MediaKey = "AAH",
                UserId = 1,
                DateUpload = DateTime.Now,
            });
            List<Media> list = service.GetAllUserMedia(2);
            Assert.AreEqual(0, list.Count());
        }


        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}