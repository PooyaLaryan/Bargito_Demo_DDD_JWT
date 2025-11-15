using Microsoft.EntityFrameworkCore;
using Ordermanagement.Infrastructure.Persistence;

namespace OrderManagement.Api.SystemExtensions
{
    public static class DbExtension
    {
        public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration) 
        {
            //Db
            services.AddDbContext<WriteDbContext>(option => option.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ReadDbContext>(option => option.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
