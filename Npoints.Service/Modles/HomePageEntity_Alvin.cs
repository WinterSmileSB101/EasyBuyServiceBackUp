using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Modles
{
    public class HomePageEntity_Alvin
    {
        public int? ModuleID { get; set; }
        public string ModuleName { get; set; }
        public int? ProductNum { get; set; }
        public string InDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
        public string LastEditDate { set; get; }
    }
}
