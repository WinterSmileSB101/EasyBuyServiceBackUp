using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/loginkayla")]
    public class LoginKayla
    {
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string Code { get; set; }
    }
}
