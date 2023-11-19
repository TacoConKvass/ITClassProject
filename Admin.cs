namespace ITClassProject;

public sealed class Admin
{
	private Admin() {
		isAdmin = false;
	}
	public bool isAdmin = false;
	private static Admin Instance;
	private const string AdminPassword = "Passin123";

	public static Admin GetInstance() { 
		if (Instance == null) {
			Instance = new Admin();
		}
		return Instance;
	}
	
	public static bool CheckPassword(string password) {
		return password == AdminPassword;
	}
}
