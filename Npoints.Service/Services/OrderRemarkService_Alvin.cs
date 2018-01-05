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
    public class OrderRemarkService_Alvin : RestServiceBase<OrderRemark_Alvin>
    {
        public override object OnGet(OrderRemark_Alvin request)
        {
            DataCommand dataCommand = null;
            List<OrderRemarkEntity> list = null;
            if (request.OrderListID != null)
            {
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetOrderRemarkByID");
                list = dataCommand.ExecuteEntityList<OrderRemarkEntity>(
                    new
                    {
                        OrderListID = request.OrderListID
                    }
                    );
            }
            else {
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetAllOrderRemark");
                list = dataCommand.ExecuteEntityList<OrderRemarkEntity>();
            }
            return new ResultEntity<List<OrderRemarkEntity>>
            {
                Result = "成功",
                ResultCode = 200,
                ResultContent = list
            };
        }

        public override object OnPost(OrderRemark_Alvin request)
        {
            
            Console.WriteLine("asdasd");
            return base.OnPost(request);
        }

        public override object OnDelete(OrderRemark_Alvin request)
        {
            DataCommand dataCommand = null;
            int res = -1;
            if (request.ID != null)
            {
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_DeleteOrderRemarkByID");
                res = dataCommand.ExecuteNonQuery(
                    new
                    {
                        ID = request.ID
                    });
            }
            if (res != -1)
            {
                return new ResultEntity<string>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = "{'ID':" + request.ID + "}"
                };
            }
            else {
                return new ResultEntity<string>
                {
                    Result = "失败",
                    ResultCode = 300,
                    ResultContent = "{'ID':" + request.ID + "}"
                };
            }
        }

        public override object OnPut(OrderRemark_Alvin request)
        {
            try
            {
                DataCommand dataCommand = null;
                OrderRemarkEntity orderRemark = null;
                if (request.ID == null && request.OrderListID != null
                    && request.Comment != null
                    && request.InUser != null && request.IsShowOut != null)
                {
                    //新建条件满足
                    dataCommand = DataCommandManager
                        .GetDataCommand("Alvin_AddOrderRemarkByID");
                    orderRemark = dataCommand
                        .ExecuteEntity<OrderRemarkEntity>(new
                        {
                            OrderListID = request.OrderListID,
                            Comment = request.Comment,
                            InUser = request.InUser,
                            InDate = DateTime.Now,
                            IsShowOut = request.IsShowOut,
                            LastEditUser = request.InUser,
                            LastEditDate = DateTime.Now
                        });
                }
                return new ResultEntity<OrderRemarkEntity>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = orderRemark
                };
            }
            catch (Exception ex)
            {
                return new ResultEntity<string>
                {
                    Result = "成功",
                    Error = ex.Message,
                    ResultCode = 300
                };
                throw ex;
            }
        }
    }
}
