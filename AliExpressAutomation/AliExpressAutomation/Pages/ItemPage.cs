using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpressAutomation.Pages
{
    public class ItemPage
    {
        public string txtQuantity => "input[value='1']";
        public string btnBuyNow => "button[class$='buynow']";

        public IWebDriver driver;
        public ItemPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public string GetQuantity()
        {
            var actualValue = driver.FindElement(By.CssSelector(txtQuantity)).GetAttribute("value");
            return actualValue;
        }

        public ItemPage SetTxtQuantity(string newValue)
        {
            driver.FindElement(By.CssSelector(txtQuantity)).SendKeys(newValue);
            return this;
        }

        public bool IsQuantityGreaterThanCero()
        {
            int actualValue = Convert.ToInt32(GetQuantity());
            return actualValue > 0 ? true : false;
        }

        public bool IsBuyNowButtonAvailable()
        {
            return driver.FindElement(By.CssSelector(btnBuyNow)).Enabled;
        }
    }
}
