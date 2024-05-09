using BlogServer.CrossCutting.Logger;
using Microsoft.AspNetCore.Mvc;

namespace BlogServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly ILog _log;

        public BlogController(ILog log)
        {
            _log = log;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _log.DebugLog("Test log get");
            return Ok("Hello from BlogController");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _log.DebugLog("Test log get with id");
            return Ok($"Hello from BlogController with id {id}");
        }

        [HttpPost]
        public IActionResult Post()
        {
            _log.DebugLog("Test log post");
            return Ok("Hello from BlogController");
        }
    }
}
