using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//废弃暂且不用
namespace Npoints.Service.Services
{
    public class CategoryProductService 
        //: RestServiceBase<CategoryProduct>
    {
        /*
           public override object OnGet(CategoryProduct request)
        {
            if (request.CategoryName != null)
            {
                DataCommand dataCommand = DataCommandManager.GetDataCommand("CategoryProductDataCommand");
                CategoryProduct result = dataCommand.ExecuteEntity<CategoryProduct>(new
                {
                  CategoryName = request.CategoryName 
                });
                return new ResultEntity<CategoryProduct>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = result
                };
            }
            return new ResultEntity<CategoryProduct>
            {
                Result = "失败",
                ResultCode = 404,
                Error = "参数输入错误",
                ResultContent = null
            };

        }

             */
        //根据名字访问单独的CategoryPaoduct

        public CategoryProduct CProductByName(string CategoryName)
        {
            if (CategoryName != null)
            {
                DataCommand dataCommand = DataCommandManager.GetDataCommand("CategoryProductDataCommand");
                CategoryProduct result = dataCommand.ExecuteEntity<CategoryProduct>(new
                {
                    CategoryName = CategoryName
                });
                return result;
            }
            return null;
        }
    }
}
