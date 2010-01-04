using Tests.SmokeTest.Core;
using MbUnit.Framework;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class HomeTest : TestBase
    {
        [Test]
        public void CheckCurrentUserName()
        {
            using (var start = GetStart())
            {
                start
                    .LoginAndGoToHomePage()
                    .AssertUserName("admin");
            }
        }
    }
}