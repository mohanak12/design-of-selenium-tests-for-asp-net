using System;
using Selenium;

namespace Tests.SmokeTest.PageObjects.Controls
{
    public class Checkbox : ControlBase
    {
        private readonly string _selector;

        public Checkbox(ISelenium selenium, string selector)
            : base(selenium)
        {
            _selector = selector;
        }

        public bool Value
        {
            get
            {
                return Boolean.Parse(Selenium.GetValue(_selector));
            }
            set
            {
                if (value)
                {
                    Selenium.Check(_selector);
                }
                else
                {
                    Selenium.Uncheck(_selector);
                }
            }
        }
        public void Click()
        {
            Selenium.Click(_selector);
        }
    }
}