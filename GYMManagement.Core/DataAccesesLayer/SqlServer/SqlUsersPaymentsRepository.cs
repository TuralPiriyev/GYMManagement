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
    public class SqlUsersPaymentsRepository : IUsersPaymentsRepository
    {
        private readonly string _connectionString;

        public SqlUsersPaymentsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(UsersPayments usersPayments)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
                
            connection.Open();
            const string query = "insert into userspayments (usersid,paymentid) values(@usersid, @paymentid)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("usersid",  usersPayments.UsersId);
            cmd.Parameters.AddWithValue("paymentid", usersPayments.PaymentsId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "delete from userspayment where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();

        }

        public void DeleteByPayments(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
            const string query = "delete from userspayment where id = @id";

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public UsersPayments Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            // burdaki query ferqlidi deyis!
            const string query = "select from userspayment where id = @id";
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader(); 

            if(reader.Read())
            {
                return Mapper.UsersPaymentsMap(reader);
            }
            return null;

            
            
        }

        public List<UsersPayments> GetByPaymentsId(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "";
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            List<UsersPayments> UsersPayments = new List<UsersPayments>();

            while(reader.Read())
            {
                UsersPayments up = new UsersPayments();
                UsersPayments.Add(up);
            }
            return UsersPayments;
        }

        public List<UsersPayments> GetByUsersId(int id)
        {
            using SqlConnection connection= new SqlConnection(_connectionString);
            connection.Open();
            const string query = "";
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            List<UsersPayments> usersPayments = new List<UsersPayments>();
            while(
                reader.Read())
            {
                UsersPayments up = Mapper.UsersPaymentsMap(reader);
                usersPayments.Add(up);
            }
            return usersPayments;
        }
    }
}
