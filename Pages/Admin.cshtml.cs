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
			int userId = int.Parse(Request.Form["userId"].ToString());
			Console.WriteLine(userId);
			if (userId < 0) {
				Console.WriteLine("UserID below 0");
				return;
			}

			List<User> users = context.GetAllRecords();
			if (users.Count() == 0) {
				Console.WriteLine("No users");
				return;
			}

			context.RemoveRecord(userId);
			Console.WriteLine($"Deleted user with ID {userId}");
		}
	}
}
