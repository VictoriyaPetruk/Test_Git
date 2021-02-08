using LibraryServicesWorkWithDB;
using LibrarySetOfClases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnitTestsLibrary
{[TestClass()]
    public class OrderTest
    {
        [TestMethod()]
        public void TestGetSum()
        {
            var dbMock = new Mock<IServicesDB>();
            dbMock
                 .Setup(x => x.Connection)
                 .Returns(new SqlConnection() { ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PHONESTORE; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False" })
                 .Verifiable();

            var phoneMock = new Mock<ClassPhone>();
            var phonesMock = new Mock<List<ClassPhone>>();
            phonesMock
                .Setup(x => x.Add(new ClassPhone() { Price = 400 }))
                .Verifiable();
            phonesMock
                .Setup(x => x.Add(new ClassPhone() { Price = 500 }))
                .Verifiable();
            var workUint = new Shop_Phone_MVC.Controllers.OrderController(dbMock.Object);
            var result = workUint.GetSum();
            result.Should().Be(900);
            dbMock.Verify();



            //var ConnMock = new Mock<SqlConnection>();
            //ConnMock
            //    .Setup(x => x.ConnectionString)
            //    .Returns(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PHONESTORE; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            //dbMock
            //    .Setup(x => x.SelectPhoneByCustomer(x.Connection, "vika"))
            //    .Returns()

            //var workUint = new Shop_Phone_MVC.Controllers.OrderController(dbMock.Object);
            //var result = workUint.LoadData();
        }

        [TestMethod]
        public void TestGetMultiply()
        {
            var result = Multiply(3);
            result.Should().Be(12);

        }
        public double Multiply(int a)
        {
            return 2 * 2 * a;
        }

    }
   
}
