using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class ProductsReportEntity
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int? Sale { get; set; }
        public int? Stock { get; set; }
    }
}
