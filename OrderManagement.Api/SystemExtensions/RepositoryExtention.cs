using OrderManagement.Application.Users;
using OrderManagement.Domain.Repositories.Security;
using OrderManagement.Domain.Repositories.Tickets.Command;
using OrderManagement.Domain.Repositories.Tickets.Query;
using OrderManagement.Domain.Repositories.Users.Command;
using OrderManagement.Domain.Repositories.Users.Query;
using OrderManagement.Domain.Services;
using Ordermanagement.Infrastructure.Repositories.Tickets.Command;
using Ordermanagement.Infrastructure.Repositories.Tickets.Query;
using Ordermanagement.Infrastructure.Repositories.Users.Command;
using Ordermanagement.Infrastructure.Repositories.Users.Query;
using Ordermanagement.Infrastructure.Services.Security;
using Ordermanagement.Infrastructure.Services;
using OrderManagement.Domain.Repositories.Permissions.Command;
using Ordermanagement.Infrastructure.Repositories.Permissions.Command;
using OrderManagement.Domain.Repositories.Permissions.Query;
using Ordermanagement.Infrastructure.Repositories.Permissions.Query;
using OrderManagement.Domain.Repositories.UserPermissions.Query;
using Ordermanagement.Infrastructure.Repositories.UserPermissions.Query;
using OrderManagement.Domain.Repositories.UserPermissions.Command;
using Ordermanagement.Infrastructure.Repositories.UserPermissions.Command;

namespace OrderManagement.Api.SystemExtensions
{
    public static class RepositoryExtention
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceDescriptors)
        {
            //Repo
            serviceDescriptors.AddScoped<DbSeeder>();
            serviceDescriptors.AddScoped<ICurrentUserService, CurrentUserService>();
            serviceDescriptors.AddScoped<IUserCommandRepository, UserCommandRepository>();
            serviceDescriptors.AddScoped<IUserQueryRepository, LoginQueryRepository>();
            serviceDescriptors.AddScoped<ITicketCommandRepository, TicketCommandRepository>();
            serviceDescriptors.AddScoped<ITicketQueryRepository, TicketQueryRepository>();
            serviceDescriptors.AddScoped<ITokenGenerator, JwtTokenGenerator>();
            serviceDescriptors.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceDescriptors.AddScoped<IPermissionCommandRepository, PermissionCommandRepository>();
            serviceDescriptors.AddScoped<IPermissionQueryRepository, PermissionQueryRepository>();
            serviceDescriptors.AddScoped<IUserPermissionCommandRepository, UserPermissionCommandRepository>();
            serviceDescriptors.AddScoped<IUserPermissionQueryRepository, UserPermissionQueryRepository>();

            return serviceDescriptors;
        }
    }
}
