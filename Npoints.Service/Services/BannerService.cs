using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Model;
using Npoints.Service.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Services
{
    class BannerService : RestServiceBase<Banner>
    {
        public override object OnGet(Banner banner)
        {
            try
            {

                DataCommand dataCommand = DataCommandManager.GetDataCommand("BannerDataCommand");
                List<Banner> result = dataCommand.ExecuteEntityList<Banner>(null);
                return new ResultEntity<List<Banner>>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = result
                };
            }
            catch (Exception e) {
                return new ResultEntity<List<Banner>>
                {
                    Result = ResultStatic.ResultString.FAILE,
                    ResultCode = ResultStatic.ResultCode.PARAMERROR
                };
           
            }
        }
    }
}
