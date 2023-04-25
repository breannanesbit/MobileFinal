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

        [HttpPost, Route("v2/submitcomment"), HttpHeader("version", "2.0")]
        public async Task SubmitComment(Comment comment) 
        {
            context.Comments.Add(comment);

            await context.SaveChangesAsync();   
        }

        [HttpGet("v1/allcomments")]
        public List<Comment> allComments()
        {
            return context.Comments.ToList();
        }

        [HttpGet("v1/allcomments/{id}")]
        public List<Comment> allCommentsForMediaElement(int id)
        {
            return context.Comments.Where(m => m.MediaId == id).ToList();
        }


    }
}
