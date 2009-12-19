using MbUnit.Framework;
using Tests.SmokeTest.Core;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        [Test]
        public void LoginSuccessWithCorrectPassword()
        {
            using (var start = GetStart())
            {
                start
                    .GoToLoginPage()
                    .EnterCredentials("admin", "god")
                    .Login();
            }
        }

        [Test]
        public void LoginWrongWithWrongPassword()
        {
            using (var start = GetStart())
            {
                start
                    .GoToLoginPage()
                    .EnterCredentials("admin", "incorrectPwd")
                    .LoginShouldFail()
                    .AssertMessage("Username and password do not match.");
            }
        }
    }
}