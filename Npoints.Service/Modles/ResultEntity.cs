using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class ResultEntity<T>
    {
        public string Result { get; set; }
        public int? ResultCode { get; set; }
        public string Error { get; set; }
        public T ResultContent { get; set; }
    }
}
