using NUnit.Framework;
using Tests.SmokeTest.Core;
using Tests.SmokeTest.PageObjects;

namespace Tests.SmokeTest.Flows
{
    public class HomePageFlow : FlowBase
    {
        private readonly HomePage _home;

        public HomePageFlow(INavigator navigator, HomePage home) 
            : base(navigator)
        {
            _home = home;
        }

        public HomePageFlow AssertUserName(string userName)
        {
            Assert.That(_home.UserName.GetText(), Is.EqualTo(userName));

            return this;
        }
    }
}
