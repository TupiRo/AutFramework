using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
            string driverVersion = ConfigurationManager.AppSettings["browserToExecute"];

            switch (driverVersion)
            {
                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                    chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
                    chromeOptions.AddUserProfilePreference("download.default_directory", Path.GetTempPath());
                    instance = new ChromeDriver(chromeOptions);
                    break;
                case "Firefox":
                    instance = new FirefoxDriver();
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
