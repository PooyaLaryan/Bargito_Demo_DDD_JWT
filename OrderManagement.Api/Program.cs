using OrderManagement.Api.SystemExtensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAllServices(builder.Configuration);

        var app = builder.Build();

        app.UseServices();

        app.Run();
    }
}