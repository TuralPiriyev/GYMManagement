using GYMManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.Domain.Repositories
{
    public interface IPaymentsRepository
    {
        void Add(Payments payment);
        void Update(Payments payment);
        void Delete (Payments payment);

        Payments Get(int id);
        List<Payments> Get();

    }
}
