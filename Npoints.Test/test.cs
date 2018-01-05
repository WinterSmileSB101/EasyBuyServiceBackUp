using Newegg.Oversea.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service
{
    [TestFixture]
    class test
    {
        [Test]
        public  void tests() {

            DataCommand dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");
            var result = dataCommand.ExecuteScalar<string>();
            Assert.AreEqual("Hello, DataAccess", result);
            //dataCommand.ExecuteNonQuery(new[] { new { a = "kk", b = 1, c=System.DateTime.Now,d="amber",e="amber",f=System.DateTime.Now} });

        }
    }
}
