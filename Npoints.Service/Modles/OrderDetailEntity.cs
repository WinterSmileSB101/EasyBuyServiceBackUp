
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class OrderDetailEntity
    {
        public string OrderListID { get; set; }
        public string ProductID { get; set; }
        public int? Number { get; set; }
    }
}