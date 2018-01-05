using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class OrderReportEntity
    {
        public int? OrderNum { get; set; }
        public int? OrderTotal { get; set; }
        public string CostomerEmail { get; set; }
    }
}
