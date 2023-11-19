using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITClassProject;

namespace ITClassProject.Pages
{
    public class AdminLoginModel : PageModel
    {
		public Admin adminInstance = Admin.GetInstance();
		public void OnGet() {
        }

		public void OnPost() {
			Console.WriteLine("Post");
			string password = Request.Form["password"].ToString();
			if (password is null) {
				Console.WriteLine("Pass is null");
				return;
			}

			if (!Admin.CheckPassword(password)) {
				Console.WriteLine("Wrong password");
				return;
			}

			adminInstance.isAdmin = true;
			RedirectToPage("/admin");
		}
	}
}
