using Microsoft.AspNetCore.Mvc;
using Model.JWT;
using Service.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(ILogger<AuthController> logger, IUserService userService) : ControllerBase
    {
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel model)
        {
            try
            {
                return Ok(await userService.SignUp(model));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] LoginModel model)
        {
            try
            {
                return Ok(await userService.SignIn(model));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
