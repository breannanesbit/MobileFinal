using MediaAPI;
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
       
        [SetUp]
        public void Setup()
        {
           
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

            var servicemock = new Mock<IUserService>();
            //servicemock.Setups(x => x.);

            /*await service.PostUserAsync(user);
            var test = service.GetUserList();
            Assert.AreEqual(1, test.Result.Count);
            //TearDown();*/
        }



       /* [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        } */
    }
}