using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/datareport")]
    public class DataReport_Alvin
    {
        public string WhichReport { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}
