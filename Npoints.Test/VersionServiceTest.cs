
using NUnit.Framework;
using Npoints.Service.Dtos;
using Npoints.Service.Services;

namespace Npoints.Test
{
    [TestFixture]
    public class VersionServiceTest
    {
        VersionService service = null;

        [SetUp]
        public void Setup()
        {
            service = new VersionService();
        }

        [Test]
        public void TestOnBeforeExecute()
        {
           Version version = service.OnGet(null) as Version;
           Assert.IsNotNull(version);
           Assert.AreEqual("1.0.0.0", version.No);
        }
    }
}
