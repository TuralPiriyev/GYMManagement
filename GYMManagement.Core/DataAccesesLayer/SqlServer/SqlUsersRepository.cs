using GYMManagement.Core.Domain.Entities;
using GYMManagement.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.DataAccesesLayer.SqlServer
{
    public class SqlUsersRepository : IUsersRepository
    {
        private readonly string _connectionString;
       

        public SqlUsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Users users)
        {
            try {   using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "insert into Userr values (@Name, @SurName, @PhoneNumber,@RegistrationStartDate , @RegistrationFinalDate)";
             
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Name", users.Name);
            cmd.Parameters.AddWithValue("SurName", users.SurName);
            cmd.Parameters.AddWithValue("PhoneNumber", users.PhoneNumber);
            cmd.Parameters.AddWithValue("RegistrationStartDate", users.RegistrationStartDate);
            cmd.Parameters.AddWithValue("RegistrationFinalDate", users.RegistrationFinalDate);

            cmd.ExecuteNonQuery();
            }

            catch(Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);

                throw;
            }
          
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from userr where id = @id ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery ();
        }
 
        public void Update(Users users)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

          
            const string query = "update userr set name = @name, surname = @surname, phonenumber = @phonenumber, registrationstartdate = @registrationstartdate,registrationfinaldate = @registrationfinaldate";
            SqlCommand cmd = new SqlCommand( query, connection);
            cmd.Parameters.AddWithValue("id",users.Id);
            cmd.Parameters.AddWithValue("name", users.Name);
            cmd.Parameters.AddWithValue("surname", users.SurName);
            cmd.Parameters.AddWithValue("phonenumber", users.PhoneNumber);
            cmd.Parameters.AddWithValue("registrationstartdate", users.RegistrationStartDate);
            cmd.Parameters.AddWithValue("registrationfinaldate", users.RegistrationFinalDate);

            cmd.ExecuteNonQuery();

        }
        public Users Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from userr where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                 return Mapper.UsersMap(reader);
            }
            return null;
        }

        public List<Users> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from userr";
            SqlCommand cmd = new SqlCommand(query, connection);

           SqlDataReader reader = cmd.ExecuteReader();

            List<Users> result = new List<Users>();
            while(reader.Read())
            {
                Users users = Mapper.UsersMap(reader);
                result.Add(users);
            }
            return result;
        }

      
    }
}
