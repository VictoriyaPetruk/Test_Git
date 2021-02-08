using LibrarySetOfClases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DBInterfaces;
namespace ADONETServices
{
    public class PhoneOperations:IServiceDBPhone
    {
       
        public void ShowPhones(IEnumerable<ClassPhone> classPhones)
        {
            foreach (var k in classPhones)

            {
                Console.WriteLine(k.Model.Trim() + "," + k.Marka);
            }

        }
        public async Task InsertPhone(ClassPhone phone)
        {
            SqlCommand command = new SqlCommand("INSERT INTO PHONE(MODEL,MARKA,CAMERA,MEMORY,battery,PRICE,DESCRIPTIONPHONE,COUNT_PHONE)" +
                $"values('{phone.Model}','{phone.Marka}',{phone.Camera},{phone.Memory},{phone.Battery},{phone.Price},'{phone.Desc}',{phone.Count});",Connection);

            await command.ExecuteNonQueryAsync();

        }
        public async Task UpdatePhone(ClassPhone phone, int id)
        {
            string commands = $"update PHONE SET MODEL=@model,MARKA=@marka,CAMERA=@camera,MEMORY=@memory,battery=@battery,PRICE=@PRICE,DESCRIPTIONPHONE=@DESCRIPTIONPHONE,COUNT_PHONE=@COUNT_PHONE WHERE ID_P={id}";

            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Parameters.AddWithValue("@model", phone.Model);
            command.Parameters.AddWithValue("@marka", phone.Marka);
            command.Parameters.AddWithValue("@camera", phone.Camera);
            command.Parameters.AddWithValue("@memory", phone.Memory);
            command.Parameters.AddWithValue("@battery", phone.Battery);
            command.Parameters.AddWithValue("@PRICE", phone.Price);
            command.Parameters.AddWithValue("@DESCRIPTIONPHONE", phone.Desc);
            command.Parameters.AddWithValue("@COUNT_PHONE", phone.Count);
            command.Connection = Connection;
            await command.ExecuteNonQueryAsync();

        }

        public async Task<List<ClassPhone>> SelectPhone()
        {
            List<ClassPhone> ListclassPhones = new List<ClassPhone>();

            string commands = "SELECT ID_P,MODEL,MARKA,CAMERA,MEMORY,battery,PRICE,DESCRIPTIONPHONE,COUNT_PHONE FROM PHONE";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection =Connection;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    ClassPhone phone = new ClassPhone();
                    phone.IDPhone = reader.GetInt32(0);
                    phone.Model = reader.GetString(1);
                    phone.Marka = reader.GetString(2);
                    phone.Camera = reader.GetInt32(3);
                    phone.Memory = reader.GetInt32(4);
                    phone.Battery = reader.GetInt32(5);
                    phone.Price = reader.GetDouble(6);
                    phone.Desc = reader.GetString(7);
                    phone.Count = reader.GetInt32(8);
                    ListclassPhones.Add(phone);
                }

            }
            return ListclassPhones;
        }
        public SqlConnection Connection { get; set; }
        public PhoneOperations()
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
