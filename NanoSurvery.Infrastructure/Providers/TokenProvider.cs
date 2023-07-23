using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NanoSurvery.Domain.Entities;
using NanoSurvery.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Infrastructure.Providers
{
	public class TokenProvider
	{
		private readonly IConfiguration _configuration;

		public TokenProvider(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string CreateToken(User user)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, user.Username!),
				new Claim("Id", user.Id.ToString())
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				_configuration.GetSection("TokenSource:Token").Value!));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.UtcNow.AddDays(1),
				signingCredentials: creds);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}

		public RefreshToken CreateRefreshToken()
		{
			var token = new RefreshToken();

			return token;
		}

	}
}
