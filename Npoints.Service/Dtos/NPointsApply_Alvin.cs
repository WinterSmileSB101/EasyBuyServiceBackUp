using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/npointsapply")]
    [RestService("/npointsapply/{ID}")]
    public class NPointsApply_Alvin
    {
        public int? ID { get; set; }
        public int? IsApply { get; set; }
        public string AccountName {get;set;}
    }
}
