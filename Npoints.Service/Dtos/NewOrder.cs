using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/neworder")]
    [RestService("/neworder?CostomerEmail={CostomerEmail}")]
    public class NewOrder
    {
        public string CostomerEmail { get; set; }
        public string OrderListID { get; set; }
        public string OrderTotal { get; set; }
    }
}
