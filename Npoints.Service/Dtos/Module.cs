using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("module")]
    public  class Module
    {
        public string ModuleName { get; set; }
        //由商品填充module的内容
        public List<Item> Products { get; set; }
    }
}
