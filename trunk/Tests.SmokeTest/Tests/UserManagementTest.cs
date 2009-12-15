using NUnit.Framework;
using Tests.SmokeTest.Core;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class UserManagementTest : TestBase
    {
        [Test]
        public void NewlyAddedUserAppearsInUsersList()
        {
            Start
                .LoginAndGoToHomePage()
                .AddUser("TestUser", "TestPassword")
                .AssertThatUserListContains("TestUser", "TestPassword");
        }

        [Test]
        public void NewlyAddedUserCanLoginInSystem()
        {
            Start
                .LoginAndGoToHomePage()
                .AddUser("TestUserForLogin", "TestPwdForLogin")
                .Logout()
                .EnterCredentials("TestUserForLogin", "TestPwdForLogin")
                .Login();
        }

        [Test]
        public void InsertionOfDuplicateUserFailed()
        {
            Start
                .LoginAndGoToHomePage()
                .EnterNewUserNameAndPassword("admin", "Whatever")
                .ClickOnAddUser()
                .AssertErrorMessage("User with name 'admin' already exists");
        }
    }
}
