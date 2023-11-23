using MySqlConnector;
using System.Reflection.PortableExecutable;

namespace ITClassProject.Database;

public class UserDbContext
{
	public UserDbContext() {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand("""
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

	public List<User> GetAllRecords() {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM users;", conn);
			var reader = mySqlCommand.ExecuteReader();
			List<User> users = new List<User>();
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

	public void AddRecord(string Name, string Password) {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand($"INSERT INTO users (`name`, `password`, `dateOfJoining`, `photoUrl`, `admin`) VALUES ('{Name}', '{Password}', NOW(), '', 0);", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	public void RemoveRecord(string Username) {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand($"DELETE FROM users WHERE name='{Username}';", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	public User FindRecord(string Username) {
		User user = new User();

		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand($"SELECT * FROM users WHERE name='{Username}'", conn);
			var reader = mySqlCommand.ExecuteReader();
			while (reader.Read()) {
				user.Username = reader.GetString("name");
				user.Password = reader.GetString("password");
				user.JoinDate = reader.GetDateOnly("dateOfJoining");
				user.PhotoUrl = reader.GetString("photoUrl");
				user.IsAdmin  = reader.GetInt32("admin");
			}
		}
		return user;
	}

	public int FindAppeareanceCount(string Username) {
		int result = 0;
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand("SELECT COUNT(*) AS num FROM users WHERE name=@Username", conn);
			mySqlCommand.Parameters.AddWithValue("name", Username);

			var reader = mySqlCommand.ExecuteReader();
			while (reader.Read()) {
				result = reader.GetInt32("num");
			}
		}

		return result;
	}
}
