using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITClassProject.Pages
{
    public class IndexModel : PageModel
    {
		public Admin adminInstance = Admin.GetInstance();
		public void OnGet() {
        }
    }
}
