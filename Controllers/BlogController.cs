using Microsoft.AspNetCore.Mvc;

namespace BlogServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from BlogController");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Hello from BlogController with id {id}");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Hello from BlogController");
        }
    }
}
