using GYMManagement.Core.Domain.Entities;
using GYMManagement.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement.Core.DataAccesesLayer.SqlServer
{/*
  * Bu User Login ucundu
  * 
  */
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(User user)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = @"insert into userl output inserted.id values(@username, @email, @Passwordhash)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("email", user.Email);
            cmd.Parameters.AddWithValue("Passwordhash", user.PasswordHash);

            user.Id = (int)cmd.ExecuteScalar();
        }


        public User Get(string username)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "select * from userl where username = @username";

            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("username", username);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                return Mapper.UserMap(reader);
            }
            return null;
        }

        public User GetById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            const string query = "select * from userl where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id",id);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                return Mapper.UserMap(reader);
            }
            return null;

        }
    }
}
