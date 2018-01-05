using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Modles;
using Npoints.Service.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Services
{
    public class HomePageService_Alvin : RestServiceBase<HomePage_Alvin>
    {
        DataCommand dataCommand = null;
        public override object OnDelete(HomePage_Alvin request)
        {
            ResultEntity<string> result = new ResultEntity<string>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR,
            };
            if (request.ID != null)
            {
                //删除记录
                dataCommand = DataCommandManager
                                           .GetDataCommand("Alvin_DeleteHomePageByID");
                int re = dataCommand.ExecuteNonQuery(new
                {
                    ID = request.ID
                });
                if (re == 0)
                {
                    result.Result = ResultStatic.ResultString.FAILE;
                    result.ResultCode = ResultStatic.ResultCode.SERVERERROR;
                    result.ResultContent = request.ID + "";
                }
                else
                {
                    result.Result = ResultStatic.ResultString.SUCCESS;
                    result.ResultCode = ResultStatic.ResultCode.OK;
                    result.ResultContent = request.ID + "";
                }
            }
            return result;
        }

        public override object OnGet(HomePage_Alvin request)
        {
            ResultEntity<List<HomePageEntity_Alvin>> result = new ResultEntity<List<HomePageEntity_Alvin>>(); 
            try
            {
                if (request.ModuleID == null)
                {
                    //获取所有返回
                    dataCommand = DataCommandManager
                                                .GetDataCommand("Alvin_GetAllHomePage");
                    List<HomePageEntity_Alvin> list = new List<HomePageEntity_Alvin>();

                    list = dataCommand.ExecuteEntityList<HomePageEntity_Alvin>();
                    result.ResultCode = ResultStatic.ResultCode.OK;
                    result.Result = ResultStatic.ResultString.SUCCESS;
                    result.ResultContent = list;
                }
                else
                {
                    dataCommand = DataCommandManager
                        .GetDataCommand("Alvin_GetAllHomePageProduct");
                    List<HomePageProductEntity_Alvin> productLsit =
                        new List<HomePageProductEntity_Alvin>();
                    productLsit = dataCommand.ExecuteEntityList<HomePageProductEntity_Alvin>(
                        new
                        {
                            ModuleID = request.ModuleID
                        });
                    return new ResultEntity<List<HomePageProductEntity_Alvin>>
                    {
                        ResultCode = ResultStatic.ResultCode.OK,
                        Result = ResultStatic.ResultString.SUCCESS,
                        ResultContent = productLsit
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = ResultStatic.ResultCode.SERVERERROR;
                result.Result = ResultStatic.ResultString.ERROR;
                result.Error = ex.Message;
                throw ex;
            }
            return result;
        }

        public override object OnPost(HomePage_Alvin request)
        {
            ResultEntity<string> result = new ResultEntity<string>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR,
            };
            try
            {
                int re = 0;
            //修改增加
            if (!request.IsNew)
            {
                //修改，更新几乎所有
                dataCommand = DataCommandManager
                                            .GetDataCommand("Alvin_UpdateModuleByID");
                re = dataCommand.ExecuteNonQuery(new
                {
                    ID = request.ID,
                    ModuleID = request.ModuleID,
                    ProductID = request.ProductID,
                    Date = request.Date,
                    User = request.User,
                });
            }
            else
            {
                //增加
                dataCommand = DataCommandManager
                                            .GetDataCommand("Alvin_InsertModuleByID");
                re = dataCommand.ExecuteNonQuery(new
                {
                    ModuleID = request.ModuleID,
                    ProductID = request.ProductID,
                    Date = request.Date,
                    User = request.User,
                });
            }

            if (re == 0)
            {
                result.Result = ResultStatic.ResultString.FAILE;
                result.ResultCode = ResultStatic.ResultCode.SERVERERROR;
                result.ResultContent = request.ID + "";
            }
            else
            {
                result.Result = ResultStatic.ResultString.SUCCESS;
                result.ResultCode = ResultStatic.ResultCode.OK;
                result.ResultContent = request.ID + "";
            }
            return result;
        }
            catch (Exception ex)
            {
                result.Error = ex.Message;
                result.ResultCode = ResultStatic.ResultCode.SERVERERROR;
                return result;
                //throw ex;
            }
}
    }
}
