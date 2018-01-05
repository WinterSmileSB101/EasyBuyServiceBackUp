using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Services
{
    public class CategoryListService  : RestServiceBase<Item2>
    {
        public override object OnGet(Item2 ca)
        {
            
            //得到所有商品
            DataCommand dataCommand = DataCommandManager.GetDataCommand("AllProductDataCommand");
            List<Item2> result = dataCommand.ExecuteEntityList<Item2>();
            return new ResultEntity<List<Item2>>
            {
                Result = "成功",
                ResultCode = 200,
                ResultContent = result
            };
        }

    }

}
