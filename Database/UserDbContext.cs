using MySqlConnector;
using ITClassProject;
using System.Xml.Linq;

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
				  `dateOfBirth` DATE,
				  `dateOfJoining` DATE,
				  `
				  PRIMARY KEY (`name`)
				);
			""", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	public List<User> GetAllRecords() {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM userDb;", conn);
			var reader = mySqlCommand.ExecuteReader();
			List<User> users = new List<User>();
			while (reader.Read()) {
				var result = new User();
				result.Id = reader.GetInt32("id");
				result.Name = reader.GetString("name");
				users.Add(result);
			}

			return users;
		}
	}

	public void AddRecord(string Name) {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand($"INSERT INTO userDb (`name`) VALUES ('{Name}');", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	public void RemoveRecord(int Id) {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand($"DELETE FROM userDb WHERE id={Id};", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}
}
