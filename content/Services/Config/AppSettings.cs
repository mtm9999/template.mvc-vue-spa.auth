using jeffb.VueSpaAuth.Services.Config.Models;

namespace jeffb.VueSpaAuth.Services.Config {
	public class AppSettings {
		public string AppBuildVers { get; set; } = "1.0.0.0";

		public SecuritySettings Security { get; set; }
	}
}
