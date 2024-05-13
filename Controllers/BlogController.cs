using BlogServer.CrossCutting.Logger;
using BlogServer.Logic.Workflows.PostWorkflows;
using Microsoft.AspNetCore.Mvc;

namespace BlogServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly ILog _log;
        private readonly IPostWorkflow _workflow;

        public BlogController(ILog log, IPostWorkflow workflow)
        {
            _log = log;
            _workflow = workflow;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _workflow.RunGetPost(id);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error fetching Post{id}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult Edit(int id)
        {
            try
            {
                _workflow.RunEditPost(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error editing post {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _workflow.RunDeletePost(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error deleting post {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(string post)
        {
            try
            {
                _workflow.RunSavePost(post);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error Saving Post {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
