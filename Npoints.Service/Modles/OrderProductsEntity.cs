
namespace Npoints.Service.Modles
{
    public class OrderProductsEntity
    {
        public string ProductName { get; set; }
        public string ProductID { get; set; }
        public int? Number { get; set; }
        public string ImageUrl { get; set; }
        public int? NowPrice { get; set; }
        public int? OriginalPrice { get; set; }
        public int? TotalPrice { get; set; }
    }
}