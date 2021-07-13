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
        public string txtQuantity => "input[aria-valuemax='4000']";

        public IWebDriver driver;
        public ItemPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public string GetQuantity()
        {
            var actualValue = driver.FindElement(By.CssSelector(txtQuantity)).Text;
            return actualValue;
        }

        public ItemPage SetTxtQuantity(string newValue)
        {
            driver.FindElement(By.CssSelector(txtQuantity)).SendKeys(newValue);
            return this;
        }
    }
}
