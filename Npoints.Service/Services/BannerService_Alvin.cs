﻿using Newegg.API.Interfaces;
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
    public class BannerService_Alvin : RestServiceBase<Banner_Alvin>
    {
        DataCommand dataCommand = null;
        public override object OnDelete(Banner_Alvin request)
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
                                           .GetDataCommand("Alvin_DeleteBannerByID");
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

        public override object OnGet(Banner_Alvin request)
        {

            //获取所有返回
            ResultEntity<List<BannerEntity_Alvin>> result = new ResultEntity<List<BannerEntity_Alvin>>();
            dataCommand = DataCommandManager
                                        .GetDataCommand("Alvin_GetAllBanner");
            List<BannerEntity_Alvin> list = new List<BannerEntity_Alvin>();
            try
            {
                list = dataCommand.ExecuteEntityList<BannerEntity_Alvin>();
                result.ResultCode = ResultStatic.ResultCode.OK;
                result.Result = ResultStatic.ResultString.SUCCESS;
                result.ResultContent = list;
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

        public override object OnPost(Banner_Alvin request)
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
                                                .GetDataCommand("Alvin_UpdateBannerByID");
                    re = dataCommand.ExecuteNonQuery(new
                    {
                        ID = request.ID,
                        Link = request.Link,
                        ImageUrl = request.ImageUrl,
                        StartTime = request.StartTime,
                        EndTime = request.EndTime,
                        Date = request.Date,
                        User = request.User,
                    });
                }
                else
                {
                    //增加
                    dataCommand = DataCommandManager
                                  .GetDataCommand("Alvin_InsertBannerByID");
                    re = dataCommand.ExecuteNonQuery(new
                    {
                        Link = request.Link,
                        ImageUrl = request.ImageUrl,
                        StartTime = request.StartTime,
                        EndTime = request.EndTime,
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
