using AliExpressAutomation.Framework.Common;
using AliExpressAutomation.Pages;
using NUnit.Framework;

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
        public void TC01ExistsAvailableItemToBuy()
        {
            var itemPage = new HomePage(browser.WebDriver)
                .CloseAdvertisement()
                .SetSearch("Iphone")
                .ClickSearchButton()
                .GoToPage("2")
                .SelectAdItemFromList("2");

            // Validations
            Assert.IsTrue(itemPage.IsQuantityGreaterThanCero());
            Assert.IsTrue(itemPage.IsBuyNowButtonAvailable());
        }

        [Test]
        public void TC02QuantityCannotBeUpatedToCero()
        {
            var itemPage = new HomePage(browser.WebDriver)
                .CloseAdvertisement()
                .SetSearch("Iphone")
                .ClickSearchButton()
                .ClickNextButton()
                .SelectAdItemFromList("2")
                .SetTxtQuantity("0");

            // Validations
            Assert.IsTrue(itemPage.IsQuantityGreaterThanCero());
            Assert.IsFalse(itemPage.IsMinusButtonEnabled());
        }

        [TearDown]
        public void TearDown()
        {
            browser.Close();
        }
    }
}
