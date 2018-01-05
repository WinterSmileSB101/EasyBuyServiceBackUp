using Newegg.API.Interfaces;
using Npoints.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newegg.Oversea.DataAccess;
using Newtonsoft.Json;
using Npoints.Service.Modles;

namespace Npoints.Service.Services
{
    class UserKaylaService: RestServiceBase<UserKayla>
    {
       public override object OnGet(UserKayla request)
        {
            if (request.ShortName != null)
            {
                var response = new ResultEntity<UserKayla>();
                try
                {
                    DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_account_ShortName");
                    UserKayla user = dataCommand.ExecuteEntity<UserKayla>(new { shortName = request.ShortName });

                    if (user != null)
                    {
                        //string a = JsonConvert.SerializeObject(user);
                        response.ResultCode = 200;
                        response.ResultContent = user;
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
            else if (request.Email != null)
            {
                var response = new ResultEntity<UserKayla>();
                try
                {
                    DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_account_Email");
                    UserKayla user = dataCommand.ExecuteEntity<UserKayla>(new { email = request.Email });

                    if (user != null)
                    {
                        response.ResultCode = 200;
                        response.ResultContent = user;
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
            else
            {
                var result = new ResultEntity<List<UserKayla>>();
                try
                {
                    DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_account"); ;
                    List<UserKayla> list = dataCommand.ExecuteEntityList<UserKayla>(null);
                    //string a = JsonConvert.SerializeObject(list);
                    if (list != null)
                    {
                        //string a = JsonConvert.SerializeObject(user);
                        result.ResultCode = 200;
                        result.ResultContent = list;
                    }
                    else
                    {
                        result.ResultCode = 404;
                        result.Result = "Not Found";
                        result.Error = "服务器未找到可用信息";
                    }
                }
                catch
                {
                    result.ResultCode = 400;
                    result.Result = "Bad Request";
                    result.Error = "请求出错，服务器无法解析";
                }
                return result;
            }
        }

        public override object OnPost(UserKayla request)
        {
            DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_account_Email");
            UserKayla user = dataCommand.ExecuteEntity<UserKayla>(new { email = request.Email });
            if (user == null)
            {
                dataCommand = DataCommandManager.GetDataCommand("kayla_add_account");
                dataCommand.ExecuteNonQuery(new[] { new { @shortName=request.ShortName,@email = request.Email, @telephone = request.Telephone, @nPoints = request.NPoints, @restPoints = request.RestPoints, @inDate = request.InDate, @inUser = request.InUser, @lastEditUser = request.LastEditUser, @lastEditDate = request.LastEditDate } });
            }
            return null;
        }
        
        public UserKayla Add(UserKayla request)
        {
            DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_account"); ;
            List<UserKayla> list = dataCommand.ExecuteEntityList<UserKayla>(null);
            string a = JsonConvert.SerializeObject(list);
            return null;
        }
    }

}
