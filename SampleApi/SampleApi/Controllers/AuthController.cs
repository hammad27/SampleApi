using Microsoft.AspNetCore.Mvc;
using SampleApi.Models.Request;
using SampleApi.Services;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var response = await authService.RegisterUser(request);
            return Ok(response);
        }
    }
}
