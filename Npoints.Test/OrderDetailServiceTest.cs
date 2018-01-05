using Npoints.Service.Dtos;
using Npoints.Service.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Npoints.Test
{
    [TestFixture]
    public class OrderDetailServiceTest
    {
        OrderDetailService_Alvin service = null;

        [SetUp]
        public void SetUp()
        {
            service = new OrderDetailService_Alvin();
        }

        [Test]
        public void TestAllInfo()
        {
            List<OrderDetail_Alvin> list = (List<OrderDetail_Alvin>)service.OnGet(
                new OrderDetail_Alvin
                {
                    OrderListID = null
                });
            Assert.AreEqual(40, list.Count);
        }

        [Test]
        public void TestInfoByID()
        {
            List<OrderDetail_Alvin> list = (List<OrderDetail_Alvin>)service.OnGet(
                new OrderDetail_Alvin
                {
                    OrderListID = "1"
                });
            Assert.AreEqual(10, list.Count);

            list = (List<OrderDetail_Alvin>)service.OnGet(
                new OrderDetail_Alvin
                {
                    OrderListID = "2"
                });
            Assert.AreEqual(10, list.Count);

            list = (List<OrderDetail_Alvin>)service.OnGet(
                new OrderDetail_Alvin
                {
                    OrderListID = "3"
                });
            Assert.AreEqual(20, list.Count);
        }
    }
}