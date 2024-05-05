using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILog _log;

        public UserController(ILog log)
        {
            _log = log;
        }

        [HttpGet]
        public IActionResult User(string username, string password)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult User(User user)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
