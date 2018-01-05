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
    public class NPointApplyService_Alvin : RestServiceBase<NPointsApply_Alvin>
    {
        public override object OnDelete(NPointsApply_Alvin request)
        {
            DataCommand dataCommand = null;
            int res = -1;
            if (request.ID != null)
            {
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_DeleteNPointApply");
                res = dataCommand.ExecuteNonQuery(new
                {
                    ID = request.ID
                });
            }
            if (request.ID == null)
            {
                return new ResultEntity<string>
                {
                    Result = "失败",
                    ResultCode = 300,
                    Error = "参数传递错误"
                };
            }
            else if (res != -1)
            {
                return new ResultEntity<string>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = "{'ID':" + request.ID + "}"
                };
            }
            else {
                return new ResultEntity<string>
                {
                    Result = "失败",
                    ResultCode = 300,
                    ResultContent = "{'ID':" + request.ID + "}"
                };
            }
        }

        public override object OnGet(NPointsApply_Alvin request)
        {
            try
            {
                DataCommand dataCommand = null;
                List<NPointApplyEntity> list = null;
                if (request.ID != null)
                {
                    dataCommand = DataCommandManager
                        .GetDataCommand("Alvin_GetNPointApplyByID");
                    NPointApplyEntity nPointApply = dataCommand
                        .ExecuteEntity<NPointApplyEntity>(new
                        {
                            ID = request.ID
                        });
                    return new ResultEntity<NPointApplyEntity>
                    {
                        Result = "成功",
                        ResultCode = 200,
                        ResultContent = nPointApply
                    };
                }
                else if (request.IsApply != null)
                {
                    if (request.IsApply == 2)
                    {
                        dataCommand = DataCommandManager
                            .GetDataCommand("Alvin_GetAllNPointApply");
                        list = dataCommand.ExecuteEntityList<NPointApplyEntity>();
                    }
                    else
                    {
                        dataCommand = DataCommandManager
                            .GetDataCommand("Alvin_GetAllNPointApplyByState");
                        list = dataCommand.ExecuteEntityList<NPointApplyEntity>(new
                        {
                            IsApply = request.IsApply
                        });
                    }
                    return new ResultEntity<List<NPointApplyEntity>>()
                    {
                        Result = "成功",
                        ResultContent = list,
                        ResultCode = 200
                    };
                }
                dataCommand = DataCommandManager
                    .GetDataCommand("Alvin_GetAllNPointApplyDefault");
                list = dataCommand.ExecuteEntityList<NPointApplyEntity>();
                return new ResultEntity<List<NPointApplyEntity>>()
                {
                    Result = "成功",
                    ResultContent = list,
                    ResultCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResultEntity<string>
                {
                    Result = "失败",
                    ResultCode = 300,
                    Error = ex.Message
                };
                throw;
            }
            
        }

        public override object OnPost(NPointsApply_Alvin request)
        {
            DataCommand dataCommand = null;
            int res = -1;
            //修改
            if (request.ID != null && request.IsApply != null)
            {
                if (request.IsApply.Equals('1'))
                {
                    //同意申请（考虑使用事务，存储过程）
                    //增加积点
                    //增加积点历史
                    //发布文章
                    //更新状态
                    //更新状态-
                    dataCommand = DataCommandManager
                        .GetDataCommand("Alvin_AlertNPointApplyApply");
                    res = dataCommand.ExecuteNonQuery(new
                    {
                        ID = request.ID,
                        IsApply = request.IsApply
                    });
                }
                else
                {
                    //更新状态-
                    dataCommand = DataCommandManager
                        .GetDataCommand("Alvin_AlertNPointApplyRefuse");
                    res = dataCommand.ExecuteNonQuery(new {
                        ID = request.ID,
                        IsApply = request.IsApply
                    });
                }
            }
            if (request.ID == null)
            {
                return new ResultEntity<string>
                {
                    Result = "失败",
                    ResultCode = 300,
                    Error = "参数传递错误"
                };
            }
            else if (res != -1)
            {
                return new ResultEntity<string>
                {
                    Result = "成功",
                    ResultCode = 200,
                    ResultContent = "{'ID':" + request.ID + "}"
                };
            }
            else
            {
                return new ResultEntity<string>
                {
                    Result = "失败",
                    ResultCode = 300,
                    ResultContent = "{'ID':" + request.ID + "}"
                };
            }
        }
    }
}
