namespace OrderManagement.Api.SystemExtensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddResultPattern();
            services.AddOpenApi();
            services.AddSwaggerGen();
            services.AddJwt(configuration);
            services.AddDb(configuration);
            services.AddBehavior();
            services.AddMediatR();
            //Accessor
            services.AddHttpContextAccessor();
            services.AddRepositories();
            return services;
        }
    }
}
