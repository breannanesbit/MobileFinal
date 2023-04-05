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
            Assert.That(list.Count(), Is.EqualTo(1));
            Assert.That(list[0].FirstName, Is.EqualTo("Test"));
        }
        [Test]
        public async Task GetAllUsers2Users()
        {
            await service.PostUserAsync(MakeTestUser());
            await service.PostUserAsync(MakeTestUser());

            var list = await service.GetUserList();
            Assert.That(list.Count(), Is.EqualTo(2));

        }


        [Test]
        public async Task GetUserByUsername()
        {
            await service.PostUserAsync(MakeTestUser());
            User user = await service.GetUserByUsername("Test@test.com");

            Assert.IsNotNull(user);
            Assert.That(user.FirstName, Is.EqualTo("Test"));
            Assert.That(user.LastName, Is.EqualTo("McTesty"));
        }
        

        [Test]
        public async Task GetMediaEmptyList()
        {

            var list = await service.GetAllMedia();
            Assert.That(list.Count(), Is.EqualTo(0));
        }
        [Test]
        public async Task GetMediaOneItem()
        {
            Media media = MakeVideoMedia();

            await service.PostUserAsync(MakeTestUser());

            await service.PostMediaAsync(media);

            var list = await service.GetAllMedia();

            Assert.That(list.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetOneUsersMedia()
        {
            await service.PostUserAsync(MakeTestUser());
            await service.PostMediaAsync(MakeVideoMedia());
            List<Media> list = service.GetAllUserMedia(1);
            Assert.That(list.Count(), Is.EqualTo(1));
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
            Assert.That(list.Count(), Is.EqualTo(2));
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
            Assert.That(list.Count(), Is.EqualTo(0));
        }
        [Test]
        public async Task GetOneUser1Media()
        {
            await service.PostUserAsync(MakeTestUser());
            await service.PostMediaAsync(MakeVideoMedia());
            await service.PostMediaAsync(new Media()
            {
                Id = 2,
                MediaKey = "AAH",
                UserId = 2,
                DateUpload = DateTime.Now,
            });
            List<Media> list = service.GetAllUserMedia(2);
            Assert.That(list.Count(), Is.EqualTo(1));
            list = service.GetAllUserMedia(1);
            Assert.That(list.Count(), Is.EqualTo(1));
        }
        [Test]
        public async Task GetMediaFromKey()
        {
            await service.PostUserAsync(MakeTestUser());
            await service.PostMediaAsync(MakeVideoMedia());
            Media media = await service.GetMediaByKey("Test");
            Assert.IsNotNull(media);
            Assert.That(media.Id, Is.EqualTo(1));
            Assert.That(media.UserId, Is.EqualTo(1));
            Assert.That(media.MediaKey, Is.EqualTo("Test"));
        }
        [Test]
        public async Task GetMediaFromKeyWith2Keys()
        {
            await service.PostUserAsync(MakeTestUser());
            await service.PostMediaAsync(MakeVideoMedia());
            await service.PostMediaAsync(new Media()
            {
                Id = 2,
                MediaKey = "AAH",
                UserId = 2,
                DateUpload = DateTime.Now,
            });
            Media media = await service.GetMediaByKey("AAH");
            Assert.IsNotNull(media);
            Assert.That(media.Id, Is.EqualTo(2));
            Assert.That(media.UserId, Is.EqualTo(2));
            Assert.That(media.MediaKey, Is.EqualTo("AAH"));
        }

        [Test]
        public Task ReturnErrorNoMatchingKey()
        {
            Assert.ThrowsAsync<NotFoundException>(
            async () => await service.GetMediaByKey("AAH"));
            return Task.CompletedTask;
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }//
    }
}