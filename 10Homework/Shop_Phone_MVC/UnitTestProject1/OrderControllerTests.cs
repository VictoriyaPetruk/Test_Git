using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using DBInterfaces;
using System.Data.SqlClient;
using LibrarySetOfClases;
using System.Collections.Generic;
using System;
using Shop_Phone_MVC.Controllers;
using Shop_Phone_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;

namespace UnitTestProject1
{
    [TestClass]
    public class OrderControllerTests
    {
      
        private List<ClassPhone> phones = new List<ClassPhone>()
            {
                new ClassPhone() { Price = 400,Marka="",Battery=0,Camera=0,Model="",Memory=0,Count=0,Desc="" },
                new ClassPhone() { Price = 500,Marka="",Battery=0,Camera=0,Model="",Memory=0,Count=0,Desc="" }
            };
        private MakeOrderViewModel model = new MakeOrderViewModel() { Name = "vika", Lname = "petruk",Sum=400,Count=1 };
        [TestMethod]
        public void TestGetSum()
        {
            //var dbOMock= new Mock<IServiceDBOrder>();
            //var dbBMock = new Mock<IServiceDBBasket>();
            //var dbCMock = new Mock<IServiceDBCustomer>();
            //var workUint = new Shop_Phone_MVC.Controllers.OrderController(dbOMock.Object, dbBMock.Object, dbCMock.Object);
            //var result = workUint.GetSum();
            //result.Should().Be(900);
        }
        [TestMethod]
        public void TestReturnOrderView()
        {
            var dbOMock = new Mock<IServiceDBOrder>();
            var dbBMock = new Mock<IServiceDBBasket>();
            var dbCMock = new Mock<IServiceDBCustomer>();
            var datamock = new Mock<OrderController>(dbOMock.Object, dbBMock.Object, dbCMock.Object) { CallBase = true };
            datamock
                .Setup(d => d.LoadData())
                .Returns(model).Verifiable();
            var result = datamock.Object.MakeOrder() as ViewResult;
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(model, result.Model);
        }
        [TestMethod]
        public void TestLoadData()
        {

        }
        [TestMethod]
        public void MakeOrderTest()
        {

        }
        [TestMethod]
        public void ConfirmationTest()
        {

        }

    }
}
