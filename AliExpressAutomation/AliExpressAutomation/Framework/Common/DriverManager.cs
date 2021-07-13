using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpressAutomation.Framework.Common
{
    /// <summary>
    /// Driver Manager Class
    /// </summary>
    public class DriverManager
    {
        /// <summary>
        /// Method to create Driver Instance
        /// </summary>
        public IWebDriver DriverFactory()
        {
            IWebDriver instance;
            string driverVersion = ConfigurationManager.AppSettings["BrowserToExecuteTests"];

            switch (driverVersion)
            {
                case "Firefox":
                    instance = new FirefoxDriver();
                    break;
                case "Chrome":
                    instance = new ChromeDriver();
                    break;
                case "IE":
                    instance = new InternetExplorerDriver();
                    break;
                case "Edge":
                    instance = new EdgeDriver();
                    break;
                default:
                    instance = new ChromeDriver();
                    break;
            }

            return instance;
        }
    }
}
