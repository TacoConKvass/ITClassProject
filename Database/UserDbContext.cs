using MySqlConnector;
using ITClassProject;

namespace ITClassProject.Database;

public class UserDbContext
{
	public UserDbContext() {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand("""
				CREATE TABLE IF NOT EXISTS `userDb` (
				  `id` INT NOT NULL AUTO_INCREMENT,
				  `name` VARCHAR(255),
				  PRIMARY KEY (`id`)
				);
			""", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	public void GetAllRecords() {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM userDb;", conn);
			var reader = mySqlCommand.ExecuteReader();

			while (reader.Read()) {
				var result = new User();
				result.Id = reader.GetInt32("id");
				result.Name = reader.GetString("name");
				Console.WriteLine($"UserID: {result.Id}		UserName: {result.Name}");
			}
		}
	}

	public void AddRecord(string Name) {
		using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			MySqlCommand mySqlCommand = new MySqlCommand($"INSERT INTO userDb (`name`) VALUES ('{Name}');", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}
}