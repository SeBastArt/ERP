using ERP.API.Filters;
using ERP.Domain.Requests.User;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ERP.API.V1.Controllers
{
    /// <summary>
    /// UserController
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/user")]
    [ApiVersion("1.0")]
    [JsonException]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Contructor UserController
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Claim claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);

            if (claim == null)
            {
                return Unauthorized();
            }
            return Ok(RespContainer.Ok(await _userService.GetUserAsync(new GetUserRequest { Email = claim.Value }), "user found"));
        }

        /// <summary>
        /// SignIn
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            return Ok(RespContainer.Ok(await _userService.SignInAsync(request), "authorized"));
        }

        /// <summary>
        /// SignUp
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            return CreatedAtAction(nameof(Get), new { }, await _userService.SignUpAsync(request));
        }
    }
}