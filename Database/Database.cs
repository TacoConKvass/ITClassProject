using ITClassProject.Database.Models;

namespace ITClassProject.Database;

public static class Database {
	private static UserDbContext? userDb;
	private static QuoteDbContext? quoteDb;

	public static UserDbContext GetUserDbContext() {
		if (userDb is null) {
			userDb = new UserDbContext();
		}
		return userDb;
	}

	public static QuoteDbContext GetQuoteDbContext() {
		if (quoteDb is null) {
			quoteDb = new QuoteDbContext();
		}
		return quoteDb;
	}
	
}