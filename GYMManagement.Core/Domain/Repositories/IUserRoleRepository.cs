using GYMManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.Domain.Repositories
{
    public interface IUserRoleRepository
    {
        void Add(UserRole userRole);
        List<UserRole> GetByUserId(int userId);
        List<UserRole> GetByRoleId(int roleId);


    }
}
