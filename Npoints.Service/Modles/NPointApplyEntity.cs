using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class NPointApplyEntity
    {
        public int? ID { get; set; }
        public string AccountName { get; set; }
        public string ApplyTo { get; set; }
        public int? IsApply { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string InDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
        public string LastEditDate { get; set; }
    }
}
