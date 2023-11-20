using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITClassProject.Pages
{
    public class IndexModel : PageModel
    {
		public LoggedInUser userInstance = LoggedInUser.GetInstance();
		public void OnGet() {
        }
    }
}
