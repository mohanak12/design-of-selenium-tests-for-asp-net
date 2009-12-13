using System;

namespace Tests.SmokeTest.Core
{
    public interface INavigator : IDisposable 
    {
        TT Open<TT>() where TT : PageBase, new();
        TT Navigate<TT>(Action action) where TT : PageBase, new();
        void WaitForText(string selector);
    }
}