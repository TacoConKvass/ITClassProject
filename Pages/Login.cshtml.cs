using Microsoft.AspNetCore.Mvc.RazorPages;
using ITClassProject.Database;

namespace ITClassProject.Pages
{
    public class AdminLoginModel : PageModel
    {
		public LoggedInUser userInstance = LoggedInUser.GetInstance();

		public void OnGet() {
			UserDbContext userDb = new UserDbContext();
			User foundUser = userDb.FindRecord("Pronto");
		}

		public void OnPost() {
			string username = Request.Form["username"].ToString();
			string password = Request.Form["password"].ToString();
			if (string.IsNullOrEmpty(password)) {
				Console.WriteLine("Pass is null, empty or whitespace");
				return;
			}

			if (string.IsNullOrEmpty(username)) {
				Console.WriteLine("Username is null, empty or whitespace");
				return;
			}

			UserDbContext userDb = new UserDbContext();
			User foundUser = userDb.FindRecord(username);
			if (foundUser.Username is null) {
				Console.WriteLine("No user with this username found");
				return;
			}

			if (!foundUser.Password.Equals(password)) {
				Console.WriteLine("Wrong password");
				return;
			}

			var loggedInUser = LoggedInUser.GetInstance();
			loggedInUser.username = foundUser.Username;
			loggedInUser.isAdmin = foundUser.IsAdmin;

			if (loggedInUser.isAdmin) {
				Response.Redirect("/admin");
				return;
			}

			Response.Redirect("/");
		}
	}
}
