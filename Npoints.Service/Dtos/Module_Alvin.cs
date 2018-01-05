using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/module_alvin")]
    public class Module_Alvin
    {
        public int? ID { get; set; }
        public string ModuleName { get; set; }
        public int? Priority { get; set; }
        public bool Enable { get; set; }
        public string User { get; set; }
        public string Date { get; set; }
        public bool IsNew { get; set; }
    }
}
