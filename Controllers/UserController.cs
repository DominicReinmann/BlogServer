using BlogServer.Authentication;
using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Workflows.LoginWorkflows;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BlogServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly ILog _log;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly ILoginWorkflow _loginWorkflow;

        public UserController(ILog log, IJwtTokenGenerator generator, ILoginWorkflow loginWorkflow)
        {
            _log = log;
            _tokenGenerator = generator;
            _loginWorkflow = loginWorkflow;
        }

        [HttpGet]
        public IActionResult User(string username, string password)
        {
            try
            {
                if (_loginWorkflow.RunLoginUser(password, username))
                {
                    var user = _loginWorkflow.GetUser(username);
                    if (string.IsNullOrEmpty(user.Username))
                    {
                        var token = _tokenGenerator.GenerateToken(user.Username, user.Role);
                        return Ok(token);
                    }
                    return BadRequest("Error getting User");
                }
                else
                {
                    return StatusCode(401);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorLog(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult User([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            try
            {
                _loginWorkflow.RunRegisterUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.ErrorLog(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
