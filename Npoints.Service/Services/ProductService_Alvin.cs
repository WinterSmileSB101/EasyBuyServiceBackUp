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

    public class ProductService_Alvin : RestServiceBase<Product_Alvin>
    {
        public override object OnGet(Product_Alvin request)
        {
            DataCommand dataCommand = null;
            List<Product_Alvin> list = null;
            if (request.ProductID != null)
            {
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetProductByID");
                list = dataCommand.ExecuteEntityList<Product_Alvin>(
                    new
                    {
                        ProductID = request.ProductID
                    });
            }
            else
            {
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetAllProduct");
                list = dataCommand.ExecuteEntityList<Product_Alvin>();
            }
            return new ResultEntity<List<Product_Alvin>>
            {
                Result = "成功",
                ResultCode = 200,
                ResultContent = list
            };
        }
    }
}
