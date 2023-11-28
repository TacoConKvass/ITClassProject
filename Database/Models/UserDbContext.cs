using MySqlConnector;

namespace ITClassProject.Database.Models;

public class UserDbContext
{
	public UserDbContext() {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("""
				CREATE TABLE IF NOT EXISTS `users` (
				  `name` VARCHAR(20),
				  `password` VARCHAR(255),
				  `dateOfJoining` DATE,
				  `photoUrl` VARCHAR(255),
				  `admin` BIT(1),
				  PRIMARY KEY (`name`)
				);
			""", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	/// <summary>
	/// Returns all users in a list
	/// </summary>
	/// <returns>List<User> - All users in the database/returns>
	public List<User> GetAllRecords() {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("SELECT * FROM users;", conn);
			var reader = mySqlCommand.ExecuteReader();
			var users = new List<User>();
			while (reader.Read()) {
				var result = new User();
				result.Username = reader.GetString("name");
				result.Password = reader.GetString("password");
				result.JoinDate = reader.GetDateOnly("dateOfJoining");
				result.PhotoUrl = reader.GetString("photoUrl");
				result.IsAdmin = reader.GetInt32("admin");
				users.Add(result);
			}

			return users;
		}
	}

	/// <summary>
	/// Adds a user to the database
	/// </summary>
	/// <param name="Name">Username to add</param>
	/// <param name="Password">Password to add</param>
	public void AddRecord(string Name, string Password) {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("""
				INSERT INTO users (`name`, `password`, `dateOfJoining`, `photoUrl`, `admin`)
				VALUES (@Name, @Password, NOW(), '', 0);
				""", conn);
			mySqlCommand.Parameters.AddWithValue("name", Name);
			mySqlCommand.Parameters.AddWithValue("password", Password);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	/// <summary>
	/// Removes given user from the database
	/// </summary>
	/// <param name="Username">Username of the user you want to delete</param>
	public void RemoveRecord(string Username) {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand($"DELETE FROM users WHERE `name`=@Name;", conn);
			mySqlCommand.Parameters.AddWithValue("name", Username);

			mySqlCommand.ExecuteNonQuery();
		}
	}

	/// <summary>
	/// Finds the dtabase record with given username
	/// </summary>
	/// <param name="Username">User you want to find</param>
	/// <returns>User - Found user. If user is not found it's values are null</returns>
	public User FindRecord(string Username) {
		var user = new User();

		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("SELECT * FROM users WHERE `name`=@Name", conn);
			mySqlCommand.Parameters.AddWithValue("name", Username);

			var reader = mySqlCommand.ExecuteReader();
			while (reader.Read()) {
				user.Username = reader.GetString("name");
				user.Password = reader.GetString("password");
				user.JoinDate = reader.GetDateOnly("dateOfJoining");
				user.PhotoUrl = reader.GetString("photoUrl");
				user.IsAdmin = reader.GetInt32("admin");
			}
		}
		return user;
	}

	/// <summary>
	/// Count how many times this username appears in the database
	/// </summary>
	/// <param name="Username">Username</param>
	/// <returns>int - How many times the username appears in the database</returns>
	public int FindAppeareanceCount(string Username) {
		var result = 0;
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand($"SELECT COUNT(*) AS num FROM users WHERE `name`=@Name", conn);
			mySqlCommand.Parameters.AddWithValue("name", Username);

			result = int.Parse(mySqlCommand.ExecuteScalar().ToString());
		}

		return result;
	}
}
