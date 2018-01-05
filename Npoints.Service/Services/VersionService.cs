using Newegg.API.Interfaces;
using Newegg.Oversea.DataAccess;
using Npoints.Service.Dtos;

using System.Reflection;

namespace Npoints.Service.Services
{
    public class VersionService : RestServiceBase<Version>
    {

        public override object OnGet(Version request)
        {
            DataCommand dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");
            dataCommand.ExecuteNonQuery(new[] { new { a = "lllll", b = 1, c = System.DateTime.Now, d = "amber", e = "amber", f = System.DateTime.Now } });
            return new Version
            {
                No = Assembly.GetExecutingAssembly().GetName().Version.ToString()

               
        };
        }


    }
}
