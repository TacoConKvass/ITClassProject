using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITClassProject.Pages.Shared;
using ITClassProject.Database.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ITClassProject.Pages
{
    public class SearchModel : _PageModel
    {
		public List<Quote> searchedQuotes = new List<Quote>();

		QuoteDbContext quoteDb = ITClassProject.Database.Database.GetQuoteDbContext();
		public void OnPost() {
			var search = Request.Form["q"].ToString();
			var searchType = Request.Form["searchType"].ToString();

			switch (searchType) {
				case "author":
					searchedQuotes = quoteDb.FindMadeBy(search);
					break;
				case "source":
					searchedQuotes = quoteDb.FindBySource(search);
					break;
				case "content":
					searchedQuotes = quoteDb.FindContaining(search);
					break;
			}
		}
	}
}
