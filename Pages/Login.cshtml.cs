using ITClassProject.Pages.Shared;
using ITClassProject.Database;

namespace ITClassProject.Pages
{
    public class AdminLoginModel : _PageModel
    {
		UserDbContext userDb = new UserDbContext();
		public bool usernameNull = false;
		public bool passwordNull = false;
		public bool userNotFound = false;
		public bool passwordIncorrect = false;
		public void OnPost() {
			usernameNull = false;
			passwordNull = false;
			userNotFound = false;
			passwordIncorrect = false;
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

			UserDbContext userDb = new UserDbContext();
			User foundUser = userDb.FindRecord(username);
			if (foundUser.Username is null) {
				Console.WriteLine("No user with this username found");
				userNotFound = true;
				return;
			}

			if (!foundUser.Password.Equals(password)) {
				Console.WriteLine("Wrong password");
				passwordIncorrect = true;
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
