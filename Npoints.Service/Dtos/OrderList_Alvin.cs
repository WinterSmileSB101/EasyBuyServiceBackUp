using Newegg.API.Attributes;
using System;

namespace Npoints.Service.Dtos
{
    /// <summary>
    /// 订单的实体类
    /// </summary>
    [RestService("/orderlist")]
    [RestService("/orderlist/{OrderListID}")]
    [RestService("/orderlist?orderState={State}")]
    [RestService("/orderlist?CustomerEmail={Email}")]
    [RestService("/orderlist?CustomerEmail={Email}&OrderState={State}")]
    [RestService("/orderlist?StartDate={StartDate}")]
    [RestService("/orderlist?EndDate={EndDate}")]
    [RestService("/orderlist?StartDate={StartDate}&EndDate={EndDate}")]
    public class OrderList_Alvin
    {
        public string OrderListID { get; set; }
        public string OrderState { get; set; }
        public string CostomerEmail { get; set; }
        public DateTime? InDate{ get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? OrderTotal { get; set; }
    }
}
