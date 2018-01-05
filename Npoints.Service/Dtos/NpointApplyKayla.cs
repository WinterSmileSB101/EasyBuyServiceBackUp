using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/npointapplykayla")]
    public class NpointApplyKayla
    {
        public string AccountName { get; set; }
        public string ApplyTo { get; set; }
        public int IsApply { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public DateTime InDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
        public DateTime? LastEditDate { get; set; }

    }
}
