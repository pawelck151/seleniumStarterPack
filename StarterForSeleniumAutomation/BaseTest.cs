using StarterForSeleniumAutomation.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using StarterForSeleniumAutomation.Pages;
using StarterForSeleniumAutomation.Enums;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;

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
            SetWebDriverManger(browserType);

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
                driver = new ChromeDriver(options);
            }
            else if (browserType == BrowserType.Edge)
            {
                EdgeOptions options = new EdgeOptions();
                options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
                driver = new EdgeDriver(options);
            }

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConstantStrings.GetUrl());
            driver.Manage().Logs.GetLog(LogType.Browser);

            homePage = new HomePage(driver);
        }

        private void SetWebDriverManger(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    break;

                case BrowserType.Edge:
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    break;

                case BrowserType.FireFox:
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    break;

                default:
                    break;
            }
        }

        #endregion Methods
    }
}
