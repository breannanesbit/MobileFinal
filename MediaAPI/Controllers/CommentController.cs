using MediaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("v2/submitcomment")]
        public async Task SubmitComment(Comment comment) 
        {
            context.Comments.Add(comment);

            await context.SaveChangesAsync();   
        }

        [HttpGet("allcomments")]
        public List<Comment> allComments()
        {
            return context.Comments.ToList();
        }

    }
}
