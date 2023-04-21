using MediaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace MediaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly MultiMediaAppContext context;

        public CommentController(MultiMediaAppContext context)
        {
            this.context = context;
        }

        [HttpPost("v2/submitcommit")]
        public async Task SubmitComment(Comment comment) 
        {
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();   
        }

    }
}
