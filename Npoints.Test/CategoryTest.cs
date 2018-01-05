using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npoints.Service.Services;
using Npoints.Service.Dtos;

namespace Npoints.Test
{
    [TestFixture]
    class CategoryTest
    {

        CategoryService categoryService = null;
       
        [SetUp]
        public void Setup()
        {
            categoryService = new CategoryService();
        }
        [Test]
        public void TestCategoryOnGet()
        {
            List<Category> list = new List<Category>();
           list = (List<Category>)categoryService.OnGet(null);
            Assert.IsNotNull(list);

        }
        [Test]
        public void TestCategoryOnPost()
        {
            Category category = new Category();
            category.CategoryName = "母婴用品";
            category.Enable = true;
            category.InDate = System.DateTime.Now.ToString();
            category.InUser = "Amber";
            category.LastEditDate = System.DateTime.Now.ToString();
            category.LastEditUser = "Amber";
            int count = (int)categoryService.OnPost(category);
            Assert.AreEqual(1,count);
        }
        [Test]
        public void TestCategoryOnPut()
        {
            Category category = new Category();
            category.CategoryName = "母婴用品";
            category.Enable = true;
            category.LastEditDate = System.DateTime.Now.ToString();
            category.LastEditUser = "Amber";
            int count = (int)categoryService.OnPut(category);
            Assert.AreEqual(10,count);
        }
        [Test]
        public void TestCategoryOnDelete()
        {
            Category category = new Category();
            category.ID = 9;
            int count = (int)categoryService.OnDelete(category);
            Assert.AreEqual(1,count);
        }
    }
}
