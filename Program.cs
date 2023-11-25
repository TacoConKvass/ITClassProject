using ITClassProject;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(Config.ConnectionString));

builder.Services.AddSession(options => {
	options.IdleTimeout = TimeSpan.FromSeconds(10);
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapControllers();
app.MapRazorPages();

app.Run();