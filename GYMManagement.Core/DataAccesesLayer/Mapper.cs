using GYMManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.DataAccesesLayer
{
    public static class Mapper
    {
        public static Users UsersMap(IDataReader reader)
        {
            return new Users
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                SurName = (string)reader["SurName"],
                PhoneNumber = (string)reader["PhoneNumber"],
                RegistrationStartDate = (string)reader["RegistrationStartDate"],
                RegistrationFinalDate = (string)reader["RegistrationFinalDate"],

            };
        }
        public static User UserMap(IDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Username = (string)reader["Username"],
                Email = (string)reader["Email"],
                PasswordHash = (string)reader["PasswordHash"]
            };
        }
        public static Role RoleMap(IDataReader reader)
        {
            return new Role
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
            };
        }
        public static UserRole UserRoleMap(IDataReader reader)
        {
            return new UserRole
            {
                Id = (int)reader["Id"],
                RoleId = (int)reader["RoleId"],
                UserId = (int)reader["UserId"],
                User = new User
                {
                    Id = (int)reader["UserId"],
                    Email = (string)reader["Email"],
                    PasswordHash = (string)reader["PasswordHash"],
                    Username = (string)reader["Username"]
                },

                Role = new Role
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                }
            };
        }

        public static Payments PaymentsMap(IDataReader reader)
        {
            return new Payments
            {
                Id= (int)reader["Id"],
                Amount = (decimal)reader["Amount"],
                PaymentDate = (string)reader["PaymentDate"]
            };
        }

        public static UsersPayments UsersPaymentsMap(IDataReader reader)
        {
            return new UsersPayments
            {
                Id = (int)reader["Id"], 
                UserId = (int)reader["UserId"],
                PaymentId = (int)reader["UserId"],

                Users = new Users
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    SurName = (string)reader["SurName"],
                    PhoneNumber = (string)reader["PhoneNumber"],
                    RegistrationStartDate = (string)reader["RegistrationStartDate"],
                    RegistrationFinalDate = (string)reader["RegistrationFinalDate"],
                },

                Payments = new Payments
                {
                    Id = (int)reader["Id"],
                    Amount = (decimal)reader["Amount"],
                    PaymentDate = (string)reader["PaymentDate"]
                }
            };
        }
    }
}
