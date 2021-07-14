using AliExpressAutomation.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliExpressAutomation.Pages
{
    /// <summary>
    /// Search Page with Page Object Pattern
    /// </summary>
    public class SearchPage
    {
        private string BtnNext => "button[aria-label^='Next page']";
        private string TxtGoToPage => "input[aria-label='Large']";
        private string BtnGo => ".jump-btn";
        private string AdItemList => "._1OUGS";
        private string Backdrop => ".next-overlay-backdrop";

        public IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public SearchPage ClickNextButton()
        {
            BrowserManager.Instance.ScrollDownOnPage();
            driver.FindElement(By.CssSelector(BtnNext)).Click();
            return this;
        }

        public SearchPage GoToPage(string pageToNavigate)
        {
            // ScrollDown to find Element
            BrowserManager.Instance.ScrollDownOnPage();
            var element = driver.FindElement(By.CssSelector(TxtGoToPage));
            element.SendKeys(pageToNavigate);

            // Click Go Button
            driver.FindElement(By.CssSelector(BtnGo)).Click();

            return this;
        }

        public ItemPage SelectAdItemFromList(string itemNumber)
        {
            // Collecting All Elements from Page
            List<IWebElement> listItems = driver.FindElements(By.CssSelector(AdItemList)).ToList();
            var element = listItems.ElementAt(Convert.ToInt32(itemNumber) - 1);

            // Wait for backdrop is not present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(Backdrop)));

            // Scroll the page till the element is found
            BrowserManager.Instance.ScrollDownOnPage(element);

            // Click on Selected Item
            element.Click();

            return new ItemPage(driver);
        }
    }
    
}
