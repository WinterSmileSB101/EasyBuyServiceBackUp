using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/ShoppingCart")]
    public class ProductIDs
    {
        public List<string> ProductlistIDs { get; set; }
    }
}
