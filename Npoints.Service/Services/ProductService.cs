using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Model;
using System.Reflection;

namespace Npoints.Service.Services
{
    public class ProductService : RestServiceBase<Item>
    {
        public override object OnGet(Item request)
        {
            if (request.ProductID != null)
            {
                DataCommand dataCommand = DataCommandManager.GetDataCommand("ProductByIDDataCommand");
                Item item = dataCommand.ExecuteEntity<Item>(new
                {
                    ProductID = request.ProductID
                });
                return new ResultEntity<Item> {
                    Result="成功",
                    ResultCode = 200,
                    ResultContent = item
                };
            }
            return new ResultEntity<Item> {
                Result = "失败",
                ResultCode = 404,
                Error = "参数输入错误",
                ResultContent = null
            };
        }
    }
}
