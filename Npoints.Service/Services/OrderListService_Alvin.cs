using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Modles;
using System;
using System.Collections.Generic;

namespace Npoints.Service.Services
{
    /// <summary>
    /// 订单的服务类
    /// </summary>
    public class OrderListService_Alvin : RestServiceBase<OrderList_Alvin>
    {
        /// <summary>
        /// 获取订单的信息,增加单个信息的获取
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override object OnGet(OrderList_Alvin request)
        {
            DataCommand dataCommand = null;
            List<OrderListEntity> list = null;

            Console.WriteLine(request.CostomerEmail);

            DateTime? startTime = new DateTime(1753,1,1), 
                endTime = DateTime.Now;//初始化两个值起始时间为最小值，终点时间为当前值
            //获取所有邮箱 Alvin_GetOrderEmailWhereDefault
            dataCommand = DataCommandManager.
             GetDataCommand("Alvin_GetOrderEmailWhereDefault");
            //参数是1个就只能这样写，不能使用 new []{new {}}这种方式
            List<string> EmialText = dataCommand.ExecuteEntityList<string>(new
            {
                StartDate = startTime,
                EndDate = endTime
            });
            if (request.StartDate != null)
            {
                //不为空则赋值起始时间
                startTime = request.StartDate;
            }
            if (request.EndDate != null)
            {
                endTime = request.EndDate;
            }
            //最高优先级的
            if (request.OrderListID != null)
            {
                //返回单条记录
                dataCommand = DataCommandManager.
                GetDataCommand("Alvin_GetOrderSingleDetailByID");
                //返回订单详情
                OrderBaseInfoEntity orderBaseInfo = dataCommand
                    .ExecuteEntity<OrderBaseInfoEntity>(new
                    {
                        OrderListID = request.OrderListID
                    });
                //返回订单商品列表
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetOrderProductByID");
                List<OrderProductsEntity> orderProducts = dataCommand
                    .ExecuteEntityList<OrderProductsEntity>(
                     new
                     {
                         OrderListID = request.OrderListID
                     }
                    );
                //返回订单的备注列表
                dataCommand = DataCommandManager
                   .GetDataCommand("Alvin_GetOrderRemarkByID");
                List<OrderRemarkEntity> orderRemarks = dataCommand
                    .ExecuteEntityList<OrderRemarkEntity>(
                    new
                    {
                        OrderListID = request.OrderListID
                    }
                    );
                return new ResultEntity<OrderSingleDatail>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = new OrderSingleDatail
                    {
                        OrderBaseInfo = orderBaseInfo,
                        OrderProducts = orderProducts,
                        OrderRemarks = orderRemarks
                    }
                };
            }

            //需要查询email
            if (request.CostomerEmail == null
                && request.OrderState != null)
            {
                //没有邮箱限制
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetOrderDataWhereState");
                list = dataCommand.ExecuteEntityList<OrderListEntity>(
                    new
                    {
                        StartDate = startTime,
                        EndDate = endTime,
                        State = request.OrderState
                    }
                    );
                list[0].EmailText = EmialText;//赋值，仅仅第一个有,解析的时候要注意
                return new ResultEntity<List<OrderListEntity>>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = list
                };
            }
            else if (request.CostomerEmail != null
                && request.OrderState == null)
            {
                //没有状态限制
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetOrderDataWhereEmail");
                list = dataCommand.ExecuteEntityList<OrderListEntity>(
                    new
                    {
                        StartDate = startTime,
                        EndDate = endTime,
                        Email = request.CostomerEmail
                    }
                    );
                list[0].EmailText = EmialText;//赋值，仅仅第一个有,解析的时候要注意
                return new ResultEntity<List<OrderListEntity>>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = list
                };
            }
            else if (request.CostomerEmail != null
                && request.OrderState != null)
            {
                //都有限制
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetOrderDataWhereState");
                list = dataCommand.ExecuteEntityList<OrderListEntity>(
                    new
                    {
                        StartDate = startTime,
                        EndDate = endTime,
                        State = request.OrderState,
                        Email = request.CostomerEmail
                    }
                    );
                list[0].EmailText = EmialText;//赋值，仅仅第一个有,解析的时候要注意
                return new ResultEntity<List<OrderListEntity>>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = list
                };
            }else {
                //返回所有记录
                dataCommand = DataCommandManager.
                 GetDataCommand("Alvin_GetOrderDataWhereDefault");
                //参数是1个就只能这样写，不能使用 new []{new {}}这种方式
                list = dataCommand.ExecuteEntityList<OrderListEntity>(new
                {
                    StartDate = startTime,
                    EndDate = endTime
                });
            }
            list[0].EmailText = EmialText;//赋值，仅仅第一个有,解析的时候要注意
            return new ResultEntity<List<OrderListEntity>>
            {
                Result = "成功",
                ResultCode = 200,
                ResultContent = list
            };
        }

        public override object OnPost(OrderList_Alvin request)
        {
            try
            {
                DataCommand dataCommand = null;
                int num = -1;
                if (request.OrderState != null && request.OrderListID != null)
                {
                    //修改状态
                    if (request.OrderState.Equals("取消"))
                    {
                        //Alvin_BackNpoints
                        dataCommand = DataCommandManager
                       .GetDataCommand("Alvin_BackNpoints");
                    }
                    else
                    {
                        dataCommand = DataCommandManager
                            .GetDataCommand("Alvin_AlertOrderStateByID");
                    }
                    num = dataCommand.ExecuteNonQuery(
                        new
                        {
                            OrderListID = request.OrderListID,
                            OrderState = request.OrderState
                        });
                    if (num == 1)
                    {
                        dataCommand = DataCommandManager
                            .GetDataCommand("Alvin_GetOrderData");
                        OrderListEntity entity = dataCommand
                            .ExecuteEntity<OrderListEntity>(new
                            {
                                ID = request.OrderListID
                            });
                        return new ResultEntity<OrderListEntity> {
                            Result = "成功",
                            ResultCode = 200,
                            ResultContent = entity
                        };
                    }
                    return new ResultEntity<OrderListEntity> {
                        Result = "失败",
                        ResultCode = 500,
                        Error ="数据库错误！"};
                }
                return new ResultEntity<OrderListEntity> {
                    Result = "失败",
                    ResultCode = 300,
                    Error = "参数错误，请检查参数后重试" };
            }
            catch (Exception)
            {
                throw;
                return "失败";
            }
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override object OnDelete(OrderList_Alvin request)
        {
            DataCommand dataCommand = null;
            int res = -1;
            if (request.OrderListID != null)
            {
                //删除指定订单编号的订单
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_DeleteOrderByID");
                res = dataCommand.ExecuteNonQuery(new
                {
                    OrderListID = request.OrderListID
                });
            }
            if (res != -1)
            {
                return new ResultEntity<String>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = @"{'deleteID':" + request.OrderListID + "}"
                };
            }
            else {
                return new ResultEntity<String>
                {
                    Result = "失败",
                    ResultCode = 300,
                    ResultContent = @"{'deleteID':" + request.OrderListID + "}"
                };
            }
            Console.WriteLine("请求数据：" + request.OrderListID);
            return base.OnDelete(request);
        }
    }
}
