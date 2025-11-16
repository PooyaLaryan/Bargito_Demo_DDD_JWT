using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Repositories.Permissions.Command
{
    public interface IPermissionCommandRepository : ICommandRepository<Permission>
    {
    }
}
