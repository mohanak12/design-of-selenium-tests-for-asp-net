using System;
using Tests.SmokeTest.Core;
using Tests.SmokeTest.PageObjects;

namespace Tests.SmokeTest.Flows
{
    public class StartFlow : FlowBase, IDisposable
    {
        public StartFlow(INavigator navigator)
            : base(navigator)
        { }

        public LoginPageFlow GoToLoginPage()
        {
            var loginPage = Navigator.Open<LoginPage>();

            return new LoginPageFlow(Navigator, loginPage);
        }

        public HomePageFlow LoginAndGoToHomePage()
        {
            return GoToLoginPage()
                .EnterValidCredentials()
                .Login();
        }

        public void Dispose()
        {
            Navigator.Dispose();
        }
    }
}
