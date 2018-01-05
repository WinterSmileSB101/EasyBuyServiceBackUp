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
    class NPointKaylaService : RestServiceBase<NPointsHistoryKayla>
    {
        public override object OnGet(NPointsHistoryKayla request)
        {
            var response = new ResultEntity<List<NPointsHistoryKayla>>();
            try
            {
                DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_npointHistory");
                List<NPointsHistoryKayla> npointlists = dataCommand.ExecuteEntityList<NPointsHistoryKayla>(new { accountName = request.AccountName });
                
                if (npointlists != null)
                {
                    //string a = JsonConvert.SerializeObject(user);
                    response.ResultCode = 200;
                    response.ResultContent = npointlists;
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
