using NUnit.Framework;
using Tests.SmokeTest.Tests;

namespace Tests.SmokeTest
{
    [SetUpFixture]
    public class SetUpSUT
    {
        [SetUp]
        public void CleanUpStorage()
        {
            SetUpTest.CleanUp();
        }
    }
}