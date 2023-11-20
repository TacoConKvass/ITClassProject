namespace ITClassProject;

public sealed class LoggedInUser
{
	private LoggedInUser() {
		isAdmin = false;
		username = "Guest";
		dateOfBirth = DateOnly.FromDateTime(DateTime.Now);
		dateOfJoining = DateOnly.FromDateTime(DateTime.Now);
	}

	public bool isAdmin;
	public string username;
	public DateOnly dateOfBirth;
	public DateOnly dateOfJoining;
	private static LoggedInUser _instance;

	public static LoggedInUser GetInstance() {
		if (_instance is null) {
			_instance = new LoggedInUser();
		}
		return _instance;
	}
}
