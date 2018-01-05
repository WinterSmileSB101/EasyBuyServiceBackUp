using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/homepage_alvin")]
    [RestService("/homepage_alvin/{ModuleID}")]
    public class HomePage_Alvin
    {
        public int? ID { get; set; }
        public int? ModuleID { get; set; }
        public string ProductID { get; set; }
        public int? ProductNum { get; set; }
        public string User { get; set; }
        public string Date { get; set; }
        public bool IsNew { get; set; }
    }
}
