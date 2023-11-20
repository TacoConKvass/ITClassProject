using ITClassProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITClassProject.Pages
{
    public class SignUpModel : PageModel
    {
		public UserDbContext dbContext = new UserDbContext();
        public void OnGet() {
        }

		public void OnPost() {
			string username  = Request.Form["username"].ToString();
			string password  = Request.Form["password"].ToString();
			string rpassword = Request.Form["rpassword"].ToString();

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(rpassword) ) {
				Console.WriteLine($"One of the parameters is either null, empty or a whitespace: {string.IsNullOrEmpty(username)}, {string.IsNullOrEmpty(password)}, {string.IsNullOrEmpty(rpassword)}");
				return;
			}

			if (username.Length >= 20) {
				Console.WriteLine("Username too long, should be 19 characters or less");
				return;
			}

			if (username == "Guest") {
				Console.WriteLine("Username can't be 'Guest'");
				return;
			}

			if (password.Length >= 255) {
				Console.WriteLine("Password too long");
				return;
			}

			if (password.Length < 8) {
				Console.WriteLine("Password too short");
				return;
			}

			bool containsSpecialChar = false;
			List<char> specialChars = new List<char>() { '@', '#', '$', '^', '&', '*', '+', '=', '-', '_' };
			foreach (char c in specialChars) {
				if (password.Contains(c)) {
					containsSpecialChar = true;
					break;
				}
			}

			if (!containsSpecialChar) {
				Console.WriteLine("Password needs to contain at least one of these: @, #, $, ^, &, *, +, =, -, _");
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
				return;
			}

			if (!rpassword.Equals(password)) {
				Console.WriteLine("Passwords dont match");
				return;
			}

			dbContext.AddRecord(username, password);
			LoggedInUser userInstance = LoggedInUser.GetInstance();
			userInstance.username = username;
			userInstance.isAdmin = false;
			Response.Redirect("/");
		}
	}
}
