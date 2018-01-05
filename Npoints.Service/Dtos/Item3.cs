using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/module")]
    public class Item3
    {
        public string ModuleName { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public int FeaturesProduct { get; set; }
        public int ForbidBuy { get; set; }
        public string BriefExplanation { get; set; }
        public string DetailInfo { get; set; }
        //product表中是分类的ID。这里直接获取分类名称
        public string Category { get; set; }
        public int OriginalPrice { get; set; }
        public int MaxNumber { get; set; }
        public int Discount { get; set; }
    }
}
