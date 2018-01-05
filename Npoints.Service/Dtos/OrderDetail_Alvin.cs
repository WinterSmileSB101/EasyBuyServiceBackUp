using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/orderdetail")]
    [RestService("/orderdetail/{OrderListID}")]
    public class OrderDetail_Alvin
    {
        public string OrderListID { get; set; }
        public string ProductID { get; set; }
        public int? Number { get; set; }
        
    }
}
