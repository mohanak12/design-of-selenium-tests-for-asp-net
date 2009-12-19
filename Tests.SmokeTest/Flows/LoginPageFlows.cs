using MbUnit.Framework;
using Tests.SmokeTest.Core;
using Tests.SmokeTest.PageObjects;

namespace Tests.SmokeTest.Flows
{
    public class LoginPageFlow : FlowBase
    {
        private readonly LoginPage _login;

        public LoginPageFlow(INavigator navigator, LoginPage login)
            : base(navigator)
        {
            _login = login;
        }

        public LoginPageFlow EnterCredentials(string name, string password)
        {
            _login.User.SetText(name);
            _login.Password.SetText(password);

            return this;
        }

        public LoginPageFlow EnterValidCredentials()
        {
            return EnterCredentials("admin", "god");
        }

        public HomePageFlow Login()
        {
            var homePage = Navigator.Navigate<HomePage>(_login.ClickLogin);

            return new HomePageFlow(Navigator, homePage);
        }

        public LoginPageFlow LoginShouldFail()
        {
            var loginNew = Navigator.Navigate<LoginPage>(_login.ClickLogin);

            return new LoginPageFlow(Navigator, loginNew);
        }

        public void AssertMessage(string message)
        {
            Assert.AreEqual(message, _login.Message.GetText());
        }
    }
}