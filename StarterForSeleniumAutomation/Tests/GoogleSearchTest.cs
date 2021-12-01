using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StarterForSeleniumAutomation.Tests
{
    [TestClass]
    public class GoogleSearchTest : BaseTest
    {
        #region Fields
        private string SText = "Test";
        #endregion Fields

        #region Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            testContextInstance = context;
        }

        [TestMethod]
        public void GoogleSearch()
        {
            homePage.SetInputSearchText(SText);
            homePage.ClickGoogleSearchButton();
            Assert.IsTrue(homePage.TextIsVisible(SText), "Search do not work correctly");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CloseBrowser();
        }

        [TestInitialize]
        public void TestInitialization()
        {
            LaunchBrowser();
        }

        #endregion Methods
    }
}
