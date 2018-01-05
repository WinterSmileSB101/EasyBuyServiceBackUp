using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class OrderBaseInfoEntity
    {
        public string OrderListID { get; set; }
        public string OrderState { set; get; }
        public string CostomerEmail { get; set; }
        public string PayManEmail { get; set; }
        public int? Total { get; set; }
        public string InDate { get; set; }
        public int? Discount { get; set; }
    }
}
