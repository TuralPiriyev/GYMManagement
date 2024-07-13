using GYMManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.Domain.Repositories
{
    public interface IUsersPaymentsRepository
    {
        void Add(UsersPayments usersPayments);
        void Delete(int id);
        void DeleteByPayments(int id);

        UsersPayments Get(int id);
        List<UsersPayments> GetByUsersId(int Id);
        List<UsersPayments> GetByPaymentsId(int Id);
    }
}
