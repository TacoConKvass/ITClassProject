using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITClassProject.Pages.Shared
{
    public class _LayoutModel : PageModel
    {
		public bool admin = false;
        public void OnGet() {
        }
    }
}
