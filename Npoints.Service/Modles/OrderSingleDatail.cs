using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class OrderSingleDatail
    {
        public OrderBaseInfoEntity OrderBaseInfo { get; set; }
        public List<OrderRemarkEntity> OrderRemarks { get; set; }
        public List<OrderProductsEntity> OrderProducts { get; set; }
    }
}
