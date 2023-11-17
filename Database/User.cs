namespace ITClassProject.Database;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
	
	public string Show() {
		return Id.ToString() + " " + Name;
	}
}

