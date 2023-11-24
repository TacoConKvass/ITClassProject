using ITClassProject.Database.Models;
using ITClassProject.Pages.Shared;

namespace ITClassProject.Pages
{
	public class SignUpModel : _PageModel
    {
		UserDbContext userDb = Database.Database.GetUserDbContext();

		public bool usernameNull = false;
		public bool passwordNull = false;
		public bool rpasswordNull = false;
		public bool nonuniqueName = false;
		public bool usernameTooLong = false;
		public bool passwordWrongLen = false;
		public bool noSpecialChars = false;
		public bool noNnums = false;
		public bool notMatching = false;

		public void OnPost() {
			usernameNull = false;
			passwordNull = false;
			rpasswordNull = false;
			nonuniqueName = false;
			usernameTooLong = false;
			passwordWrongLen = false;
			noSpecialChars = false;
			noNnums = false;
			notMatching = false;

			string username  = Request.Form["username"].ToString();
			string password  = Request.Form["password"].ToString();
			string rpassword = Request.Form["rpassword"].ToString();

			if (string.IsNullOrEmpty(username)) {
				Console.WriteLine("Username is null or empty");
				usernameNull = true;
				return;
			}

			if (string.IsNullOrEmpty(password)) {
				Console.WriteLine("Password is null or empty");
				passwordNull = true;
				return;
			}

			if (string.IsNullOrEmpty(rpassword)) {
				Console.WriteLine("Rpassword is null or empty");
				rpasswordNull = true;
				return;
			}


			if (username.Length >= 20) {
				Console.WriteLine("Username too long, should be 19 characters or less");
				usernameTooLong = true;
				return;
			}

			if (username == "Guest" || userDb.FindAppeareanceCount(username) != 0) {
				Console.WriteLine("Username can't be 'Guest'");
				nonuniqueName = true;
				return;
			}

			if (password.Length >= 255 || password.Length < 8) {
				Console.WriteLine("Password too long or too short");
				passwordWrongLen = true;
				return;
			}

			bool containsSpecialChar = false;
			List<char> specialChars = new List<char>() { '#', '$', '^', '&', '*', '+', '=', '-', '_' };
			foreach (char c in specialChars) {
				if (password.Contains(c)) {
					containsSpecialChar = true;
					break;
				}
			}

			if (!containsSpecialChar) {
				Console.WriteLine("Password needs to contain at least one of these: #, $, ^, &, *, +, =, -, _");
				noSpecialChars = true;
				return;
			}

			bool containsNumber = false;
			List<char> nums = new List<char>() {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
			foreach (char num in nums) {
				if (password.Contains(num)) {
					containsNumber = true;
					break;
				}
			}

			if (!containsNumber) {
				Console.WriteLine("Password needs to contain at least one number");
				noNnums = true;
				return;
			}

			if (!rpassword.Equals(password)) {
				Console.WriteLine("Passwords dont match");
				notMatching = true;
				return;
			}

			userDb.AddRecord(username, password);
			TempData["username"] = username;
			TempData["isAdmin"] = 0;
			Response.Redirect("/");
		}
	}
}
