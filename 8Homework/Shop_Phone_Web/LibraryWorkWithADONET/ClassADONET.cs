
using LibrarySetOfClases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LibraryServicesWorkWithDB;

namespace LibraryWorkWithADONET
{
    public class ClassADONET:IServicesDB
    {   public SqlConnection Connection { get; set; }
        public ClassADONET()
        {
            Connection = GetConncection();
        }
        public SqlConnection GetConncection()
        {
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PHONESTORE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connection = new SqlConnection(connectionstring);
            connection.Open();
            return connection;
        }
        public async Task CreateDatabase(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("CREATE DATABASE PHONESTORE");
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();
            connection.Close();
        }
        public async Task CreateTables(SqlConnection connection)
        {
            var t1 = CreatePhone(connection);
            var t2 = CreateCustomer(connection);
            await t1;
            await t2;
            await CreateOrder(connection);
            await CreateOrderPhone(connection);
            await CreateBasket(connection);
            await CreateBasketPhone(connection);
        }
        //CreatePhone и CreateCustomer  могут идти параллельно 
        public async  Task CreatePhone(SqlConnection connection)
        {
            string commands = "CREATE TABLE PHONE(ID_P INTEGER PRIMARY KEY IDENTITY,MODEL CHAR(50) NOT NULL,MARKA CHAR(100) NOT NULL,CAMERA INTEGER,MEMORY INTEGER,battery INTEGER,PRICE FLOAT, DESCRIPTIONPHONE CHAR(300),COUNT_PHONE INTEGER not null)";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();

        }
        public async Task CreateCustomer(SqlConnection connection)
        {
            string commands = "CREATE TABLE CUSTOMER(ID_C INT not null PRIMARY KEY IDENTITY,NAME CHAR(20) NOT NULL,LNAME CHAR(30) NOT NULL,EMAIL CHAR(50),NUMBER CHAR(20) ,COUNTRY CHAR(70),CITY CHAR(50), LOGIN CHAR(15),PASSWORD CHAR(30) not null)";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();

        }
        public async static Task CreateOrder(SqlConnection connection)
        {
            string commands = "CREATE TABLE ORDERS(ID_O INT not null PRIMARY KEY IDENTITY,ID_C INT not null,DATE_O DATETIME,ADRESS CHAR(150),CONSTRAINT FK_Orders_To_Customers FOREIGN KEY (ID_C) REFERENCES CUSTOMER (ID_C) ON DELETE CASCADE);";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();

        }
        public async  Task CreateOrderPhone(SqlConnection connection)
        {
            string commands = "CREATE TABLE ORDER_PHONE(ID_OP INT not null PRIMARY KEY IDENTITY,ID_O INT NOT NULL,ID_P INTEGER NOT NULL,SALE FLOAT,FOREIGN KEY (ID_O) REFERENCES ORDERS(ID_O) ON DELETE CASCADE,FOREIGN KEY (ID_P) REFERENCES PHONE(ID_P) ON DELETE CASCADE)";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();

        }
        public async  Task CreateBasket(SqlConnection connection)
        {
            string commands = "CREATE TABLE BASKET(ID_B INT not null PRIMARY KEY IDENTITY,ID_C INT NOT NULL,FOREIGN KEY (ID_C) REFERENCES CUSTOMER(ID_C) ON DELETE CASCADE);";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();

        }
        public async  Task CreateBasketPhone(SqlConnection connection)
        {
            string commands = "CREATE TABLE BASKET_PHONE(ID_BP INT not null PRIMARY KEY IDENTITY,ID_B INT NOT NULL,ID_P INT NOT NULL,FOREIGN KEY (ID_B) REFERENCES BASKET(ID_B) ON DELETE CASCADE,FOREIGN KEY (ID_P) REFERENCES PHONE(ID_P) ON DELETE CASCADE)";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();
        }
        //два метода могут идти параллельно 
        public async Task InsertPhone(SqlConnection connection, ClassPhone phone)
        {
            SqlCommand command = new SqlCommand("INSERT INTO PHONE(MODEL,MARKA,CAMERA,MEMORY,battery,PRICE,DESCRIPTIONPHONE,COUNT_PHONE)" +
                $"values('{phone.Model}','{phone.Marka}',{phone.Camera},{phone.Memory},{phone.Battery},{phone.Price},'{phone.Desc}',{phone.Count});", connection);



            await command.ExecuteNonQueryAsync();


        }
        public async  Task InsertCustomer(SqlConnection connection, ClassCustomer customer)
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
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();
        }
        public async  Task UpdatePhone(SqlConnection connection, ClassPhone phone,int id)
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
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();

        }

        public async Task<List<ClassPhone>> SelectPhone(SqlConnection connection)
        {
            List<ClassPhone> ListclassPhones = new List<ClassPhone>();

            string commands = "SELECT ID_P,MODEL,MARKA,CAMERA,MEMORY,battery,PRICE,DESCRIPTIONPHONE,COUNT_PHONE FROM PHONE";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
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
        public async Task<List<ClassPhone>> SelectPhoneByCustomer(SqlConnection connection,string login_user)
        {
            List<ClassPhone> ListclassPhones = new List<ClassPhone>();

            string commands = $"SELECT p.ID_P,p.MODEL,p.MARKA,p.CAMERA,p.MEMORY,p.battery,p.PRICE,p.DESCRIPTIONPHONE,p.COUNT_PHONE FROM PHONE p  join basket_phone pb on p.ID_P=pb.ID_P join basket b on pb.ID_B=b.ID_B join customer c  on c.ID_C=b.ID_C where c.LOGIN='{login_user}' ";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
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
        public async Task<List<ClassBasket>> SelectUsersBasket(SqlConnection connection)
        {
            List<ClassBasket> Listbaskets = new List<ClassBasket>();

            string commands = $"SELECT c.login,b.id_b,b.id_c from customer c join basket b on c.id_c=b.id_c";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    ClassBasket b = new ClassBasket();
                    b.Login_U = reader.GetString(0);
                    b.IDBasket = reader.GetInt32(1);
                    b.IDCustomer = reader.GetInt32(2);

                    Listbaskets.Add(b);
                }

            }
            return Listbaskets;
        }
        public async Task<List<ClassCustomer>> SelectCustomer(SqlConnection connection)
        {
            List<ClassCustomer> ListclassUser = new List<ClassCustomer>();

            string commands = "SELECT ID_C,NAME,LNAME,EMAIL,NUMBER, COUNTRY,CITY,LOGIN,PASSWORD FROM CUSTOMER";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    ClassCustomer custom = new ClassCustomer();
                    custom.IDcustomer = reader.GetInt32(0);
                    custom.Name = reader.GetString(1);
                    custom.Lname = reader.GetString(2);
                    custom.Email = reader.GetString(3);
                    custom.Number= reader.GetString(4);
                    custom.Country = reader.GetString(5);
                    custom.City = reader.GetString(6);
                    custom.Login = reader.GetString(7);
                    custom.Password= reader.GetString(8);
                    ListclassUser.Add(custom);
                }

            }
            return ListclassUser;
        }
        public  void ShowPhones(IEnumerable<ClassPhone> classPhones)
        {
            foreach (var k in classPhones)

            {
                Console.WriteLine(k.Model.Trim() + "," + k.Marka);
            }

        }
        public async Task Delete(SqlConnection connection,int id)
        {
            string commands = $"DELETE PHONE WHERE ID_P={id}";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();

        }
        public async Task InsertInBasketID(SqlConnection connection,int id)
        {
            string commands = "INSERT INTO BASKET(ID_C)" + 
                $"values({id})";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();
        }
        public async Task InsertInBasketPhone(SqlConnection connection,int idc,int idp)
        {
            string commands = $"INSERT INTO BASKET_PHONE(ID_B,ID_P)"+
                $"values((Select ID_B from BASKET where ID_C={idc}),{idp})";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();
        }
    }
}
