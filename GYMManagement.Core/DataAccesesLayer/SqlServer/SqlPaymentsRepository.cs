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
    public class SqlPaymentsRepository : IPaymentsRepository
    {
        private  readonly string _connectionString;
        

        public SqlPaymentsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Payments payments)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = " insert into payments output inserted.id values(@amount, @paymentdate)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", payments.Amount);
            cmd.Parameters.AddWithValue("paymentdate", payments.PaymentDate);
            cmd.ExecuteNonQuery();
        }
        public void Update(Payments payment)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "update payments set amount = @amount, paymentdate = @paymentdate)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("amount", payment.Amount);
            cmd.Parameters.AddWithValue("paymentdate", payment.PaymentDate);

            cmd.ExecuteNonQuery();

        }
        public void Delete(Payments payment)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from payments where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id",payment.Id);
            cmd.ExecuteNonQuery ();
        }

        public Payments Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from payments where id = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue ("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                return Mapper.PaymentsMap(reader);
            }
            return null;
        }

        public List<Payments> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Select * from payments";
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Payments> payments = new List<Payments>(); 
            while(reader.Read())
            {
                Payments p = Mapper.PaymentsMap(reader);
                payments.Add(p);
            }
            return payments;
        }

        
    }
}
