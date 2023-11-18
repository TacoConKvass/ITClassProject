using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITClassProject.Database;

namespace ITClassProject.Pages
{
    public class AboutModel : PageModel
    {
		UserDbContext context = new UserDbContext();
        public void OnGet() {
			context.GetAllRecords();
		}

		public void OnPost() {
			string userName = Request.Form["uName"].ToString();
			if (string.IsNullOrEmpty(userName)) {
				Console.WriteLine("Empty form");
				return;
			}
			context.AddRecord(userName);
		}
	}
}
