using ITClassProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITClassProject.Pages
{
    public class AdminModel : PageModel
    {
		UserDbContext context = new UserDbContext();
		public void OnGet() {
        }

		public void OnPost() {
			string userName = Request.Form["uName"].ToString();
			if (userName == "") {
				Console.WriteLine("Empty form");
				return;
			}
			context.AddRecord(userName);
		}
	}
}
