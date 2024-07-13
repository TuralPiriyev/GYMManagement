using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.Domain.Entities
{
    public class Payments
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentDate { get; set; }

        public List<Users>  Users { get; set; }
    }
}
