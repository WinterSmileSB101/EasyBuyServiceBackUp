using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class HomePageProductEntity_Alvin
    {
        public int? ID { get; set; }
        public int? ModuleID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public int? Stock { get; set; }
        public int? OriginalPrice { get; set; }
        public bool IsPublish { get; set; }
    }
}
