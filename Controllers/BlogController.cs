using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Workflows.PostWorkflows;
using Microsoft.AspNetCore.Authorization;
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
                return Ok(result);
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error fetching Post{id}: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit([FromBody] Posts post)
        {
            try
            {
                _workflow.RunEditPost(post);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error editing post {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromBody] Posts post)
        {
            try
            {
                _workflow.RunDeletePost(post);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error deleting post {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult PostPost([FromBody] Posts post)
        {
            try
            {
                _workflow.RunSavePost(post);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error Saving Post {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
