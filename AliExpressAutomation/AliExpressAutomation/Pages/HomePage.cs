using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AliExpressAutomation.Pages
{
    /// <summary>
    /// Home Page with Page Object Pattern
    /// </summary>
    public class HomePage
    {
        private string TxtSearch => "search-key";
        private string BtnSearch => ".search-button";
        private string BtnClose => ".btn-close";
        private string CouponLayer => ".poplayer-content";

        public IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public HomePage SetSearch(string searchText)
        {
            driver.FindElement(By.Id(TxtSearch)).SendKeys(searchText);
            return this;
        }

        public HomePage CloseAdvertisement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(CouponLayer)));
            if (element.Displayed)
            {
                driver.FindElement(By.CssSelector(BtnClose)).Click();
            }

            return this;
        }

        public SearchPage ClickSearchButton()
        {
            driver.FindElement(By.CssSelector(BtnSearch)).Click();
            return new SearchPage(driver);
        }
    }
}
