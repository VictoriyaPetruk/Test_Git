using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DBInterfaces;

namespace ADONETServices
{
    public class OrderOperations : IServiceDBOrder
    {
       
        public async Task InsertOrderPhone(string login, int idp)
        {
            string commands = $"INSERT INTO ORDER_PHONE(ID_O,ID_P,SALE)" +
                $"values((Select Max(o.ID_O)  from ORDERS o where o.ID_C=(select v.id_c from customer v where v.login='{login}')),{idp},0)";
            await ExecuteNonQueryCommand(commands);
        }
        public async Task ReduceCount(int id, int count)
        {
            string commands = $"Update PHONE set count_phone={count - 1} WHERE ID_P={id}";

            await ExecuteNonQueryCommand(commands);

        }
        public async Task<int> GetNumberOrder(string login_user)
        {
            int id = 0;
            string commands = $"SELECT o.id_o from orders o join customer c on o.id_c=c.id_c where c.login='{login_user}'";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = Connection;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }

            }
            return id;
        }
      

        public async Task InsertOrderId(string login, string adress)
        {
            DateTime date = DateTime.Today;
            string date_s = date.ToString("MM.dd.yyyy");
            string commands = "INSERT INTO ORDERS(ID_C,DATE_O,ADRESS)" +
                $"values((select id_c from customer where login='{login}'),'{date_s}','{adress}')";
            await ExecuteNonQueryCommand(commands);

        }
        public SqlConnection Connection { get; set; }
        public OrderOperations()
        {
            Connection = GetConncection();
        }
        private SqlConnection GetConncection()
        {
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PHONESTORE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connection = new SqlConnection(connectionstring);
            connection.Open();
            return connection;
        }
        public async Task ExecuteNonQueryCommand(string commands)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = Connection;
            await command.ExecuteNonQueryAsync();

        }
    }
}
