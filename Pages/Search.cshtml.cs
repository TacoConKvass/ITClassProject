using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITClassProject.Pages.Shared;
using ITClassProject.Database.Models;

namespace ITClassProject.Pages
{
    public class SearchModel : _PageModel
    {
		List<Quote> searchedQuotes = new List<Quote>();
		public void OnGet() {

		}
    }
}
