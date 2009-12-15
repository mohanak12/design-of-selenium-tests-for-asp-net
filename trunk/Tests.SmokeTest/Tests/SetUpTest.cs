using NUnit.Framework;
using Tests.SmokeTest.Core;
using Tests.SmokeTest.PageObjects;

namespace Tests.SmokeTest.Tests
{
    [TestFixture]
    public class SetUpTest
    {
        public static void CleanUp()
        {
            using (var navigator = new Navigator())
            {
                navigator.Start(Configuration.StorageAdminSiteUrl);
                var storageAdminPage = navigator.Open<StorageAdminPage>();
                storageAdminPage.ClickClear();
            }
        }

        [Test, Ignore]
        public void CleanUpStorage()
        {
            CleanUp();
        }
    }
}
