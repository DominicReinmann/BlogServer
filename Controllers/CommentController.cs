using Microsoft.AspNetCore.Mvc;

namespace BlogServer.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CommentController : Controller
    {

        [HttpPost("comment")]
        public IActionResult PostComment()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
