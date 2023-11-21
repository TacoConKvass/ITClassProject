using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;

namespace ITClassProject.Pages.Shared
{
    public class _PageModel : PageModel
    {
		public bool admin = false;
		public string currentUsername = "Guest";

		public void OnGet() {
			if (TempData.Peek("username") is null) {
				TempData["username"] = "Guest";
			}
			else {
				currentUsername = TempData.Peek("username").ToString();
			}

			if (TempData.Peek("isAdmin") is null) {
				TempData["isAdmin"] = 0;
			}
			else {
				admin = (int)TempData.Peek("isAdmin") == 1;
			}
		}
    }
}
