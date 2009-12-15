using System;
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
            Navigator.WaitForText(_home.UserName.GetSelector);

            Assert.That(_home.UserName.GetText(), Is.EqualTo(userName));

            return this;
        }

        public LoginPageFlow Logout()
        {
            var loginNew = Navigator.Navigate<LoginPage>(_home.ClickLogout);

            return new LoginPageFlow(Navigator, loginNew);
        }


        public HomePageFlow AddUser(string userName, string password)
        {
            EnterNewUserNameAndPassword(userName, password);
            ClickOnAddUser();
            AssertErrorMessage("");

            return this;
        }

        public HomePageFlow EnterNewUserNameAndPassword(string userName, string password)
        {
            _home.Name.SetText(userName);
            _home.Password.SetText(password);

            return this;
        }

        public HomePageFlow ClickOnAddUser()
        {
            Navigator.ClickAndWaitForJQuery(_home.ClickAddUser);

            return this;
        }

        public HomePageFlow AssertThatUserListContains(string name, string password)
        {
            var isExists = false;

            for (var i = 1; i <= _home.GetUserTableRowsCount(); i++)
            {
                var row = _home.GetUserTableRow(i);

                if(row.User.GetText() == name && row.Password.GetText() == password)
                {
                    isExists = true;
                }
            }

            Assert.That(isExists, Is.EqualTo(true), string.Format("User with name {0} and password {1} doesn't exists in user list table", name, password));

            return this;
        }

        public HomePageFlow AssertErrorMessage(string message)
        {
            Assert.That(_home.Error.GetText(), Is.EqualTo(message), "Error message while insertion of user is wrong.");

            return this;
        }
    }
}
