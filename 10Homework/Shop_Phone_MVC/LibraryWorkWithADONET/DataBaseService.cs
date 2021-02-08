

using LibrarySetOfClases;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ADONETServices;
using DBInterfaces;

namespace ADONETServices
{
    public class DataBaseService 
    {   public  SqlConnection   Connection { get; set; }
         DataBaseService()
        {
            Connection = GetConncection();
        }
        private  SqlConnection GetConncection()
        {
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PHONESTORE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connection = new SqlConnection(connectionstring);
            connection.Open();
            return connection;
        }
        public async  Task ExecuteNonQueryCommand(string commands)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = Connection;
            await command.ExecuteNonQueryAsync();
           
        }
    }
    

}
