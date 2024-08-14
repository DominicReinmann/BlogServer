using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Workflows.CommentWorkflows;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CommentController : Controller
    {
        private readonly ILog _log;
        private readonly ICommentWorkflow _workflow;

        public CommentController(ILog log, ICommentWorkflow workflow)
        {
            _log = log;
            _workflow = workflow;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, User")]
        public IActionResult CreateComment([FromBody] Comments comment)
        {
            if (comment == null || string.IsNullOrEmpty(comment.Content))
            {
                return BadRequest("Invalid comment data.");
            }
            try
            {
                _workflow.RunPostComment(comment);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error creating comment: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, User")]
        public IActionResult UpdateComment(int id, [FromBody] Comments updatedComment)
        {
            if (updatedComment == null || id != updatedComment.Id)
            {
                return BadRequest("Invalid comment data or mismatched ID.");
            }
            try
            {
                _workflow.RunEditComment(updatedComment);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error editing comment {id}: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult DeleteComment(int id)
        {
            try
            {
                _workflow.RunDeleteComment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error deleting comment {id}: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
