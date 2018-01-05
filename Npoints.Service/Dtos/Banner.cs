using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("banner")]
    public class Banner
    {
        public string BannerImaUrl { get; set; }
        public string BannerLink { get; set; }
    }
}
