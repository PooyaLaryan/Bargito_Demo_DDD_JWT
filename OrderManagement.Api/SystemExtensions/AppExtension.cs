using OrderManagement.Api.ApiInfrastructures;
using OrderManagement.Application.Users;

namespace OrderManagement.Api.SystemExtensions
{
    public static class AppExtension
    {
        public static WebApplication UseServices(this WebApplication app) 
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ResultsExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();


            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
                seeder.SeedAsync().GetAwaiter().GetResult();
            }

            return app;
        }
    }
}
