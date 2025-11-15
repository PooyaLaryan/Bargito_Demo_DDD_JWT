using MediatR;
using Ordermanagement.Infrastructure.Services.Behaviors;

namespace OrderManagement.Api.SystemExtensions
{
    public static class BehaviorExtension
    {
        public static IServiceCollection AddBehavior(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

            return services;
        }
    }
}
