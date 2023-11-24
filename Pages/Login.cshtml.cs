using ITClassProject.Pages.Shared;
using ITClassProject.Database.Models;

namespace ITClassProject.Pages
{
	public class AdminLoginModel : _PageModel
    {
		UserDbContext userDb = Database.Database.GetUserDbContext();
		public bool usernameNull = false;
		public bool passwordNull = false;
		public bool userNotFound = false;
		public void OnPost() {
			usernameNull = false;
			passwordNull = false;
			userNotFound = false;
			string username = Request.Form["username"].ToString();
			string password = Request.Form["password"].ToString();

			if (string.IsNullOrEmpty(username)) {
				Console.WriteLine("Username is null, empty or whitespace");
				usernameNull = true;
				return;
			}

			if (string.IsNullOrEmpty(password)) {
				Console.WriteLine("Pass is null, empty or whitespace");
				passwordNull = true;
				return;
			}

			User foundUser = userDb.FindRecord(username);
			if (foundUser.Username is null || !foundUser.Password.Equals(password)) {
				Console.WriteLine("No user with this username found");
				userNotFound = true;
				return;
			}

			TempData["username"] = foundUser.Username;
			TempData["isAdmin"] = foundUser.IsAdmin;
			Console.WriteLine(foundUser.Username + "\t" + foundUser.IsAdmin.ToString());


			if (foundUser.IsAdmin == 1) {
				Response.Redirect("/admin");
				return;
			}

			Response.Redirect("/");
		}
	}
}
