using System;
using jeffb.VueSpaAuth.Services.Config.Models;
using jeffb.VueSpaAuth.Services.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace jeffb.VueSpaAuth.Services.Config {
	public static class SecuritySettingsConfig {
		public static void ConfigureSecurity(this IServiceCollection services, IConfiguration config) {
			var settings = config.GetSection("AppSettings").GetSection("Security").Get<SecuritySettings>();
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(
					o => {
						o.RequireHttpsMetadata = settings.RequireSsl;
						o.SaveToken = false;
						o.TokenValidationParameters = new TokenValidationParameters {
							ValidIssuer = settings.Api.Issuer,
							ValidateAudience = false,
							IssuerSigningKey = settings.Api.GetSigningKey(),
							RequireExpirationTime = true,
							RequireSignedTokens = true,
							ValidateLifetime = true,
							ClockSkew = TimeSpan.Zero
						};
					});

			services.AddScoped<IUserVerify, UserVerifyImpl>();
		}
	}
}
