using Microsoft.AspNetCore.Mvc;
using ITClassProject.Pages.Shared;
using ITClassProject.Database;
using ITClassProject.Database.Models;
using System.Text.RegularExpressions;

namespace ITClassProject.Pages
{
    public class IndexModel : _PageModel
    {
		public List<string> Captcha = new List<string>() { "HAPK3", "3M56R", "D4TSH", "R84CH", "459CT", "TSMS9", "RBSKW", "W93BX" };
		public int random = 1;
		public Random Random = new Random();

		QuoteDbContext quoteDb = Database.Database.GetQuoteDbContext();

		public override void OnGet() {
			base.OnGet();
			random = Random.Next(1, 8);
		}

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
