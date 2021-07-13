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
        public void TestMethod()
        {
            new HomePage(browser.WebDriver)
                .SetSearch("Iphone")
                .ClickSearchButton();
        }
    }
}
