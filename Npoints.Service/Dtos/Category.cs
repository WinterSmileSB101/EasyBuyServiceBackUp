using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/category?Datalist={Datalist}")]
    [RestService("/category/{ID}")]
    [RestService("/category")]
    public  class Category
    {
        public int? ID { get; set; }
        public string CategoryName { get; set; }
        public Boolean? Enable {get;set;}
        public string InDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
        public string LastEditDate { get; set; }
        public int Number { get; set; }
        public string SplitArr { get; set; }
        public int  Datalist { get; set; }
    }
}
