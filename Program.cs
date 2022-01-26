var builder = WebApplication.CreateBuilder(args);

builder.Services.UseContactsApi();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapContactsApi();

app.Run();
