using NUnit.Framework;
using Tests.SmokeTest.Core;
using Tests.SmokeTest.PageObjects;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class LoginTest
    {
        private SeleniumScope _scope;
        private INavigator _navigator;

        [TestFixtureSetUp]
        public void Setup()
        {
            _scope = new SeleniumScope();
            _navigator = new Navigator(_scope.Selenium);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _scope.Dispose();
        }

        [Test]
        public void LoginSuccessWithCorrectPassword()
        {
            var login = _navigator.Open<LoginPage>();

            login.User.SetText("admin");
            login.Password.SetText("god");

            _navigator.Navigate<HomePage>(login.ClickLogin);
        }

        [Test]
        public void LoginWrongWithWrongPassword()
        {
            var login = _navigator.Open<LoginPage>();

            login.User.SetText("admin");
            login.Password.SetText("incorrectPwd");

            login = _navigator.Navigate<LoginPage>(login.ClickLogin);

            Assert.That(login.Message.GetText(), Is.EqualTo("Username and password do not match."));
        }
    }
}
