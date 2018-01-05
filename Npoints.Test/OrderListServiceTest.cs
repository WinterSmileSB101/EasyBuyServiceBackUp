using Npoints.Service.Dtos;
using Npoints.Service.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Test
{
    [TestFixture]
    public class OrderListServiceTest
    {
        OrderListService_Alvin service = null;
        [SetUp]
        public void Setup()
        {
            service = new OrderListService_Alvin();
        }
        /// <summary>
        /// 测试所有数据（新订单时间倒序）
        /// </summary>
        [Test]
        public void TestAllInfo()
        {
            List<OrderList_Alvin> list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = null,
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = "新订单",
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(28, list.Count);
            Assert.AreEqual("12", list[0].OrderListID);
        }

        [Test]
        public void TestID()
        {
            List<OrderList_Alvin> list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = null,
                    OrderListID = "12",
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("新订单", list[0].OrderState);

            list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = null,
                    OrderListID = "123",
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void TestEmail()
        {
            List<OrderList_Alvin> list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = null,
                    OrderListID = null,
                    CostomerEmail = "Alvin.X.Zhang@newegg.com",
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(37, list.Count);
            Assert.AreEqual("12", list[0].OrderListID);

            list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = null,
                    OrderListID = null,
                    CostomerEmail = "Alvin.X.Zhang@neweg.com",
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestDateFrom()
        {
            List<OrderList_Alvin> list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = new DateTime(2017, 8, 25),
                    EndDate = null,
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(12, list.Count);
            Assert.AreEqual("新订单", list[0].OrderState);

            list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = new DateTime(2017, 8, 30),
                    EndDate = null,
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void TestDateTo()
        {
            List<OrderList_Alvin> list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = new DateTime(2017, 8, 30),
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(37, list.Count);
            Assert.AreEqual("新订单", list[0].OrderState);

            list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = new DateTime(2017, 8, 23),
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void TestDateFromTo()
        {
            List<OrderList_Alvin> list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = new DateTime(2017, 8, 24),
                    EndDate = new DateTime(2017, 8, 30),
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(37, list.Count);
            Assert.AreEqual("新订单", list[0].OrderState);

            list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = new DateTime(2017, 8, 27),
                    EndDate = new DateTime(2017, 8, 30),
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(8, list.Count);

            list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = new DateTime(2017, 8, 30),
                    EndDate = new DateTime(2017, 8, 23),
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void TestOrderState()
        {
            List<OrderList_Alvin> list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = null,
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = "新订单",
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(28, list.Count);
            Assert.AreEqual("新订单", list[0].OrderState);

            list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = null,
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = "完成",
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(9, list.Count);

            list = (List<OrderList_Alvin>)service.OnGet(
                new OrderList_Alvin
                {
                    StartDate = null,
                    EndDate = null,
                    OrderListID = null,
                    CostomerEmail = null,
                    OrderState = null,
                    OrderTotal = null,
                    InDate = null
                });
            Assert.AreEqual(37, list.Count);
        }
    }
}
