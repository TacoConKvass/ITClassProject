using Microsoft.AspNetCore.Mvc;
using ITClassProject.Database.Models;

namespace ITClassProject.Controllers.Api;

[Route("api/quote")]
[ApiController]
public class QuoteController : ControllerBase
{
	QuoteDbContext quoteDb = ITClassProject.Database.Database.GetQuoteDbContext();

	[HttpDelete]
	public StatusCodeResult DeleteQuote([FromQuery(Name = "id")] int id) {
		quoteDb.RemoveQuote(id);
		return StatusCode(200);
	}
}