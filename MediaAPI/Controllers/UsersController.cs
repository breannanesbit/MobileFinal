﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
