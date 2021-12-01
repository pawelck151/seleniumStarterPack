using StarterForSeleniumAutomation.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using StarterForSeleniumAutomation.Pages;
using StarterForSeleniumAutomation.Enums;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace StarterForSeleniumAutomation.Tests
{
    [TestClass]
    public class BaseTest
    {
        #region Fields
        public static TestContext testContextInstance;
        protected BrowserType browserType;
        protected IWebDriver driver;
        protected HomePage homePage;
        #endregion Fields

        #region Properties

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion Properties

        #region Methods

        [TestCleanup]
        public void CloseBrowser()
        {
            //if (testContextInstance.CurrentTestOutcome != UnitTestOutcome.Passed)

            //{
            //    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            //    ss.SaveAsFile(@"C:\\");
            //}

            driver.Quit();
        }

        protected void LaunchBrowser()
        {
            browserType = ConstantTestProperties.BROWSER_TYPE;

            //change this path
            string driversPath = @"C:\Users\pawel.wojtak\Documents\Projects\SeleniumTestFrameWork\Common\Drivers\";

            if (browserType == BrowserType.FireFox)
            {
                FirefoxOptions options = new FirefoxOptions();
                options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
                driver = new FirefoxDriver();
            }
            else if (browserType == BrowserType.Chrome)
            {
                ChromeOptions options = new ChromeOptions();
                options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
                driver = new ChromeDriver(driversPath, options);
            }
            else if (browserType == BrowserType.IE)
            {
                InternetExplorerOptions options = new InternetExplorerOptions()
                {
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                };
                driver = new InternetExplorerDriver(driversPath, options);
            }

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConstantStrings.GetUrl());
            driver.Manage().Logs.GetLog(LogType.Browser);

            homePage = new HomePage(driver);
        }

        #endregion Methods
    }
}
