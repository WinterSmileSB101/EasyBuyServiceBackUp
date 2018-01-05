using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/orderlistkayla")]
    [RestService("/orderlistkayla/{OrderListID}")]
    [RestService("/orderlistkayla?CostomerEmail={CostomerEmail}")]
    [RestService("/orderlistkayla?CostomerEmail={CostomerEmail}&datebetween={datebetween}")]
    //
    public class OrderListKayla
    {
        public string OrderListID { get; set; }
        public string OrderState { get; set; }
        public string CostomerEmail { get; set; }
        public int OrderTotal { get; set; }
        public int Discount { get; set; }
        public string PayManEmail { get; set; }
        public string datebetween { get; set; }
        public bool FeaturesProduct { get; set; }
        public string Comment { get; set; }
        public DateTime InDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
        public DateTime? LastEditDate { get; set; }
        public List<OrderDetailKayla> ProductList { get; set; }
    }
}
