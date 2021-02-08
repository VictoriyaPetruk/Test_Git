using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ADONETServices
{
   public class DataBaseCreation
    {
       
        public async Task CreateDatabase()
        {
            SqlCommand command = new SqlCommand("CREATE DATABASE PHONESTORE");
            command.Connection = Connection;
            await command.ExecuteNonQueryAsync();
        }
        public async Task CreateTables()
        {
            var t1 = CreatePhone();
            var t2 = CreateCustomer();
            await t1;
            await t2;
            await CreateOrder();
            await CreateOrderPhone();
            await CreateBasket();
            await CreateBasketPhone();

        }
        //CreatePhone и CreateCustomer  могут идти параллельно 
        public async Task CreatePhone()
        {
            string commands = "CREATE TABLE PHONE(ID_P INTEGER PRIMARY KEY IDENTITY,MODEL CHAR(50) NOT NULL,MARKA CHAR(100) NOT NULL,CAMERA INTEGER,MEMORY INTEGER,battery INTEGER,PRICE FLOAT, DESCRIPTIONPHONE CHAR(300),COUNT_PHONE INTEGER not null)";
            await ExecuteNonQueryCommand(commands);

        }
        public async Task CreateCustomer()
        {
            string commands = "CREATE TABLE CUSTOMER(ID_C INT not null PRIMARY KEY IDENTITY,NAME CHAR(20) NOT NULL,LNAME CHAR(30) NOT NULL,EMAIL CHAR(50),NUMBER CHAR(20) ,COUNTRY CHAR(70),CITY CHAR(50), LOGIN CHAR(15),PASSWORD CHAR(30) not null)";
            await ExecuteNonQueryCommand(commands);
        }
        public async Task CreateOrder()
        {
            string commands = "CREATE TABLE ORDERS(ID_O INT not null PRIMARY KEY IDENTITY,ID_C INT not null,DATE_O DATETIME,ADRESS CHAR(150),CONSTRAINT FK_Orders_To_Customers FOREIGN KEY (ID_C) REFERENCES CUSTOMER (ID_C) ON DELETE CASCADE);";
            await ExecuteNonQueryCommand(commands);

        }
        public async Task CreateOrderPhone()
        {
            string commands = "CREATE TABLE ORDER_PHONE(ID_OP INT not null PRIMARY KEY IDENTITY,ID_O INT NOT NULL,ID_P INTEGER NOT NULL,SALE FLOAT,FOREIGN KEY (ID_O) REFERENCES ORDERS(ID_O) ON DELETE CASCADE,FOREIGN KEY (ID_P) REFERENCES PHONE(ID_P) ON DELETE CASCADE)";
            await ExecuteNonQueryCommand(commands);

        }
        public async Task CreateBasket()
        {
            string commands = "CREATE TABLE BASKET(ID_B INT not null PRIMARY KEY IDENTITY,ID_C INT NOT NULL,FOREIGN KEY (ID_C) REFERENCES CUSTOMER(ID_C) ON DELETE CASCADE);";
            await ExecuteNonQueryCommand(commands);
        }
        public async Task CreateBasketPhone()
        {
            string commands = "CREATE TABLE BASKET_PHONE(ID_BP INT not null PRIMARY KEY IDENTITY,ID_B INT NOT NULL,ID_P INT NOT NULL,FOREIGN KEY (ID_B) REFERENCES BASKET(ID_B) ON DELETE CASCADE,FOREIGN KEY (ID_P) REFERENCES PHONE(ID_P) ON DELETE CASCADE)";
            await ExecuteNonQueryCommand(commands);
        }
        public async Task Delete(int id)
        {
            string commands = $"DELETE from PHONE WHERE ID_P={id}";
            await ExecuteNonQueryCommand(commands);

        }
        public SqlConnection Connection { get; set; }
        public DataBaseCreation()
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
