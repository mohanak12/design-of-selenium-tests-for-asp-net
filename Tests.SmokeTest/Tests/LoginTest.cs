using NUnit.Framework;
using Tests.SmokeTest.Core;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        [Test]
        public void LoginSuccessWithCorrectPassword()
        {
            Start
                .GoToLoginPage()
                .EnterCredentials("admin", "god")
                .Login();
        }

        [Test]
        public void LoginWrongWithWrongPassword()
        {
            Start
                .GoToLoginPage()
                .EnterCredentials("admin", "incorrectPwd")
                .LoginShouldFail()
                .AssertMessage("Username and password do not match.");
        }
    }
}