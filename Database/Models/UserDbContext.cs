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

	public void RemoveRecord(string Username) {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand($"DELETE FROM users WHERE `name`=@Name;", conn);
			mySqlCommand.Parameters.AddWithValue("name", Username);

			mySqlCommand.ExecuteNonQuery();
		}
	}

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
				Console.WriteLine(user);
			}
		}
		return user;
	}

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
