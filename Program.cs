var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ContactRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/contacts", (ContactRepository repository) => {

		return Results.Ok(repository.Get());

});

app.Run();