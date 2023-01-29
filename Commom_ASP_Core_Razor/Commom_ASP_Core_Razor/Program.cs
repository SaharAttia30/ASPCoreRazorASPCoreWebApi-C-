var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
// builder.Services.AddRazorPages(options => options.RootDirectory = "/Pages");

var app = builder.Build();

app.MapRazorPages();

app.Run();