using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jeffb.VueSpaAuth.Controllers.api {
	[Produces("application/json")]
	[Route("api/Test")]
	[Authorize]
	public class TestController : Controller {
		[HttpGet]
		public IActionResult Default() {
			return Ok("Hello World");
		}
	}
}
