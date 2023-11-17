using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using ITClassProject.Database;

namespace ITClassProject.Pages
{
    public class AboutModel : PageModel
    {
		UserDbContext context = new UserDbContext();
        public void OnGet() {
			context.AddRecord("Uno");
			context.GetAllRecords();
		}

		public void OnPost() {
			string userName = Request.Form["uName"].ToString();
			context.AddRecord(userName);
		}
	}
}
