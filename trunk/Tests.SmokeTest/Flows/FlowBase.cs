using Tests.SmokeTest.Core;

namespace Tests.SmokeTest.Flows
{
    public class FlowBase
    {
        private readonly INavigator _navigator;

        public FlowBase(INavigator navigator)
        {
            _navigator = navigator;
        }

        public INavigator Navigator
        {
            get { return _navigator; }
        }
    }
}