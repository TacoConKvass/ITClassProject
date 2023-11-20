namespace ITClassProject.Database;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
	public bool IsAdmin { get; set; }
	
	public string Show() {
		return Id.ToString() + " " + Name;
	}
}

