using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Models
{
    public class PaymentsModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; } 
        public string PaymentDate { get; set; }
    }
}
