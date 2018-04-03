using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using jeffb.VueSpaAuth.Services.Config.Models;
using Microsoft.IdentityModel.Tokens;

namespace jeffb.VueSpaAuth.Services.Security {
	public static class ApiSecurityExtensions {
		public static string GenerateToken(this ApiSettings config, string username, string role) {
			var claims = new[] {
				new Claim(JwtRegisteredClaimNames.Sub, username),
				new Claim(ClaimTypes.NameIdentifier, username),
				new Claim(ClaimTypes.Name, username),
				new Claim(ClaimTypes.Role, role),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};
			var creds = new SigningCredentials(config.GetSigningKey(), SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				config.Issuer,
				claims: claims,
				expires: DateTime.Now.AddMinutes(config.ExpiryMins),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
