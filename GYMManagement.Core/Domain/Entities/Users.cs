using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.Domain.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string RegistrationStartDate { get; set; }
        public string? RegistrationFinalDate { get; set; }
         
        public List<Payments> Payments { get; set; }        
    }
}
