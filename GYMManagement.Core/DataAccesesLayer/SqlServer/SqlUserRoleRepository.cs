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
    public class SqlUserRoleRepository : IUserRoleRepository
    {
        private readonly string  _connectionString;
        public SqlUserRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(UserRole userRole)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "insert into UserRole(userid, roleid) values (@username,@roleid";

            SqlCommand cmd = new SqlCommand (query, connection);
            cmd.Parameters.AddWithValue("userid", userRole.UserId);
            cmd.Parameters.AddWithValue("roleid", userRole.RoleId);
            cmd.ExecuteNonQuery();
        }

        public List<UserRole> GetByRoleId(int roleId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open ();

            const string query = @"select ur.Id, ur.RoleId, r.Id RoleId, r.Name RoleName, 
                                   ur.UserId, u.Username, u.Email, u.PasswordHash  from UserRole ur 
                                   join userl u on u.Id = ur.UserId
                                   join Role r on r.Id = ur.RoleId
                                   where ur.roleId = @roleId";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("roleId", roleId);

            SqlDataReader reader = cmd.ExecuteReader();
            List<UserRole> userRoles = new List<UserRole>();

            while (reader.Read())
            {
                UserRole userRole = Mapper.UserRoleMap(reader);

                userRoles.Add(userRole);
            }

            return userRoles;
        }

        public List<UserRole> GetByUserId(int userId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = @"select ur.Id, ur.RoleId, r.Id RoleId, r.Name RoleName, 
                                   ur.UserId, u.Username, u.Email, u.PasswordHash  from UserRole ur 
                                   join userl u on u.Id = ur.UserId
                                   join Role r on r.Id = ur.RoleId
                                   where ur.userid = @userid";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("userId", userId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<UserRole> userRoles = new List<UserRole>();

            while (reader.Read())
            {
                UserRole userRole = Mapper.UserRoleMap(reader);

                userRoles.Add(userRole);
            }

            return userRoles;
        }
    }
}
