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
    public class HomePage
    {
        private string txtSearch => "search-key";
        private string btnSearch => ".search-button";
        private string btnClose => ".btn-close";

        public IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public HomePage SetSearch(string searchText)
        {
            driver.FindElement(By.Id(txtSearch)).SendKeys(searchText);
            return this;
        }

        public HomePage CloseAdvertisement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(btnClose)));
            if (element.Displayed)
            {
                element.Click();
            }

            return this;
        }

        public SearchPage ClickSearchButton()
        {
            driver.FindElement(By.CssSelector(btnSearch)).Click();
            return new SearchPage(driver);
        }
    }
}
