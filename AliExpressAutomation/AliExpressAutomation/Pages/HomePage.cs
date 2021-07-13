using AliExpressAutomation.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpressAutomation.Pages
{
    public class HomePage
    {
        public string txtSearch => "search-key";
        public string btnSearch => ".search-button";

        public IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage SetSearch(string searchText)
        {
            driver.FindElement(By.Id(txtSearch)).SendKeys(searchText);
            return this;
        }

        public SearchPage ClickSearchButton()
        {
            driver.FindElement(By.CssSelector(btnSearch)).Click();
            return new SearchPage();
        }
    }
}
