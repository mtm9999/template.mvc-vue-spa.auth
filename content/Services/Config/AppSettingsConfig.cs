using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jeffb.VueSpaAuth.Services.Config {
	public static class AppSettingsConfig {
		public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration config) {
			services.Configure<AppSettings>(config.GetSection("AppSettings"));
			services.Configure<AppSettings>(
				o => {
					var dll = Assembly.GetExecutingAssembly();
					var dllInfo = FileVersionInfo.GetVersionInfo(dll.Location);
					o.AppBuildVers = dllInfo.FileVersion;
				}
			);
		}
	}
}
