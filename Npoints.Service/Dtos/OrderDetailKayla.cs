using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    public class OrderDetailKayla
    {
        public string OrderListID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string BriefExplanation { get; set; }
        public string ImageUrl { get; set; }        
        public int Price { get; set; }
        public int Number { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
        public DateTime? LastEditDate { get; set; }
    }
}
