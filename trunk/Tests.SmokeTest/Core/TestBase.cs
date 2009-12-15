using NUnit.Framework;
using Tests.SmokeTest.Flows;

namespace Tests.SmokeTest.Core
{
    public class TestBase
    {
        private INavigator _navigator;
        private StartFlow _startFlow;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var navigator = new Navigator();
            navigator.Start(Configuration.SiteUrl);

            _navigator = navigator;
            _startFlow = new StartFlow(_navigator);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _navigator.Dispose();
        }

        public INavigator Navigator
        {
            get { return _navigator; }
        }

        public StartFlow Start
        {
            get { return _startFlow; }
        }
    }
}