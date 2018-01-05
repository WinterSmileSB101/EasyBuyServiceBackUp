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
    class NpointApplyKaylaService : RestServiceBase<NpointApplyKayla>
    {
        public override object OnPost(NpointApplyKayla request)
        {
            var response = new ResultEntity<NpointApplyKayla>();
            try
            {
                DataCommand dataCommand = DataCommandManager.GetDataCommand("kayla_npointApply");
                dataCommand.ExecuteNonQuery(new[] { new { @accountName = request.AccountName, @applyTo = request.ApplyTo, @Title = request.Title, @Description = request.Description } });
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
