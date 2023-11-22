using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITClassProject.Pages.Shared
{
	public class _LayoutModel : _PageModel
	{
		public void OnPost() {
			var bonk = Request.Form["sign-out"];
			Console.WriteLine(bonk);
		}
	}
}
