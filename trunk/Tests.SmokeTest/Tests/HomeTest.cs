using NUnit.Framework;
using Tests.SmokeTest.Core;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class HomeTest : TestBase
    {
        [Test]
        public void CheckCurrentUserName()
        {
            Start
                .LoginAndGoToHomePage()
                .AssertUserName("admin");
        }

        
    }
}
