using System;
using NUnit.Framework;
using Tests.SmokeTest.Core;
using Tests.SmokeTest.PageObjects;

namespace Tests.SmokeTest.Flows
{
    public class LoginPageFlow
    {
        private readonly INavigator _navigator;
        private readonly LoginPage _login;

        public LoginPageFlow(INavigator navigator, LoginPage login)
        {
            _navigator = navigator;
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
            var homePage = _navigator.Navigate<HomePage>(_login.ClickLogin);

            return new HomePageFlow(_navigator, homePage);
        }

        public LoginPageFlow LoginShouldFail()
        {
            var loginNew = _navigator.Navigate<LoginPage>(_login.ClickLogin);

            return new LoginPageFlow(_navigator, loginNew);
        }

        public void AssertMessage(string message)
        {
            Assert.That(_login.Message.GetText(), Is.EqualTo(message));
        }
    }
}