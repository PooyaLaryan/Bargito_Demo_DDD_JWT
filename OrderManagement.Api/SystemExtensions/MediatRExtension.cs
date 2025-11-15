using OrderManagement.Application.Users.Command;
using OrderManagement.Application.Users.Query;

namespace OrderManagement.Api.SystemExtensions
{
    public static class MediatRExtension
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserQueryHandler).Assembly));

            return services;
        }
    }
}
