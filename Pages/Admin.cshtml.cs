using ITClassProject.Pages.Shared;
using ITClassProject.Database.Models;

namespace ITClassProject.Pages
{
	public class AdminModel : _PageModel
    {
		UserDbContext context = Database.Database.GetUserDbContext();

		public void OnPost() {
			var userForDeletion = Request.Form["usernameForDeletion"].ToString();
			context.RemoveRecord(userForDeletion);
			Response.Redirect("/admin");
		}
	}
}
