using AliExpressAutomation.Framework.Common;
using AliExpressAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpressAutomation.Tests
{
    [TestFixture]
    public class TC01BuyAvailableItem
    {
        public BrowserManager browser;

        [SetUp]
        public void SetUp()
        {
            browser = BrowserManager.Instance;
            browser.OpenBrowser();
            browser.GoTo();
        }

        [Test]
        public void TC01ExistAvailableItem()
        {
            new HomePage(browser.WebDriver)
                .CloseAdvertisement()
                .SetSearch("Iphone")
                .ClickSearchButton()
                .GoToPage("2")
                .SelectAdItemFromList("2");
        }

        [Test]
        public void TC02QuantityIsMayorThanCero()
        {
            new HomePage(browser.WebDriver)
                .SetSearch("Iphone")
                .ClickSearchButton()
                .ClickNextButton()
                .GoToPage("2");
        }
    }
}
