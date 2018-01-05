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
    class OrderListsKaylaService : RestServiceBase<OrderListKayla>
    {
        public override object OnGet(OrderListKayla request)
        {
            var response = new ResultEntity<List<OrderListKayla>>();
            if (request.CostomerEmail!=null)
            {
                if (request.datebetween == null)
                {
                    try
                    {
                        DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_orderList");
                        List<OrderListKayla> OrderLists = dataCommand.ExecuteEntityList<OrderListKayla>(new { CostomerEmail = request.CostomerEmail });


                        List<string> OrderListIDs = new List<string>();
                        foreach (var list in OrderLists)
                        {
                            OrderListIDs.Add(list.OrderListID);
                        }
                        
                        dataCommand = DataCommandManager.GetDataCommand("kayla_orderDetail");
                        List<OrderDetailKayla> OrderDetaillists = dataCommand.ExecuteEntityList<OrderDetailKayla>(new { orderListIDs = OrderListIDs.ToArray() });


                        Dictionary<string,List < OrderDetailKayla >> OrderDictionary= new Dictionary<string, List<OrderDetailKayla>>();
                        foreach (var item in OrderDetaillists)
                        {
                            if (OrderDictionary.ContainsKey(item.OrderListID))
                            {
                                OrderDictionary[item.OrderListID].Add(item);
                            }
                            else
                            {
                                OrderDictionary.Add(item.OrderListID, new List<OrderDetailKayla> { item });
                            }
                        }

                        foreach(OrderListKayla list in OrderLists)
                        {
                            list.ProductList = OrderDictionary[list.OrderListID];
                        }


                        //foreach (OrderListKayla list in OrderLists)
                        //{
                        //    dataCommand = DataCommandManager.GetDataCommand("kayla_orderDetail");
                        //    list.ProductList = dataCommand.ExecuteEntityList<OrderDetailKayla>(new { orderListID = list.OrderListID });
                        //}

                        if (OrderLists != null)
                        {
                            //string a = JsonConvert.SerializeObject(user);
                            response.ResultCode = 200;
                            response.ResultContent = OrderLists;
                        }
                        else
                        {
                            response.ResultCode = 404;
                            response.Result = "Not Found";
                            response.Error = "服务器未找到可用信息";
                        }
                    }
                    catch
                    {
                        response.ResultCode = 400;
                        response.Result = "Bad Request";
                        response.Error = "请求出错，服务器无法解析";
                    }
                }
                else
                {
                    try
                    {
                        List<OrderListKayla> OrderLists;
                        DataCommand dataCommand;
                        if (request.datebetween== "lastWeek")
                        {
                            dataCommand = DataCommandManager.GetDataCommand("kayla_orderList_time");
                            OrderLists = dataCommand.ExecuteEntityList<OrderListKayla>(new { CostomerEmail = request.CostomerEmail, fromDate=System.DateTime.Now.AddDays(-7) } );

                        }
                        else if(request.datebetween == "lastMouth")
                        {
                            dataCommand = DataCommandManager.GetDataCommand("kayla_orderList_time");
                            OrderLists = dataCommand.ExecuteEntityList<OrderListKayla>(new { CostomerEmail = request.CostomerEmail, fromDate = System.DateTime.Now.AddMonths(-1) } );

                        }
                        else if(request.datebetween == "lastHalfYear")
                        {
                            dataCommand = DataCommandManager.GetDataCommand("kayla_orderList_time");
                            OrderLists = dataCommand.ExecuteEntityList<OrderListKayla>(new { CostomerEmail = request.CostomerEmail, fromDate = System.DateTime.Now.AddMonths(-6) } );

                        }
                        else
                        {
                            dataCommand = DataCommandManager.GetDataCommand("kayla_orderList");
                            OrderLists = dataCommand.ExecuteEntityList<OrderListKayla>(new { CostomerEmail = request.CostomerEmail });
                        }


                        //foreach (OrderListKayla list in OrderLists)
                        //{
                        //    dataCommand = DataCommandManager.GetDataCommand("kayla_orderDetail");
                        //    list.ProductList = dataCommand.ExecuteEntityList<OrderDetailKayla>(new { orderListID = list.OrderListID });
                        //}

                        List<string> OrderListIDs = new List<string>();
                        foreach (var list in OrderLists)
                        {
                            OrderListIDs.Add(list.OrderListID);
                        }
                        
                        dataCommand = DataCommandManager.GetDataCommand("kayla_orderDetail");
                        List<OrderDetailKayla> OrderDetaillists = dataCommand.ExecuteEntityList<OrderDetailKayla>(new { orderListIDs = OrderListIDs.ToArray() });


                        Dictionary<string, List<OrderDetailKayla>> OrderDictionary = new Dictionary<string, List<OrderDetailKayla>>();
                        foreach (var item in OrderDetaillists)
                        {
                            if (OrderDictionary.ContainsKey(item.OrderListID))
                            {
                                OrderDictionary[item.OrderListID].Add(item);
                            }
                            else
                            {
                                OrderDictionary.Add(item.OrderListID, new List<OrderDetailKayla> { item });
                            }
                        }

                        foreach (OrderListKayla list in OrderLists)
                        {
                            list.ProductList = OrderDictionary[list.OrderListID];
                        }

                        if (OrderLists != null)
                        {
                            //string a = JsonConvert.SerializeObject(user);
                            response.ResultCode = 200;
                            response.ResultContent = OrderLists;
                        }
                        else
                        {
                            response.ResultCode = 404;
                            response.Result = "Not Found";
                            response.Error = "服务器未找到可用信息";
                        }
                    }
                    catch
                    {
                        response.ResultCode = 400;
                        response.Result = "Bad Request";
                        response.Error = "请求出错，服务器无法解析";
                    }
                }
            }
            else
            {
                response.ResultCode = 400;
                response.Result = "Bad Request";
                response.Error = "请求出错，服务器无法解析";
            }
            return response;
        }

        public override object OnPost(OrderListKayla request)
        {
            var response = new ResultEntity<OrderListKayla>();
            try
            {
                DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_orderList_insert");
                dataCommand.ExecuteNonQuery(new[] { new { @orderListID=request.OrderListID, @orderState=request.OrderState, @costomerEmail = request.CostomerEmail, @orderTotal = request.OrderTotal,  @payManEmail=request.PayManEmail } });

                foreach(OrderDetailKayla item in request.ProductList)
                {
                    dataCommand = DataCommandManager.GetDataCommand("kayla_orderDetail_insert");
                    dataCommand.ExecuteNonQuery(new[] { new { @orderListID=request.OrderListID, @productID=item.ProductID, @number=item.Number } });
                }

                response.ResultCode = 200;
            }
            catch
            {
                response.ResultCode = 404;
                response.Error = "There is someting wrong.Please try again later.";
            }

            return response;
        }
    }
}
