using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Workflows.TagWorkflows;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TagController : Controller
    {
        private readonly ILog _log;
        private readonly ITagWorkflow _workflow;

        public TagController(ILog log, ITagWorkflow workflow)
        {
            _log = log;
            _workflow = workflow;
        }

        [HttpGet("")]
        public IActionResult GetTags()
        {
            try
            {
                var result = _workflow.RunGetTags();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error getting Tag {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("")]
        [Authorize(JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, User")]
        public IActionResult PostTags([FromBody] Tag tags)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error saving Tag {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
