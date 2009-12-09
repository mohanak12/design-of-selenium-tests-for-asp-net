using Tests.SmokeTest.Core;
using Tests.SmokeTest.PageObjects;

namespace Tests.SmokeTest.Flows
{
    public class StartFlow
    {
        private readonly INavigator _navigator;

        public StartFlow(INavigator navigator)
        {
            _navigator = navigator;
        }

        public LoginPageFlow GoToLoginPage()
        {
            var loginPage = _navigator.Open<LoginPage>();

            return new LoginPageFlow(_navigator, loginPage);
        }

        public HomePageFlow LoginAndGoToHomePage()
        {
            return GoToLoginPage()
                .EnterValidCredentials()
                .Login();
        }
    }
}
