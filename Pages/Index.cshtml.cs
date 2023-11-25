using Microsoft.AspNetCore.Mvc;
using ITClassProject.Pages.Shared;
using ITClassProject.Database;
using ITClassProject.Database.Models;

namespace ITClassProject.Pages
{
    public class IndexModel : _PageModel
    {
		QuoteDbContext quoteDb = Database.Database.GetQuoteDbContext();
		public void OnPost() {
			string source = Request.Form["source"].ToString();
			string quote = Request.Form["quote"].ToString();

			Quote submittedQuote = new Quote();
			submittedQuote.Author = TempData.Peek("username").ToString();
			submittedQuote.Source = source;
			submittedQuote.Content = quote;

			quoteDb.AddQuote(submittedQuote);
		}
    }
}
