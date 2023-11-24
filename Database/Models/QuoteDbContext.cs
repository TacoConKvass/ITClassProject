using MySqlConnector;
using System.Xml.Linq;

namespace ITClassProject.Database.Models;

public class QuoteDbContext
{
	public QuoteDbContext() {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("""
				CREATE TABLE IF NOT EXISTS `quotes`` (
				  `author` VARCHAR(20),
				  `content` VARCHAR(400),
				  `source` VARCHAR(100),
				  `postDate` DATE
				);
			""", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	public List<Quote> GetAllQuotes() {
		List<Quote> posts = new List<Quote>();

		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("SELECT * FROM `quotes`;", conn);
			var reader = mySqlCommand.ExecuteReader();
			while (reader.Read()) {
				Quote post = new Quote();
				post.Author = reader.GetString("author");
				post.Content = reader.GetString("content");
				post.Source = reader.GetString("source");
				post.PostDate = reader.GetMySqlDateTime("postDate");
				posts.Add(post);
			}

			return posts;
		}
	}

	public void AddQuote(Quote newQuote) {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("""
				INSERT INTO quotes (`author`, `content`, `source`, `postDate`)
				VALUES (@Author, @Content, @Source, NOW());
				""", conn);
			mySqlCommand.Parameters.AddWithValue("author", newQuote.Author);
			mySqlCommand.Parameters.AddWithValue("content", newQuote.Content);
			mySqlCommand.Parameters.AddWithValue("source", newQuote.Source);
			mySqlCommand.ExecuteNonQuery();
		}
	}
}