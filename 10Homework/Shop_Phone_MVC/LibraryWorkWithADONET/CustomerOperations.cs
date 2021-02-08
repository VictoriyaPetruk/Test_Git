using LibrarySetOfClases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DBInterfaces;
namespace ADONETServices
{
    public class CustomerOperations: IServiceDBCustomer
    {
       
        public async Task<List<string>> GetCustomer(string login_user)
        {
            List<string> fio = new List<string>();
            string commands = $"SELECT Name,Lname from customer where login='{login_user}'";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = Connection;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {

                    string name = reader.GetString(0);
                    string lname = reader.GetString(1);
                    fio.Add(name);
                    fio.Add(lname);

                }

            }
            return fio;
        }
        public async Task<List<Customer>> SelectCustomer()
        {
            List<Customer> ListclassUser = new List<Customer>();

            string commands = "SELECT ID_C,NAME,LNAME,EMAIL,NUMBER, COUNTRY,CITY,LOGIN,PASSWORD FROM CUSTOMER";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = Connection;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    Customer custom = new Customer();
                    custom.IDcustomer = reader.GetInt32(0);
                    custom.Name = reader.GetString(1);
                    custom.Lname = reader.GetString(2);
                    custom.Email = reader.GetString(3);
                    custom.Number = reader.GetString(4);
                    custom.Country = reader.GetString(5);
                    custom.City = reader.GetString(6);
                    custom.Login = reader.GetString(7).Trim();
                    custom.Password = reader.GetString(8).Trim();
                    ListclassUser.Add(custom);
                }

            }
            return ListclassUser;
        }
        public async Task InsertCustomer(Customer customer)
        {
            string commands = "INSERT INTO CUSTOMER(NAME,LNAME,EMAIL,NUMBER ,COUNTRY,CITY, LOGIN,PASSWORD)" +
                   "values(@name,@lname,@email,@number,@country,@city,@login,@password);";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Parameters.AddWithValue("@name", customer.Name);
            command.Parameters.AddWithValue("@lname", customer.Lname);
            command.Parameters.AddWithValue("@email", customer.Email);
            command.Parameters.AddWithValue("@number", customer.Number);
            command.Parameters.AddWithValue("@country", customer.Country);
            command.Parameters.AddWithValue("@city", customer.City);
            command.Parameters.AddWithValue("@login", customer.Login);
            command.Parameters.AddWithValue("@password", customer.Password);
            command.Connection = Connection;
            await command.ExecuteNonQueryAsync();
        }
        public SqlConnection Connection { get; set; }
        public CustomerOperations()
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
