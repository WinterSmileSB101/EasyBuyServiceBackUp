using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Newtonsoft.Json;
using Npoints.Service.Dtos;
using Npoints.Service.Model;
using Npoints.Service.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Services
{
   public  class ProductDetailService : RestServiceBase<ProductDetail>
    {
        DataCommand dataCommand = null;
        List<ProductDetail> list = null;
        
        public override object OnGet(ProductDetail request)
        {

            ResultEntity<List<ProductDetail>> result = new ResultEntity<List<ProductDetail>>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR
            };
            try
            { 
            DateTime? startTime = new DateTime(1753, 1, 1),
                endTime = DateTime.Now;

            if (request.DateFrom != null)
            {
                startTime = request.DateFrom;
            }

            if (request.DateTo != null)
            {
                endTime = request.DateTo;
            }


            if (request.ProductID != null)
            {
                dataCommand = DataCommandManager.GetDataCommand("GetOneProduct_Amber");
                list = dataCommand.ExecuteEntityList<ProductDetail>(new
                {
                    ID = request.ProductID
                });
            }
            else if (request.ProductName != null)
            {
                dataCommand = DataCommandManager.GetDataCommand("GetOneProductSearch_Amber");
                list = dataCommand.ExecuteEntityList<ProductDetail>(new
                {
                    ProductName = request.ProductName,
                    DateFrom = startTime,
                    DateTo = endTime

                });
            }
            else if (request.DateFrom != null|| request.DateTo != null)
            {
                dataCommand = DataCommandManager.GetDataCommand("GetOneProductSearchTime_Amber");
                list = dataCommand.ExecuteEntityList<ProductDetail>(new
                {
                    DateFrom = startTime,
                    DateTo = endTime
                });
            }
            else
            {
              
                dataCommand = DataCommandManager.GetDataCommand("GetProductList_Amber");
              
                list = dataCommand.ExecuteEntityList<ProductDetail>(new
                {
                    DateFrom = startTime,
                    DateTo = endTime
                });
               
            }
            result.ResultCode = ResultStatic.ResultCode.OK;
            result.Result = ResultStatic.ResultString.SUCCESS;
            result.ResultContent = list;
            return result;
        }
            catch (Exception ex)
            {
                result.Result = ResultStatic.ResultString.SERVERERROR;
                result.ResultCode = ResultStatic.ResultCode.SERVERERROR;
                result.Error = ex.Message;
                return result;
                //throw;
            }

}
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override object OnPost(ProductDetail request)
        {
            ResultEntity<int> result = new ResultEntity<int>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR
            };
            try
            { 
            dataCommand = DataCommandManager.GetDataCommand("PostProduct_Amber");
           int affectRow =  dataCommand.ExecuteNonQuery(new[] {new{
                  ProductID = request.ProductID
                  ,ProductName = request.ProductName
                  ,ImageUrl = request.ImageUrl
                  ,Stock = request.Stock
                  ,FeaturesProduct = request.FeaturesProduct
                  ,ForbidBuy = request.ForbidBuy
                  ,IsPublish = request.IsPublish
                  ,HomeDisplay = request.HomeDisplay
                  ,Priority = request.Priority
                  ,BriefExplanation = request.BriefExplanation
                  ,DetailInfo = request.DetailInfo
                  ,CategoryID = request.CategoryID
                  ,InDate = request.InDate
                  ,InUser = request.InUser
                  ,LastEditUser = request.LastEditUser
                  ,LastEditDate = request.LastEditDate
                  ,OriginalPrice = request.OriginalPrice
                  ,StartTime = request.StartTime
                  ,MaxNumber = request.MaxNumber
                  ,Discount = request.Discount
                  
                  } });
            result.Result = ResultStatic.ResultString.SUCCESS;
            result.ResultCode = ResultStatic.ResultCode.OK;
            result.ResultContent = affectRow;
            return result;
        }
            catch (Exception ex)
            {
                result.Result = ResultStatic.ResultString.SERVERERROR;
                result.ResultCode = ResultStatic.ResultCode.SERVERERROR;
                result.Error = ex.Message;
                return result;
                //throw;
            }
}
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override object OnPut(ProductDetail request)
        {
            ResultEntity<int> result = new ResultEntity<int>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR
            };
            try
            { 

            dataCommand = DataCommandManager.GetDataCommand("PutProduct_Amber");
            int affectRow = dataCommand.ExecuteNonQuery(new[] { new {
                 ProductID = request.ProductID
                  ,ProductName = request.ProductName
                  ,ImageUrl = request.ImageUrl
                  ,Stock = request.Stock
                  ,FeaturesProduct = request.FeaturesProduct
                  ,ForbidBuy = request.ForbidBuy
                  ,IsPublish = request.IsPublish
                  ,HomeDisplay = request.HomeDisplay
                  ,Priority = request.Priority
                  ,BriefExplanation = request.BriefExplanation
                  ,DetailInfo = request.DetailInfo
                  ,CategoryID = request.CategoryID
                  ,LastEditUser = request.LastEditUser
                  ,LastEditDate = request.LastEditDate
                  ,OriginalPrice = request.OriginalPrice
                  ,StartTime = request.StartTime
                  ,MaxNumber = request.MaxNumber
                  ,Discount = request.Discount
            } });

            result.Result = ResultStatic.ResultString.SUCCESS;
            result.ResultCode = ResultStatic.ResultCode.OK;
            result.ResultContent = affectRow;
            return result;
        }
            catch (Exception ex)
            {
                result.Result = ResultStatic.ResultString.SERVERERROR;
                result.ResultCode = ResultStatic.ResultCode.SERVERERROR;
                result.Error = ex.Message;
                return result;
                //throw;
            }
}

        public override object OnDelete(ProductDetail request)
        {
            ResultEntity<int> result = new ResultEntity<int>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR
            };
            try
            { 
            List<string> split = new List<string>();
            int affectRow = 0;
            dataCommand = DataCommandManager.GetDataCommand("DeleteProduct_Amber");
            if (request.SplitArr != null)
            {
                split = new SplitString().bySplit(request.SplitArr, ',');
                foreach (string i in split)
                {
                    affectRow = dataCommand.ExecuteNonQuery(new[] {new{
                       ProductID = i
                 } });
                }
            }
            else
            {
                affectRow = dataCommand.ExecuteNonQuery(new[] {new{
                ProductID = request.ProductID
                } });
            }
            result.Result = ResultStatic.ResultString.SUCCESS;
            result.ResultCode = ResultStatic.ResultCode.OK;
            result.ResultContent = affectRow;
            return result;
        }
            catch (Exception ex)
            {
                result.Result = ResultStatic.ResultString.SERVERERROR;
                result.ResultCode = ResultStatic.ResultCode.SERVERERROR;
                result.Error = ex.Message;
                return result;
                //throw;
            }
}
    }
}
