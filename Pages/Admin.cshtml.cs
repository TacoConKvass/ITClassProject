using ITClassProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITClassProject.Pages.Shared;

namespace ITClassProject.Pages
{
    public class AdminModel : _PageModel
    {
		UserDbContext context = new UserDbContext();

		public void OnPost() {
			var userForDeletion = Request.Form["usernameForDeletion"].ToString();
			context.RemoveRecord(userForDeletion);
			Response.Redirect("/admin");
		}
	}
}
