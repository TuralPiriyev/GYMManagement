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
    public class SqlRoleRepository : IRoleRepository
    {
        private readonly string _connectionString;

        public SqlRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Role GetById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from Role where Id = @Id";

            SqlCommand cmd = new SqlCommand (query, connection);

            cmd.Parameters.AddWithValue("Id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read() == false)
            {
                return null;
            }
            return Mapper.RoleMap(reader);
        }

        public Role GetByName(string name)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from Role where name = @name";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue ("Name", name); 

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read() == false)
            {
                return null;
            }
            return Mapper.RoleMap(reader);

        }
    }
}
