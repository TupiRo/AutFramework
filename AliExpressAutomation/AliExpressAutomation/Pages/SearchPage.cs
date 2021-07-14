using AliExpressAutomation.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpressAutomation.Pages
{
    public class SearchPage
    {
        private string btnNext => "button[aria-label^='Next page']";
        private string txtGoToPage => "input[aria-label='Large']";
        private string btnGo => ".jump-btn";
        private string adItemList => "._1OUGS";
        private string backdrop => ".next-overlay-backdrop";

        public IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public SearchPage ClickNextButton()
        {
            driver.FindElement(By.CssSelector(btnNext)).Click();
            return this;
        }

        public SearchPage GoToPage(string pageToNavigate)
        {
            // ScrollDown to find Element
            BrowserManager.Instance.ScrollDownOnPage();
            var element = driver.FindElement(By.CssSelector(txtGoToPage));
            element.SendKeys(pageToNavigate);

            // Click Go Button
            driver.FindElement(By.CssSelector(btnGo)).Click();

            return this;
        }

        public ItemPage SelectAdItemFromList(string itemNumber)
        {
            // Collecting All Elements from Page
            List<IWebElement> listItems = driver.FindElements(By.CssSelector(adItemList)).ToList();
            var element = listItems.ElementAt(Convert.ToInt32(itemNumber) - 1);

            // Wait for backdrop is not present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(backdrop)));
            
            //This will scroll the page till the element is found		
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);

            // Click on Selected Item
            element.Click();

            return new ItemPage(driver);
        }
    }
    
}
