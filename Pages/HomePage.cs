using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using StarterForSeleniumAutomation.Constants;
using System.Collections.Generic;

namespace StarterForSeleniumAutomation.Pages
{
    public class HomePage : Page
    {
        #region IWebelements
#pragma warning disable 0649

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement InputSearchText { get; set; }

        [FindsBy(How = How.Name, Using = "btnK")]
        public IWebElement GoogleSearchButton { get; set; }

#pragma warning restore 0649
        #endregion IWebelements

        public HomePage(IWebDriver browser) : base(browser)
        { }

        public void SetInputSearchText(string text) => InputSearchText.SendKeys(text);

        public void ClickGoogleSearchButton() => GoogleSearchButton.Click();

        public bool TextIsVisible(string SearchText)
        {
            IList<IWebElement> elements = driver.FindElements(By.XPath("//*"));
            var result = false;
            foreach (var el in elements)
            {
                if (el.Text.Contains(SearchText))
                {
                    result = true;
                    break;
                }
                else result = false;
            }
            return result;
        }

        public override void NavigateToPage(string parameter = "")
        {
            driver.Navigate().GoToUrl(ConstantStrings.GetUrl());
        }
    }
}
