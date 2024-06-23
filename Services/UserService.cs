using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Net;
using UsersAPI.Data.Dtos;
using UsersAPI.Models;

namespace UsersAPI.Services
{
	public class UserService
	{
		private IMapper _mapper;
		private UserManager<User> _userManager;
		private SignInManager<User> _signInManager;
		private TokenService _tokenService;

		public UserService(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, TokenService tokenService)
		{
			_userManager = userManager;
			_mapper = mapper;
			_signInManager = signInManager;
			_tokenService = tokenService;
		}

		public async Task Register(UserRegistrerDto dto)
		{
			User user = _mapper.Map<User>(dto);

			IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

			if (!result.Succeeded)
				throw new Exception("User registration failed. Please check your information and try again. If the problem persists, contact support for assistance.");
		}

		public async Task<string> Login(UserLoginDto dto)
		{
			var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

			if (!result.Succeeded)
				throw new Exception("Login failed.Please check your credentials and try again.If the problem persists, contact support for assistance.");

			var user = _signInManager
				.UserManager
				.Users
				.FirstOrDefault(u => u.NormalizedUserName == dto.Username.ToUpper());

			var token = _tokenService.GenerateToken(user);

			return token;
		}
	}
}
