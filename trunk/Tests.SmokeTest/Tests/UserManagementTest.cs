using MbUnit.Framework;
using Tests.SmokeTest.Core;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class UserManagementTest : TestBase
    {
        [Test]
        public void NewlyAddedUserAppearsInUsersList()
        {
            using (var start = GetStart())
            {
                start
                    .LoginAndGoToHomePage()
                    .AddUser("TestUser", "TestPassword")
                    .AssertThatUserListContains("TestUser", "TestPassword");
            }
        }

        [Test]
        public void NewlyAddedUserCanLoginInSystem()
        {
            using (var start = GetStart())
            {
                start
                    .LoginAndGoToHomePage()
                    .AddUser("TestUserForLogin", "TestPwdForLogin")
                    .Logout()
                    .EnterCredentials("TestUserForLogin", "TestPwdForLogin")
                    .Login();
            }
        }

        [Test]
        public void InsertionOfDuplicateUserFailed()
        {
            using (var start = GetStart())
            {
                start
                    .LoginAndGoToHomePage()
                    .EnterNewUserNameAndPassword("admin", "Whatever")
                    .ClickOnAddUser()
                    .AssertErrorMessage("User with name 'admin' already exists");
            }
        }
    }
}
