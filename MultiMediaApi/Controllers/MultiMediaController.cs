using Microsoft.AspNetCore.Mvc;

namespace MultiMediaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MultiMediaController : Controller
    {
      
        [HttpPut("uploadfile/{file}")]
        public async Task<string> UploadFile(IFormFile file)
        {

            return "quwgffiffhiokdbfhkdsf";
        }

    }
}
