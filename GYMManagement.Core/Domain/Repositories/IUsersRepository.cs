using GYMManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.Domain.Repositories
{
    public interface IUsersRepository
    {
        void Add(Users users);
        void Update(Users users);
        void Delete(int id);

        Users Get(int id);
        List<Users> Get();


    }
}
