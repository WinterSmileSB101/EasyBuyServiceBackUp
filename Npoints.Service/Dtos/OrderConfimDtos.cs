using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("OrderConfim")]
    public class OrderConfimDtos
    {
        public string ListIDNNum { get; set; }
        public string BuyManEmail { get; set; }
        public string PayManEmail { get; set; }
        public int TotalPoint { get; set; }
        public string ShortName { get; set; }
    }
}
