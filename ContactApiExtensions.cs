public static class ContactApiExtensions 
{

    public static IServiceCollection UseContactsApi(
        this IServiceCollection services
    )
    {

        services.AddTransient<ContactRepository>();

        return services;

    }

    public static WebApplication MapContactsApi(
        this WebApplication app
    )
    {

        app.MapGet("/contacts", (ContactRepository repository) => {

            return Results.Ok(repository.Get());

        });

        app.MapGet("/contacts/{id:int}", (
            int id,
            ContactRepository repository) => {

                Contact? value = repository.GetById(id);
                if (value == null) {
                    return Results.NotFound();
                }
                return Results.Ok(value);

        });

        return app;

    }

}
