using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dtos;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
	[ApiController]
	[Route("User")]
	public class UserController : ControllerBase
	{
		private UserService _userService;

		public UserController(UserService registrationService)
		{
			_userService = registrationService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> UserRegistrer([FromBody] UserRegistrerDto dto)
		{
			await _userService.Register(dto);
			return Ok("User registred!");
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto dto)
		{
			var token = await _userService.Login(dto);
			return Ok(token);
		}
	}
}
