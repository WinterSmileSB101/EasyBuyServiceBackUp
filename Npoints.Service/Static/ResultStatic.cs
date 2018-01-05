using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Static
{
    public class ResultStatic
    {
        public class ResultString{
            public const string SUCCESS = "成功";
            public const string FAILE = "失败";
            public const string ERROR = "错误";
            public const string SERVERERROR = "服务器内部错误";
        }

        public class ResultCode
        {
            public const int NOTFIND = 404;
            public const int OK = 200;
            public const int SERVERERROR = 500;
            public const int PARAMERROR = 300;
        }

    }
}
