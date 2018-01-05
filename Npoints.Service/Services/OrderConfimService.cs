using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Model;
using Npoints.Service.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace Npoints.Service.Services
{
    class OrderConfimService : RestServiceBase<OrderConfimDtos>
    {
        public override object OnGet(OrderConfimDtos ocd)
        {

            var dataCommand = DataCommandManager.GetDataCommand("OrderConfimDataCommand");
            var p = new DynamicParameters();
            string str = DateTime.Now.ToString()+ocd.ShortName;
            var MG = getMGMd5(str);
            p.Add("@ListIDNNum", ocd.ListIDNNum);
            p.Add("@BuyMan_Email", ocd.BuyManEmail);
            p.Add("@PayMan_Email", ocd.PayManEmail);
            p.Add("@TotalPoint", ocd.TotalPoint);
            p.Add("@ShortName", ocd.ShortName);
            p.Add("@orderLsitID",MG);
            p.Add("@PA3",dbType:DbType.Int16, direction: ParameterDirection.Output);
            
            dataCommand.ExecuteNonQuery(p);
            var result = p.Get<Int16>("@PA3");
            if (result == 1)
            {
                return new ResultEntity<int>
                {
                    Result = ResultStatic.ResultString.SUCCESS,
                    ResultCode = ResultStatic.ResultCode.OK,
                    ResultContent = result
                };
            }
            else if (result == 0) {
                return new ResultEntity<int>
                {
                    Result = ResultStatic.ResultString.FAILE,
                    ResultCode = ResultStatic.ResultCode.PARAMERROR,
                    ResultContent = result
                };
            }
            else if (result == 2) {
                return new ResultEntity<int>
                {
                    Result = ResultStatic.ResultString.FAILE,
                    Error = "商品库存不足",
                    ResultCode = ResultStatic.ResultCode.PARAMERROR,
                    ResultContent = result
                };
            }
            else if (result == -1) {
                return new ResultEntity<int>
                {
                    Result = ResultStatic.ResultString.SUCCESS,
                    ResultCode = ResultStatic.ResultCode.OK,
                    ResultContent = 1
                };
            }
            else {
                return new ResultEntity<int>
                {
                    Result = ResultStatic.ResultString.FAILE,
                    Error = "其他错误",
                    ResultCode = ResultStatic.ResultCode.PARAMERROR,
                    ResultContent = result
                };
            }


        }

        private static string getMGMd5(string str) {
            string result = null;
            MD5 md5 = new MD5CryptoServiceProvider();
            result = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(str)),4,8);
            result = result.Replace("-","");
            return result;
        }
    }
}