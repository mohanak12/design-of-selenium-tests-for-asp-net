using Selenium;

namespace Tests.SmokeTest.PageObjects.Controls
{
    public class ControlBase
    {
        private readonly ISelenium _selenium;

        public ControlBase(ISelenium selenium)
        {
            _selenium = selenium;
        }

        protected ISelenium Selenium
        {
            get
            {
                return _selenium;
            }
        }
    }
}