using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITClassProject;

namespace ITClassProject.Pages
{
    public class AdminLoginModel : PageModel
    {
		public LoggedInUser userInstance = LoggedInUser.GetInstance();

		public void OnGet() {
        
		}

		public void OnPost() {
			Console.WriteLine("Post");
			string username = Request.Form["username"].ToString();
			string password = Request.Form["password"].ToString();
			if (password is null) {
				Console.WriteLine("Pass is null");
				return;
			}

			
			Response.Redirect("/admin");
		}
	}
}
