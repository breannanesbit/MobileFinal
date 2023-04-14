using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace MediaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public MultiMediaAppContext Context { get; }

        public UserController(MultiMediaAppContext context)
        {
            Context = context;
        }

        [HttpPost]
        public async Task PostUserAsync(User user)
        {
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
        }

        [HttpGet("all")]
        public async Task<List<User>> GetUserList()
        {
            var result = Context.Users.ToList();
            return result;
        }

        [HttpGet("{username}")]
        public async Task<User> GetCurrentUserAsync(string username)
        {
            try
            {
                return await Context.Users.FirstOrDefaultAsync(u => u.Username == username);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("getusermedia/{user}")]
        public async Task<List<Media>> GetCurrentUsersMediaAsync(string user)
        {
            try
            {
                return await Context.Media.Where(u => u.User.Username == user).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
