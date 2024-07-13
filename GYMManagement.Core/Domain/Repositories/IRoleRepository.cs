using GYMManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.Domain.Repositories
{
    public interface IRoleRepository
    {
        Role GetByName (string name);
        Role GetById (int id);
    }
}
