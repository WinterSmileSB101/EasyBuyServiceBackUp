using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newegg.API.Attributes;

namespace Npoints.Service.Dtos
{
    [RestService("/userkayla")]
    [RestService("/userkayla?Email={Email}")]
    [RestService("/userkayla/{ShortName}")]
    public class UserKayla
    {
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int NPoints { get; set; }
        public int RestPoints { get; set; }
        public DateTime InDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
        public DateTime? LastEditDate { get; set; }
    }
}
