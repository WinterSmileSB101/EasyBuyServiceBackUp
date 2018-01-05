using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Services
{
    class NewOrderService : RestServiceBase<NewOrder>
    {
        public override object OnGet(NewOrder request)
        {
            var response = new ResultEntity<NewOrder>();
            try
            {
                DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_newOrder");
                NewOrder Order = dataCommand.ExecuteEntity<NewOrder>(new { CostomerEmail = request.CostomerEmail });
                
                if (Order != null)
                {
                    //string a = JsonConvert.SerializeObject(user);
                    response.ResultCode = 200;
                    response.ResultContent = Order;
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
            return response;
        }
    }
}
