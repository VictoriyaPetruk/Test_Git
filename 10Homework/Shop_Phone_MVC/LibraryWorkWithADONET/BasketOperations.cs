using LibrarySetOfClases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DBInterfaces;
namespace ADONETServices
{
    public class BasketOperations:IServiceDBBasket
    {
       
        public async Task InsertInBasketID(int id)
        {
            string commands = "INSERT INTO BASKET(ID_C)" +
                $"values({id})";
            await ExecuteNonQueryCommand(commands);
        }
        public async Task InsertInBasketPhone(int idc, int idp)
        {
            string commands = $"INSERT INTO BASKET_PHONE(ID_B,ID_P)" +
                $"values((Select ID_B from BASKET where ID_C={idc}),{idp})";
            await ExecuteNonQueryCommand(commands);
        }
        public async Task<List<Basket>> SelectUsersBasket()
        {
            List<Basket> Listbaskets = new List<Basket>();

            string commands = $"SELECT c.login,b.id_b,b.id_c from customer c join basket b on c.id_c=b.id_c";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection =Connection;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    Basket b = new Basket();
                    b.Login_U = reader.GetString(0);
                    b.IDBasket = reader.GetInt32(1);
                    b.IDCustomer = reader.GetInt32(2);

                    Listbaskets.Add(b);
                }

            }
            return Listbaskets;
        }
        public async Task<List<ClassPhone>> SelectPhoneByCustomer(string login_user)
        {
            List<ClassPhone> ListclassPhones = new List<ClassPhone>();

            string commands = $"SELECT p.ID_P,p.MODEL,p.MARKA,p.CAMERA,p.MEMORY,p.battery,p.PRICE,p.DESCRIPTIONPHONE,p.COUNT_PHONE FROM PHONE p  join basket_phone pb on p.ID_P=pb.ID_P join basket b on pb.ID_B=b.ID_B join customer c  on c.ID_C=b.ID_C where c.LOGIN='{login_user}' ";
            SqlCommand command = new SqlCommand();
            command.CommandText = commands;
            command.Connection = Connection;
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
       
        public async Task DeleteFromBasket(int id, string login)
        {
            string commands = $"DELETE BASKET_PHONE  from BASKET_PHONE join  basket on BASKET_PHONE.id_b=basket.id_b join customer  on customer.id_c=basket.id_c WHERE BASKET_PHONE.ID_P={id} and customer.login='{login}'";

            await ExecuteNonQueryCommand(commands);

        }
        public SqlConnection Connection { get; set; }
        public  BasketOperations()
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
