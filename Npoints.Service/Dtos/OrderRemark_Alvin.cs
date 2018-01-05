using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/orderremark")]
    [RestService("/orderremark/{OrderListID}")]
    public class OrderRemark_Alvin
    {
        public string ID { get; set; }
        public string OrderListID { get; set; }
        public string Comment { get; set; }
        public Boolean? IsShowOut { get; set; }
        public string InDate { get; set; }
        public string InUser { get; set; }  
    }
}
