using Tests.SmokeTest.Flows;

namespace Tests.SmokeTest.Core
{
    public class TestBase
    {
        public StartFlow GetStart()
        {
            var navigator = new Navigator();
            navigator.Start(Configuration.SiteUrl);

            return new StartFlow(navigator);
        }
    }
}