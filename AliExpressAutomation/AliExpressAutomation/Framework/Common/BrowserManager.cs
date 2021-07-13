using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpressAutomation.Framework.Common
{
    /// <summary>
    /// The browser manager.
    /// </summary>
    public class BrowserManager
    {
        /// <summary>
        /// The singleton browser manager instance.
        /// </summary>
        private static BrowserManager _instance;

        /// <summary>
        /// The web driver.
        /// </summary>
        public IWebDriver WebDriver { get; private set; }

        /// <summary>
        /// The URL
        /// </summary>
        public string Url => ConfigurationManager.AppSettings["webUrl"];

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="browser">The browser name.</param>
        private BrowserManager()
        {
        }

        /// <summary>
        /// Gets the current browser manager instance.
        /// </summary>
        /// <returns>The browser manager.</returns>
        public static BrowserManager Instance
        {
            get
            {
                return _instance = _instance == null ? new BrowserManager() : _instance;
            }
        }

        /// <summary>
        /// Open a web browser.
        /// </summary>
        public void OpenBrowser()
        {
            WebDriver = new DriverManager().DriverFactory();
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Cookies.DeleteAllCookies();
        }

        /// <summary>
        /// Method to navigate to URL
        /// </summary>
        public void GoTo()
        {
            WebDriver.Navigate().GoToUrl(Url);
        }

        /// <summary>
        /// Close the web driver
        /// </summary>
        public void Close()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }

        /// <summary>
        /// ScrollDown in the Page
        /// </summary>
        public void ScrollDownOnPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
    }
}
