using MySqlConnector;

namespace ITClassProject.Database.Models;

public class QuoteDbContext
{
	public QuoteDbContext() {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("""
				CREATE TABLE IF NOT EXISTS `quotes` (
				  `id` INT AUTO_INCREMENT,
				  `author` VARCHAR(20),
				  `content` VARCHAR(400),
				  `source` VARCHAR(100),
				  `postDate` DATE,
				  PRIMARY KEY (`id`)
				) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;
			""", conn);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	/// <summary>
	/// Returns a list of all quotes in the database
	/// </summary>
	/// <returns>List<Quote> - All records</returns>
	public List<Quote> GetAllQuotes() {
		List<Quote> posts = new List<Quote>();

		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("SELECT * FROM `quotes`;", conn);
			var reader = mySqlCommand.ExecuteReader();
			while (reader.Read()) {
				Quote post = new Quote();
				post.Id = reader.GetInt32("id");
				post.Author = reader.GetString("author");
				post.Content = reader.GetString("content");
				post.Source = reader.GetString("source");
				post.PostDate = reader.GetMySqlDateTime("postDate");
				posts.Add(post);
			}

			return posts;
		}
	}

	/// <summary>
	/// Add a quote to the database
	/// </summary>
	/// <param name="newQuote">Quote object to add</param>
	public void AddQuote(Quote newQuote) {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("""
				INSERT INTO `quotes` (`author`, `content`, `source`, `postDate`)
				VALUES (@Author, @Content, @Source, NOW());
				""", conn);
			mySqlCommand.Parameters.AddWithValue("author", newQuote.Author);
			mySqlCommand.Parameters.AddWithValue("content", newQuote.Content);
			mySqlCommand.Parameters.AddWithValue("source", newQuote.Source);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	/// <summary>
	/// Remove quote from the database
	/// </summary>
	/// <param name="id">ID of the quote you want to delete</param>
	public void RemoveQuote(int id) {
		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand($"DELETE FROM `quotes` WHERE `id`=@Id;", conn);
			mySqlCommand.Parameters.AddWithValue("id", id);
			mySqlCommand.ExecuteNonQuery();
		}
	}

	/// <summary>
	/// Find all quotes fullfilling the requirement
	/// </summary>
	/// <param name="content">Text that the quote should start with</param>
	/// <returns>List<Quote> - List of all quotes starting with the given string</returns>
	public List<Quote> FindContaining(string content) {
		List<Quote> matchingQuotes = new List<Quote>();

		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("SELECT * FROM `quotes` WHERE `content` LIKE @Content", conn);
			mySqlCommand.Parameters.AddWithValue("content", content.ToString() + "%");

			var reader = mySqlCommand.ExecuteReader();
			while (reader.Read()) {
				Quote quote = new Quote();
				quote.Author = reader.GetString("author");
				quote.Content = reader.GetString("content");
				quote.Source = reader.GetString("source");
				quote.PostDate = reader.GetMySqlDateTime("postDate");
				quote.Id = reader.GetInt32("id");
				matchingQuotes.Add(quote);
			}
		}
		return matchingQuotes;
	}

	/// <summary>
	/// Find all quotes fullfilling the requirement
	/// </summary>
	/// <param name="author">String that the author username should start with</param>
	/// <returns>List<Quote> - List of all quotes which author's username starts with the given string</returns>
	public List<Quote> FindMadeBy(string author) {
		List<Quote> matchingQuotes = new List<Quote>();

		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("SELECT * FROM `quotes` WHERE `author` LIKE @Author;", conn);
			mySqlCommand.Parameters.AddWithValue("author", author.ToString() + "%");

			var reader = mySqlCommand.ExecuteReader();
			while (reader.Read()) {
				Quote quote = new Quote();
				quote.Author = reader.GetString("author");
				quote.Content = reader.GetString("content");
				quote.Source = reader.GetString("source");
				quote.PostDate = reader.GetMySqlDateTime("postDate");
				quote.Id = reader.GetInt32("id");
				matchingQuotes.Add(quote);
			}
		}

		return matchingQuotes;
	}

	/// <summary>
	/// Find all quotes fullfilling the requirement
	/// </summary>
	/// <param name="source">String that the source should start with</param>
	/// <returns>List<Quote> - List of all quotes which source starts with the given string</returns>
	public List<Quote> FindBySource(string source) {
		List<Quote> matchingQuotes = new List<Quote>();

		using (var conn = new MySqlConnection(Config.ConnectionString)) {
			conn.Open();
			var mySqlCommand = new MySqlCommand("SELECT * FROM `quotes` WHERE `source` LIKE @Source;", conn);
			mySqlCommand.Parameters.AddWithValue("source", source.ToString() + "%");

			var reader = mySqlCommand.ExecuteReader();
			while (reader.Read()) {
				Quote quote = new Quote();
				quote.Author = reader.GetString("author");
				quote.Content = reader.GetString("content");
				quote.Source = reader.GetString("source");
				quote.PostDate = reader.GetMySqlDateTime("postDate");
				quote.Id = reader.GetInt32("id");
				matchingQuotes.Add(quote);
			}
		}

		return matchingQuotes;
	}
}