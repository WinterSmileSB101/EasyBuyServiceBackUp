using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Modles;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Npoints.Service.Services
{
    class NPointDonateKaylaService : RestServiceBase<NPointDonateKayla>
    {
        public override object OnPost(NPointDonateKayla request)
        {
            //var response = new ResultEntity<NPointDonateKayla>();
            //if (request.ToName == "1")
            //{
            //    response.ResultCode = 200;
            //}
            //else
            //{
            //    response.ResultCode = 404;
            //}
            
            //response.Error = "You not have enough N-Points";
            //return response;

            var response = new ResultEntity<string>();
            NPointDonateKayla data;
            try
            {
                DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_npointDonate");
                data = dataCommand.ExecuteEntity<NPointDonateKayla>(new {
                    fromName = request.FromName,
                    number = Convert.ToInt32( request.Number),
                    toName = request.ToName
                });
                if (data.result == 1)
                {
                    response.ResultCode = 200;
                }
                else if(data.result == -3)
                {
                    response.ResultCode = 404;
                    response.Error = "不能转赠积点给自己";
                }
                else if(data.result == -2)
                {
                    response.ResultCode = 404;
                    response.Error = "对方账户不存在";
                }
                else if(data.result == 0)
                {
                    response.ResultCode = 404;
                    response.Error = "您的账户余额不足";
                }
                else
                {
                    response.ResultCode = 404;
                    response.Error = "There is someting wrong.";
                }
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
