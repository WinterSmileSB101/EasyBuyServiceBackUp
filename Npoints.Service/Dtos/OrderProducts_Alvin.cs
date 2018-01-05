using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/orderproducts")]
    [RestService("/orderproducts?OrderListID={OrderListID}")]
    public class OrderProducts_Alvin
    {
        public string OrderListID { get; set; }
    }
}