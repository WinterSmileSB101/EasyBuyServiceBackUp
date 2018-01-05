using Newegg.API.Attributes;
using Npoints.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Npoints.Service.Dtos
{
    //一定要有基础路由
    [RestService("/productdetail")]
    [RestService("/productdetail/{ProductID}")]
    [RestService("/productdetail?ProductName={Name}&DateFrom={DateFrom}&DateTo={DateTo}")]
    [RestService("/productdetail?ProductName={ProductName}")]
    public class ProductDetail
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public int? Stock { get; set; }
        public Boolean? FeaturesProduct { get; set; }
        public Boolean? ForbidBuy { get; set; }
        public Boolean? IsPublish { get; set; }
        public Boolean? HomeDisplay { get; set; }
        public int? Priority { get; set; }
        public string BriefExplanation { get; set; }
        public string DetailInfo { get; set; }
        public int CategoryID { get; set; }
        public string InDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
        public string LastEditDate { get; set; }
        public int? OriginalPrice { get; set; }
        public string StartTime { get; set; }
        public int? MaxNumber { get; set; }
        public int? Discount { get; set; }

        //public List<String> CategoryName{get;set;}
        public string CategoryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateTo { get; set; }
        public string SplitArr { get; set; }
        
    }
}
