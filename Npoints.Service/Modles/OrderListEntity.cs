using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class OrderListEntity
    {
        public string OrderListID { get; set; }
        public string OrderState { get; set; }
        public string CostomerEmail { get; set; }
        public string InDate { get; set; }
        public int? OrderTotal { get; set; }
        public int? Discount { get; set; }
        public List<string> EmailText { get; set; }
    }
}