using NUnit.Framework;
using Tests.SmokeTest.Flows;

namespace Tests.SmokeTest.Core
{
    public class TestBase
    {
        private INavigator _navigator;
        private StartFlow _startFlow;

        [TestFixtureSetUp]
        public void Setup()
        {
            var navigator = new Navigator();
            navigator.Start(Configuration.SiteUrl);

            _navigator = navigator;
            _startFlow = new StartFlow(_navigator);
        }

        [TestFixtureTearDown]
        public void TearDown()
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