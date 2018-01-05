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
    public class OrderProductsService_Alvin : RestServiceBase<OrderProducts_Alvin>
    {
        public override object OnGet(OrderProducts_Alvin request)
        {
            DataCommand dataCommand = null;
            List<OrderProductsEntity> list = null;
            if (request.OrderListID != null)
            {
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetOrderProductByID");
                list = dataCommand.ExecuteEntityList<OrderProductsEntity>(
                    new
                    {
                        OrderListID = request.OrderListID
                    }
                    );
            }
            return new ResultEntity<List<OrderProductsEntity>> {
                Result = "成功",
                ResultCode = 200,
                ResultContent = list
            };
        }
    }
}
