namespace ITClassProject;

public static class Config
{
	public const string ConnectionString = "Server=127.0.0.1;Port=3306;Uid=root;Database=test";
	private const string AdminPass = "Passin123";
	public const bool Admin = false;

	public static bool CheckPassword(string Pass) {
		return Pass == AdminPass;
	}
}
