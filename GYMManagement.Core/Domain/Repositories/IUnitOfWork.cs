using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public IUsersRepository UsersRepository { get; }
        public IUserRepository UserRepository => throw new NotImplementedException();

        public IRoleRepository RoleRepository => throw new NotImplementedException();

        public IUserRoleRepository UserRoleRepository => throw new NotImplementedException();

        bool IsOnline();
   
    }
}
