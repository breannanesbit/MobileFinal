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

        [HttpPost("v1/submitcomment")]
        public async Task SubmitComment(Comment comment) 
        {
            context.Comments.Add(comment);

            await context.SaveChangesAsync();   
        }

        /*[HttpGet, Route("v1/allcomments"), HttpHeader("version", "1.0")]*/
        [HttpGet("v1/allcomments")]
        public async Task<IActionResult> AllComments()
        {
            var comments = context.Comments.ToList();
            return Ok(comments);
        }

        //[HttpGet, Route("v2/allcomments/{id}"), HttpHeader("version", "2.0")]
        [HttpGet("v2/allcomments/{id}")]
        public async Task<IActionResult> allCommentsForMediaElement(int id)
        {
            var comments = context.Comments.Where(m => m.MediaId == id).ToList();
            return Ok(comments);
        }


    }
}
