using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//废弃
namespace Npoints.Service.Dtos
{
    [RestService("/categorylist")]
    public class CategoryProduct
    {
        public string CategoryName { get; set; }
        public List<Item> Products { get; set; }
    }
}
