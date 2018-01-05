using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/product")]
    [RestService("/product/{ProductID}")]
    public class Product_Alvin
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int? OriginalPrice { get; set; }
    }
}
