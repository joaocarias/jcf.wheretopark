using Jcf.WhereToPark.Api.Applications.Authentication.Models.DTOs;
using Jcf.WhereToPark.Api.Applications.User.Controllers;
using Jcf.WhereToPark.Api.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.WhereToPark.Api.Applications.Authentication.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : AppControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public AuthenticationController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                if (!loginDTO.IsValidate())
                {

                }

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }


    }
}
