using Commerce.Application.Interfaces.Services;
using Commerce.Application.Transfers.Requests;
using Commerce.Application.Transfers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        public IIdentityService IdentityService { get; set; }
        public AuthenticationController(IIdentityService identityService)
        {
            IdentityService = identityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequest userRegisterRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await IdentityService.RegisterUser(userRegisterRequest);

            if (result.Sucess)
                return Ok(result);
            else if (result.Errors.Count() > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userRegisterRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await IdentityService.Login(userRegisterRequest);

            if (result.Sucess)
                return Ok(result);
            else if (result.Errors.Count() > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
