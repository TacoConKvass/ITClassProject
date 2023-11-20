using ITClassProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITClassProject.Pages
{
    public class AdminModel : PageModel
    {
		public enum Actions {
			Delete,
			Show
		}

		UserDbContext context = new UserDbContext();
		public void OnGet() {
        }

		public void OnPost() {
		}
	}
}
