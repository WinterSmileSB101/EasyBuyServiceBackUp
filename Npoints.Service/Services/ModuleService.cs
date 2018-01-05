using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Model;
using System.Collections.Generic;
using System.Reflection;

namespace Npoints.Service.Services
{
    public class ModuleService : RestServiceBase<Item3>
    {
        public override object OnGet(Item3 item)
        {

            //得到所有商品
            DataCommand dataCommand = DataCommandManager.GetDataCommand("ModuleProductDataCommand");
            List<Item3> result = dataCommand.ExecuteEntityList<Item3>();
            return new ResultEntity<List<Item3>>
            {
                Result = "成功",
                ResultCode = 200,
                ResultContent = result
            };
        }

    }
}
