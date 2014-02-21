using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium.Utils
{
    public static class WebBrowser
    {
        /// <summary>
        /// Path to the directory where IEDriver for Selenium can be found.
        /// </summary>
        private const string IeDriverPath = @"..\..\Tools\IEDriver";

        /// <summary>
        /// Base Url used by the website in development phase (IIS Express).
        /// </summary>
        public const string BaseUrl = "http://localhost:28231/";

        /// <summary>
        /// Gets the active browser for this scenario. Opens one if one is not already open.
        /// </summary>
        public static IWebDriver Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    IWebDriver driver = new InternetExplorerDriver(IeDriverPath);
                    ScenarioContext.Current["browser"] = driver;
                }
                return ScenarioContext.Current["browser"] as IWebDriver;
            }
        }

        /// <summary>
        /// Closes the active browser for this scenario.
        /// </summary>
        public static void Close()
        {
            var driver = ScenarioContext.Current["browser"] as IWebDriver;

            Debug.Assert(driver != null, "driver != null");
            driver.Quit();

            ScenarioContext.Current.Remove("browser");

        }
    }
}

