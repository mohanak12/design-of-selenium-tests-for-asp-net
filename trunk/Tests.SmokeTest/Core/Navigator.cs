using System;
using System.Configuration;
using System.IO;
using NUnit.Framework;
using Selenium;

namespace Tests.SmokeTest.Core
{
    public class Navigator : INavigator
    {
        private readonly ISelenium _selenium;

        private static string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteUrl"];
            }
        }

        public Navigator(ISelenium selenium)
        {
            _selenium = selenium;
        }

        public TT Open<TT>() where TT : PageBase, new()
        {
            var target = new TT();
            InitPage(target);

            _selenium.Open(Path.Combine(BaseUrl, target.PageUrl));


            
            WaitLoad(target);
            AssertCorrectPageLoaded(target);
            return target;
        }

        private void WaitLoad<TT>(TT target) where TT : PageBase
        {
            _selenium.WaitForPageToLoad("120000");
        }

        private void AssertCorrectPageLoaded<TT>(TT target) where TT : PageBase
        {
            var location = _selenium.GetLocation();
            var paramsStart = location.IndexOf('?');

            if (paramsStart >= 0)
            {
                location = location.Substring(0, paramsStart);
            }

            if (!location.EndsWith(target.PageUrl))
            {
                Assert.Fail("Expected URL {0} but was {1}", target.PageUrl, location);
            }
        }

        public TT Navigate<TT>(Action action) where TT : PageBase, new()
        {
            return Navigate<TT>(action, false);
        }

        public TT Navigate<TT>(Action action, bool chooseOkOnConfirmation) where TT : PageBase, new()
        {
            var target = new TT();
            InitPage(target);

            if (chooseOkOnConfirmation) _selenium.ChooseOkOnNextConfirmation();

            action();

            if (chooseOkOnConfirmation)
            {
                if (_selenium.IsConfirmationPresent())
                {
                    _selenium.GetConfirmation();
                }
            }

            WaitLoad(target);
            if (target.Selenium.GetBodyText().Contains("Server Error in "))
            {
                Assert.Fail(String.Format("Server error while navigating\r\n\r\n {0}.", (object)target.Selenium.GetBodyText()));
            }

            AssertCorrectPageLoaded(target);

            return target;
        }

        private void InitPage<TT>(TT target) where TT : PageBase
        {
            target.Selenium = _selenium;
        }
    }
}