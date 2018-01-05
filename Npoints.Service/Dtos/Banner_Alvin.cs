using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/banner_alvin")]
    public class Banner_Alvin
    {
        public int? ID { get; set; }
        public string Link { get; set; }
        public string ImageUrl { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string User { get; set; }
        public string Date { get; set; }
        public bool IsNew { get; set; }
    }
}
