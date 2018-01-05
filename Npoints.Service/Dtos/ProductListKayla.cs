using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    public class ProductListKayla
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public bool FeaturesProduct { get; set; }
        public bool ForbidBuy { get; set; }
        public bool IsPublish { get; set; }
        public string BriefExplanation { get; set; }
        public int OriginalPrice { get; set; }
        public DateTime StartTime { get; set; }
        public int MaxNumber { get; set; }
        public int Discount { get; set; }
    }
}
