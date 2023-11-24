using MySqlConnector;

namespace ITClassProject.Database.Models;

public class Quote
{
	public int Id { get; set; }
	public string? Author { get; set; }
	public string? Content { get; set; }
	public string? Source { get; set; }
	public MySqlDateTime PostDate { get; set; }
}