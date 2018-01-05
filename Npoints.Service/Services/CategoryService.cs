using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;
using Npoints.Service.Model;
using Npoints.Service.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Services
{
    public class CategoryService : RestServiceBase<Category>
    {
        DataCommand dataCommand = null;
        List<Category> list = null;
        /// <summary>
        /// 获取分类管理界面的全部信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override object OnGet(Category request)
        {
            ResultEntity<List<Category>> result = new ResultEntity<List<Category>>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR
            };
            dataCommand = DataCommandManager.GetDataCommand("GetCategoryNumber_Amber");
            list = dataCommand.ExecuteEntityList<Category>(null);
            result.Result = ResultStatic.ResultString.SUCCESS;
            result.ResultCode = ResultStatic.ResultCode.OK;
            result.ResultContent = list;
            return result;
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override object OnPost(Category request)
        {
            ResultEntity<int> result = new ResultEntity<int>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR
            };
            try
            { 
            dataCommand = DataCommandManager.GetDataCommand("PostCategory_Amber");
            int affectrow = dataCommand.ExecuteNonQuery(new[] {
                new
                {
                    CategoryName = request.CategoryName,
                    Enable = request.Enable,
                    InDate = request.InDate,
                    InUser = request.InUser,
                    LastEditUser = request.LastEditUser,
                    LastEditDate =request.LastEditDate
                }
                });
            result.Result = ResultStatic.ResultString.SUCCESS;
            result.ResultCode = ResultStatic.ResultCode.OK;
            result.ResultContent = affectrow;
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
        public override object OnPut(Category request)
        {
            dataCommand = DataCommandManager.GetDataCommand("PutCategory_Amber");
            ResultEntity<int> result = new ResultEntity<int>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR
            };
            try
            {
                int affectrow = dataCommand.ExecuteNonQuery(new[] {
                new{
                    ID = request.ID,
                    CategoryName = request.CategoryName,
                    Enable = request.Enable,
                    LastEditUser = request.LastEditUser,
                    LastEditDate =request.LastEditDate
                }
            });
            result.Result = ResultStatic.ResultString.SUCCESS;
            result.ResultCode = ResultStatic.ResultCode.OK;
            result.ResultContent = affectrow;
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
        public override object OnDelete(Category request)
        {
            ResultEntity<int> result = new ResultEntity<int>
            {
                Result = ResultStatic.ResultString.ERROR,
                ResultCode = ResultStatic.ResultCode.PARAMERROR
            };
            try
            {
                List<string> split = new List<string>();
                int affectrow = 0;
                dataCommand = DataCommandManager.GetDataCommand("DeleteCategory_Amber");
                if (request.SplitArr != null)
                {
                    split = new SplitString().bySplit(request.SplitArr, ',');
                    foreach (string i in split)
                    {
                        affectrow = dataCommand.ExecuteNonQuery(new[] {new{
                       ID = int.Parse(i)
                 } });
                    }
                }
                else
                {
                    affectrow = dataCommand.ExecuteNonQuery(new[] {
                new{
                    ID =request.ID
                }
            });

                }
                result.Result = ResultStatic.ResultString.SUCCESS;
                result.ResultCode = ResultStatic.ResultCode.OK;
                result.ResultContent = affectrow;
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
