using Npoints.Service.Dtos;
using Npoints.Service.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Npoints.Test
{
    [TestFixture]
    class ProductTest
    {

        ProductDetailService productDetailService = null;
        ProductListService productListService = null;

        [SetUp]
        public void Setup() {
            productDetailService = new ProductDetailService();
            productListService = new ProductListService();
        }
        [Test]
        public void TestDetailOnGet() {
            ProductDetail productDetail = new ProductDetail();
            //productDetail.DateFrom = Convert.ToDateTime("2017/8/28");
            List<ProductDetail> list = (List<ProductDetail>)productDetailService.OnGet(productDetail);
            Assert.IsNotNull(list);
        }
        [Test]
        public void TestDetailOnPost() {
           ProductDetail productDetail = new ProductDetail();
            productDetail.ProductID = "s21d65s4";
            productDetail.ProductName = "苹果7Plus";
            productDetail.ImageUrl = "sadsad";
            productDetail.Stock = 5;
            productDetail.FeaturesProduct = false;
            productDetail.ForbidBuy = false;
            productDetail.IsPublish = true;
            productDetail.HomeDisplay = false;
            productDetail.Priority = 1000;
            productDetail.BriefExplanation = "货真价实";
            productDetail.DetailInfo = "eweewe";
            productDetail.CategoryID = 1;
            productDetail.InDate = DateTime.Now.ToString();
            productDetail.InUser = "Amber";
            productDetail.LastEditUser = "Amber";
            productDetail.LastEditDate = DateTime.Now.ToString();
            productDetail.StartTime = DateTime.Now.ToString();
            productDetail.MaxNumber = 1;
            productDetail.OriginalPrice = 4000;
            productDetail.Discount = 10;
            int row =(int)productDetailService.OnPost(productDetail);
            Assert.AreEqual(1, row);
        }
        [Test]
        public void TestDetailOnDelete() {
            ProductDetail productDetail = new ProductDetail();
            productDetail.ProductID = "s21d65s4";
            int count = (int)productDetailService.OnDelete(productDetail);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void TestDetailOnPut() {
            ProductDetail productDetail = new ProductDetail();
            productDetail.ProductID = "s21d65s4";
            productDetail.ProductName = "苹果7Plus";
            productDetail.ImageUrl = "sadsad";
            productDetail.Stock = 2;
            productDetail.FeaturesProduct = false;
            productDetail.ForbidBuy = false;
            productDetail.IsPublish = true;
            productDetail.HomeDisplay = false;
            productDetail.Priority = 1000;
            productDetail.BriefExplanation = "货真价实";
            productDetail.DetailInfo = "eweewe";
            productDetail.CategoryID = 1;
            productDetail.LastEditUser = "Amber";
            productDetail.LastEditDate = DateTime.Now.ToString();
            productDetail.StartTime = DateTime.Now.ToString();
            productDetail.MaxNumber = 1;
            productDetail.OriginalPrice = 4000;
            productDetail.Discount = 10;
            int count = (int)productDetailService.OnPut(productDetail);
            Assert.AreEqual(1,count);
        }
        [Test]
        public void TestAllDetailOnGet(){
            ProductDetail productDetail = new ProductDetail();
            List<ProductDetail> list = (List<ProductDetail>)productDetailService.OnGet(productDetail);
            Assert.IsNotNull(list);
        }

        [Test]
        public void TestCategoryOnGet() {
            //Category category = new Category();

        }

    }
}
