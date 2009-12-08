using System;
using System.Configuration;
using Selenium;

namespace Tests.SmokeTest.Core
{
    public class SeleniumScope : IDisposable
    {
        private readonly ISelenium _selenium;

        public SeleniumScope()
        {
            _selenium = new DefaultSelenium(SeleniumHost, SeleniumPort, "*firefox", SiteUrl);
            _selenium.Start();
            _selenium.SetTimeout("120000");
        }

        private string SiteUrl
        {
            get { return ConfigurationManager.AppSettings["SiteUrl"]; }
        }

        private string SeleniumHost
        {
            get { return ConfigurationManager.AppSettings["SeleniumHost"]; }
        }

        private int SeleniumPort
        {
            get { return Int32.Parse(ConfigurationManager.AppSettings["SeleniumPort"]); }
        }

        public ISelenium Selenium
        {
            get { return _selenium; }
        }

        public void Dispose()
        {
            _selenium.Stop();
        }
    }
}