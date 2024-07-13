using GYMManagement.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.DataAccesesLayer
{
    public class EmptyUnitOfWork : IUnitOfWork
    {
        public IUsersRepository UsersRepository => throw new NotImplementedException();

        public IUserRepository UserRepository => throw new NotImplementedException();

        public IRoleRepository RoleRepository => throw new NotImplementedException();

        public IUserRoleRepository UserRoleRepository => throw new NotImplementedException();
        public bool IsOnline()
        {
            return false;
        }
    }
}
