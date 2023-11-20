namespace ITClassProject;

public sealed class LoggedInUser
{
	private LoggedInUser() {
		isAdmin = false;
		username = "Guest";
	}

	public bool isAdmin;
	public string username;
	private static LoggedInUser Instance;

	public static LoggedInUser GetInstance() {
		if (Instance is null) {
			Instance = new LoggedInUser();
		}
		return Instance;
	}
}
