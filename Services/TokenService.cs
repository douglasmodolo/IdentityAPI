
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersAPI.Models;

namespace UsersAPI.Services
{
	public class TokenService
	{
		public string GenerateToken(User user)
		{
			Claim[] claims = new Claim[]
			{
				new Claim("username", user.UserName),
				new Claim("id", user.Id)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ASDAS5665989855CC5V53"));

			var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken
				(
					expires: DateTime.Now.AddMinutes(10),
					claims: claims,
					signingCredentials: signingCredentials
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}