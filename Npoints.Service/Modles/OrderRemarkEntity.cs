using System;

namespace Npoints.Service.Modles
{
    public class OrderRemarkEntity
    {
        public int? ID { get; set; }
        public string OrderListID { get; set; }
        public string Comment { get; set; }
        public Boolean? IsShowOut { get; set; }
        public string InDate { get; set; }
    }
}