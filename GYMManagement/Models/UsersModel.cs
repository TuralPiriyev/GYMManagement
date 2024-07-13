using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string RegistrationStartDate { get; set; }
        public string RegistrationFinalDate { get; set;}

      

        public override string ToString()
        {
            return Name + " " + SurName;
        }

     
    }
}
