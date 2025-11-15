using OrderManagement.Api.ApiInfrastructures;

namespace OrderManagement.Api.SystemExtensions
{
    public static class ResultPatternExtension
    {
        public static IServiceCollection AddResultPattern(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ResultsFilter>();
            });

            return services;
        }
    }
}
