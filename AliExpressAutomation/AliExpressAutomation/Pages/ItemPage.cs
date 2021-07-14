using AliExpressAutomation.Framework.Common;
using OpenQA.Selenium;
using System;

namespace AliExpressAutomation.Pages
{
    /// <summary>
    /// Item Page with Page Object Pattern
    /// </summary>
    public class ItemPage
    {
        public string TxtQuantity => ".next-input-group input";
        public string BtnBuyNow => "button[class$='buynow']";
        public string BtnMinus => "span[class$='next-before'] button";


        public IWebDriver driver;
        public ItemPage(IWebDriver driver)
        {
            this.driver = driver;
            BrowserManager.Instance.SwitchToAcualWindow();
        }

        public string GetQuantity()
        {
            var actualValue = driver.FindElement(By.CssSelector(TxtQuantity)).GetAttribute("value");
            return actualValue;
        }

        public ItemPage SetTxtQuantity(string newValue)
        {
            var element = driver.FindElement(By.CssSelector(TxtQuantity));

            // Setting element
            element.Clear();
            element.SendKeys(newValue + Keys.Tab);

            return this;
        }

        public bool IsQuantityGreaterThanCero()
        {
            int actualValue = Convert.ToInt32(GetQuantity());
            return actualValue > 0 ? true : false;
        }

        public bool IsBuyNowButtonAvailable()
        {
            return driver.FindElement(By.CssSelector(BtnBuyNow)).Enabled;
        }

        public bool IsMinusButtonEnabled()
        {
            return driver.FindElement(By.CssSelector(BtnMinus)).Enabled;
        }
    }
}
