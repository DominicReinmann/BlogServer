using BlogServer.Authentication;
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
        private readonly IJwtTokenGenerator _tokenGenerator;

        public UserController(ILog log, IJwtTokenGenerator generator)
        {
            _log = log;
            _tokenGenerator = generator;
        }

        [HttpGet]
        public IActionResult User(string username, string password)
        {
            try
            {
                if(username == "dore" && password == "HalloDu123")
                {
                    return Ok(_tokenGenerator.GenerateToken());
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
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
