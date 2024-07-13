using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.Domain.Entities
{
    public class UsersPayments
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int PaymentsId { get; set; }

        public Users Users { get; set; }
        public Payments Payments { get; set; }
    }
}
