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
    public class DataReportService_Alvin : RestServiceBase<DataReport_Alvin>
    {
        public override object OnGet(DataReport_Alvin request)
        {
            DataCommand dataCommand = null;
            string start = "1753/1/1", end = DateTime.Now.ToString() ;
            if (request.WhichReport == null)
                return new ResultEntity<string>
                {
                    Result = "失败",
                    ResultCode = 300,
                    Error = "参数错误"
                };

            if (request.start != null) start = request.start;
            if (request.end != null) end = request.end;

            switch (request.WhichReport)
            {
                case "One":
                case "one":
                    //订单报表
                    dataCommand = DataCommandManager
                        .GetDataCommand("Alvin_DataReportOne");
                    List<OrderReportEntity> one = dataCommand
                        .ExecuteEntityList<OrderReportEntity>(
                        new
                        {
                            start = start,
                            end = end,
                        }
                        );
                    return new ResultEntity<List<OrderReportEntity>>
                    {
                        Result = "成功",
                        ResultCode = 200,
                        ResultContent = one
                    };
                case "Two":
                case "two":
                    dataCommand = DataCommandManager
                        .GetDataCommand("Alvin_DataReportTwo");
                    List<ProductsReportEntity> two = dataCommand
                        .ExecuteEntityList<ProductsReportEntity>(new
                        {
                            start = start,
                            end = end
                        });
                    return new ResultEntity<List<ProductsReportEntity>>
                    {
                        Result = "成功",
                        ResultCode = 200,
                        ResultContent = two
                    };
                case "Three":
                case "three":
                    dataCommand = DataCommandManager
                        .GetDataCommand("Alvin_DataReportThree");
                    List<PeopleReportEntity> three = dataCommand
                        .ExecuteEntityList<PeopleReportEntity>(new
                        {
                            start = start,
                            end = end
                        });
                    return new ResultEntity<List<PeopleReportEntity>>
                    {
                        Result = "成功",
                        ResultCode = 200,
                        ResultContent = three
                    };
                default:
                    break;
            }
            return new ResultEntity<string>
            {
                Result = "失败",
                ResultCode = 404,
                Error="没有找到"
            }; ;
        }
    }
}
