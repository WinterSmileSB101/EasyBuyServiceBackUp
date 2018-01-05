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
    public class OrderRemarkTest
    {
        OrderRemarkService_Alvin service = null;
        [SetUp]
        public void SetUp()
        {
            service = new OrderRemarkService_Alvin();
        }

        [Test]
        public void TestAllInfoGet()
        {
            List<OrderRemark_Alvin> list = (List<OrderRemark_Alvin>)service.OnGet(
                new OrderRemark_Alvin {
                    OrderListID = null
                }
                );
            Assert.AreEqual(24,list.Count);
        }

        [Test]
        public void TestInfoByIDGet()
        {
            List<OrderRemark_Alvin> list = (List<OrderRemark_Alvin>)service.OnGet(
                new OrderRemark_Alvin
                {
                    OrderListID = "1"
                }
                );
            Assert.AreEqual(8, list.Count);

            list = (List<OrderRemark_Alvin>)service.OnGet(
                new OrderRemark_Alvin
                {
                    OrderListID = "2"
                }
                );
            Assert.AreEqual(8, list.Count);

            list = (List<OrderRemark_Alvin>)service.OnGet(
                new OrderRemark_Alvin
                {
                    OrderListID = "3"
                }
                );
            Assert.AreEqual(8, list.Count);
        }
    }
}