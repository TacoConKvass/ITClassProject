namespace ITClassProject.Database.Models;

public class User
{
	public string? Username { get; set; }
	public string? Password { get; set; }
	public DateOnly JoinDate { get; set; }
	public string? PhotoUrl { get; set; }
	public int IsAdmin { get; set; }
}

