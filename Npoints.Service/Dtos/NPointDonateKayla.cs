using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/npointdonatekayla")]
    public class NPointDonateKayla
    {
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Number { get; set; }
        public int result { get; set; }
        public string text { get; set; }
    }
}
