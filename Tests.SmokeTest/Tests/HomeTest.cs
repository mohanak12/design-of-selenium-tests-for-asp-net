using NUnit.Framework;
using Tests.SmokeTest.Core;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class HomeTest : TestBase
    {
        [Test]
        public void CheckCurrentUserName()
        {
            Start
                .LoginAndGoToHomePage()
                .AssertUserName("admin");
        }

        [Test]
        public void NewlyAddedUserAppearsInUsersListTest()
        {
            Start
                .LoginAndGoToHomePage()
                .EnterNewUserNameAndPassword("TestUser", "TestPassword")
                .ClickOnAddUser()
                .AssertErrorMessage("")
                .AssertThatUserListContains("TestUser", "TestPassword");
        }

        [Test]
        public void InsertionOfDuplicateUserFailedTest()
        {
            Start
                .LoginAndGoToHomePage()
                .EnterNewUserNameAndPassword("admin", "Whatever")
                .ClickOnAddUser()
                .AssertErrorMessage("User with name 'admin' already exists");
        }
    }
}
