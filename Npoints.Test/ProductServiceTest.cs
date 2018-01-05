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
    public class ProductServiceTest
    {
        ProductService_Alvin service = null;
        [SetUp]
        public void SetUp()
        {
            service = new ProductService_Alvin();
        }

        [Test]
        public void TestAllInfo()
        {
            List<Product_Alvin> list = (List<Product_Alvin>)service.OnGet(
                new Product_Alvin {
                    ProductID = null
                });
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("鼠标", list[0].ProductName);
        }

        [Test]
        public void TestInfoByID()
        {
            List<Product_Alvin> list = (List<Product_Alvin>)service.OnGet(
                new Product_Alvin
                {
                    ProductID = "1"
                });
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("鼠标", list[0].ProductName);

            list = (List<Product_Alvin>)service.OnGet(
                new Product_Alvin
                {
                    ProductID = "2"
                });
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("咖啡卷", list[0].ProductName);

            list = (List<Product_Alvin>)service.OnGet(
                new Product_Alvin
                {
                    ProductID = "3"
                });
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("尿不湿", list[0].ProductName);
        }
    }
}