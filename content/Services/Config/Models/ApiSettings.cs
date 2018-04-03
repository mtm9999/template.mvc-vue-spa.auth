using System;
using Microsoft.IdentityModel.Tokens;

namespace jeffb.VueSpaAuth.Services.Config.Models {
	public class ApiSettings {
		public string Issuer { get; set; }
		public string Key { get; set; }
		public int ExpiryMins { get; set; }
	}

	public static class ApiSettingsExtensions {
		public static SymmetricSecurityKey GetSigningKey(this ApiSettings config) {
			return new SymmetricSecurityKey(Convert.FromBase64String(config.Key));
		}
	}

}
