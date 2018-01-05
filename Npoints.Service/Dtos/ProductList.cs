using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/productlist")]
    [RestService("/productlist/{ProductID}")]
    [RestService("/productlist?ProductName={ProductName}")]
    public class ProductList
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public int? OriginalPrice { get; set; }
        public int? Discount { get; set; }
        public int? Stock { get; set; }
        public Boolean? IsPublish { get; set; }
        public Boolean? FeaturesProduct { get; set; }
        public Boolean? ForbidBuy { get; set; }
        public int? Priority { get; set; }
    }
}
