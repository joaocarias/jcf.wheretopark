using Jcf.WhereToPark.Api.Applications.User.Services.IServices;
using Jcf.WhereToPark.Api.Core.Controllers;
using Jcf.WhereToPark.Api.Core.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.WhereToPark.Api.Applications.User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : AppControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = new APIResponse();
            try
            {
                var user = await _userService.GetAsync(id);
                if (user is null)
                {
                    response.IsNotFound();
                    return NotFound(response);
                }

                response.IsOk(user.ToDTO());
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new APIResponse();
            try
            {
                var users = await _userService.GetAllAsync();
                if (users is null)
                {
                    response.IsNotFound();
                    return NotFound(response);
                }

                response.IsOk(users.Select(x => x.ToDTO()));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        // post

        // put

        // delete


    }
}
