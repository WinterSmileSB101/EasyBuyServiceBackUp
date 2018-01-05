using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Services
{
    public class ProductListService : RestServiceBase<ProductList>
    {
        public override object OnGet(ProductList request) {
            DataCommand dataCommand = null;
            List<ProductList> list = null;
            if (request.ProductID != null)
            {
                dataCommand = DataCommandManager.GetDataCommand("GetOneProduct_Amber");
                list = dataCommand.ExecuteEntityList<ProductList>(new
                {
                    ID = request.ProductID
                });
            }
            else if (request.ProductName != null) {
                dataCommand = DataCommandManager.GetDataCommand("GetOneProductWhere_Amber");
                list = dataCommand.ExecuteEntityList<ProductList>(new
                {
                    ProductName = request.ProductName
                });
            }
          
            else
            {
                dataCommand = DataCommandManager.GetDataCommand("GetProductList_Amber");
                list = dataCommand.ExecuteEntityList<ProductList>(null);
            }
            return list;
        }
    }
}
