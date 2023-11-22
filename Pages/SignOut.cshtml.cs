using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITClassProject.Pages
{
    public class SignOutModel : PageModel
    {
        public void OnGet()
        {
			TempData["username"] = null;
			TempData["isAdmin"] = null;
			Response.Redirect("/");
        }
    }
}
