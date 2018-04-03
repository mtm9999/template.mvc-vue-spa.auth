using jeffb.VueSpaAuth.Services.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace jeffb.VueSpaAuth.Controllers {
	public class HomeController : Controller {
		private readonly AppSettings _config;

		public HomeController(IOptions<AppSettings> config) {
			_config = config.Value;
		}

		public IActionResult Index() {
			ViewData["version"] = _config.AppBuildVers;
			return View();
		}
	}
}
