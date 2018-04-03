using System;
using jeffb.VueSpaAuth.Models.Security;
using jeffb.VueSpaAuth.Services.Config;
using jeffb.VueSpaAuth.Services.Config.Models;
using jeffb.VueSpaAuth.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace jeffb.VueSpaAuth.Controllers.api {
	[Produces("application/json")]
	[Route("api/Auth")]
	public class AuthController : Controller {
		private readonly ILogger _log;
		private readonly SecuritySettings _config;
		private readonly IUserVerify _signInMgr;

		public AuthController(ILogger<AuthController> log, IOptions<AppSettings> config, IUserVerify signInMgr) {
			_log = log;
			_config = config.Value.Security;
			_signInMgr = signInMgr;
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public IActionResult RequestToken([FromBody] RequestTokenApiModel model) {
			try {
				if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password)) throw new ArgumentException("Missing username or password");
				var result = _signInMgr.VerifyUser(model.Username, model.Password);
				if (!result) {
					_log.LogDebug("User '{0}' login unsuccessful", model.Username);
					return Unauthorized();
				}
				var token = _config.Api.GenerateToken(model.Username, "default");
				var retval = new CurrentUserModel {
					Username = model.Username,
					Token = token
				};
				_log.LogInformation("User '{0}' successfully logged in", model.Username);
				return Accepted(retval);
			} catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			} catch (Exception ex) {
				_log.LogError(ex, ex.Message);
				return StatusCode(500, ex.Message);
			}
		}

		[Authorize]
		[HttpGet("curruser")]
		public IActionResult VerifyToken() {
			return Ok(new CurrentUserModel { Username = Request.HttpContext.User.Identity.Name });
		}
	}
}
