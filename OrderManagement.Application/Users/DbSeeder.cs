using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.Permissions.Command;
using OrderManagement.Domain.Repositories.Permissions.Query;
using OrderManagement.Domain.Repositories.Users.Command;
using OrderManagement.Domain.Repositories.Users.Query;

namespace OrderManagement.Application.Users;

public class DbSeeder
{
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IPermissionCommandRepository _permissionCommandRepository;
    private readonly IPermissionQueryRepository _permissionQueryRepository;

    public DbSeeder(
        IUserCommandRepository userCommandRepository,
        IUserQueryRepository userQueryRepository,
        IPermissionCommandRepository permissionCommandRepository,
        IPermissionQueryRepository permissionQueryRepository)
    {
        _userCommandRepository = userCommandRepository;
        _userQueryRepository = userQueryRepository;
        _permissionCommandRepository = permissionCommandRepository;
        _permissionQueryRepository = permissionQueryRepository;
    }

    public async Task SeedAsync()
    {
        string hashed = BCrypt.Net.BCrypt.HashPassword("123");

        var permission = await _permissionQueryRepository.GetAsync();
        if (!permission.Any())
        {
            var permissions = new List<Permission>
            {
                new Permission { Name = "Tickets.Create" },
                new Permission { Name = "Tickets.View.My" },
                new Permission { Name = "Tickets.View.All" },
                new Permission { Name = "Tickets.Edit.My" },
                new Permission { Name = "Tickets.Edit.All" },
                new Permission { Name = "Reports.View" }
            };

            await _permissionCommandRepository.InsertBatch(permissions);
        }


        var users = await _userQueryRepository.GetAllUsersAsync(default);

        if (users.Any())
            return;

        var user1Id = await _userCommandRepository.RegisterAsync(new User
        (
            fullName: "Pooya Lariyan",
            email: "pooya.laryan@gmail.com",
            password: hashed,
            role: Domain.Enums.UserRole.Admin
        ), default);

        await _userCommandRepository.RegisterAsync(new User
        (
            fullName: "admin admin",
            email: "admin@bargito.ir",
            password: hashed,
            role: Domain.Enums.UserRole.Admin
        ), default);

        await _userCommandRepository.RegisterAsync(new User
        (
            fullName: "client client",
            email: "client@bargito.ir",
            password: hashed,
            role: Domain.Enums.UserRole.Employee
        ), default);
    }
}
