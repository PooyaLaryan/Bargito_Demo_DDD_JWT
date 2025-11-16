using OrderManagement.Api.SystemExtensions;
using OrderManagement.Application.Users;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddServices(builder.Configuration);

        var app = builder.Build();

        app.UseServices();

        using (var scope = app.Services.CreateScope())
        {
            var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
            seeder.SeedAsync().GetAwaiter().GetResult();
        }

        app.Run();
    }
}