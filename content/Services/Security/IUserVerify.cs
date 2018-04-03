namespace jeffb.VueSpaAuth.Services.Security {
	public interface IUserVerify {
		bool VerifyUser(string username, string providedPassword);
	}
}
