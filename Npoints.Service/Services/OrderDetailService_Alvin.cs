using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Services
{
    public class OrderDetailService_Alvin : RestServiceBase<OrderDetail_Alvin>
    {
        public override object OnGet(OrderDetail_Alvin request)
        {
            DataCommand dataCommand = null;
            List<OrderDetailEntity> list = null;
            if (request.OrderListID != null)
            {
                //按照ID来查找
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetOrderDetailByID");
                list = dataCommand.ExecuteEntityList<OrderDetailEntity>(new
                {
                    OrderListID = request.OrderListID
                });
            }
            else
            {
                //获取所有
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetAllOrderDetail");
                list = dataCommand.ExecuteEntityList<OrderDetailEntity>();
            }
            return new ResultEntity<List<OrderDetailEntity>>
            {
                Result = "成功",
                ResultCode = 200,
                ResultContent = list
            };
        }
    }
}
