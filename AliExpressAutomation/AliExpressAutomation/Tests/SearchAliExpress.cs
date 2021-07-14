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
    public class SearchAliExpress
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
            var actualPage = new HomePage(browser.WebDriver)
                .CloseAdvertisement()
                .SetSearch("Iphone")
                .ClickSearchButton()
                .GoToPage("2")
                .SelectAdItemFromList("2");

            // Validations
            Assert.IsTrue(actualPage.IsQuantityGreaterThanCero());
            Assert.IsTrue(actualPage.IsBuyNowButtonAvailable());
        }

        [Test]
        public void TC02QuantityCannotBeUpatedToCero()
        {
            new HomePage(browser.WebDriver)
                .SetSearch("Iphone")
                .ClickSearchButton()
                .ClickNextButton()
                .GoToPage("2");
        }
    }
}
