namespace jeffb.VueSpaAuth.Services.Security {
	public class UserVerifyImpl : IUserVerify {
		#region Implementation of IUserVerify
		public bool VerifyUser(string username, string providedPassword) {
			return username.Equals("root") && providedPassword.Equals("password");
		}
		#endregion
	}
}
