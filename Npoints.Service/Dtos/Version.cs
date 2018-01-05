using Newegg.API.Attributes;

namespace Npoints.Service.Dtos
{
    [RestService("/version")]
    public class Version
    {
        public string No { get; set; }
    }
}
