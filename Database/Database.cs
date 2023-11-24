using ITClassProject.Database.Models;

namespace ITClassProject.Database;

public static class Database {
	private static UserDbContext? userDb;
	//private static QuoteDbContext? quoteDb;

	public static UserDbContext GetUserDbContext() {
		userDb ??= new UserDbContext(); //If userDb is null
		return userDb;
	}

	/*
	public static QuoteDbContext GetPostDbContext() {
		quoteDb ??= new QuoteDbContext();
		return quoteDb;
	}
	*/
}