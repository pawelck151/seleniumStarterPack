using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace StarterForSeleniumAutomation.Pages
{
    public abstract class Page
    {
        public IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public abstract void NavigateToPage(string parameter = "");
    }
}