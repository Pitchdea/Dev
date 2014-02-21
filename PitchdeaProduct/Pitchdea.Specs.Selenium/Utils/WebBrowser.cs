using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium.Utils
{
    public static class WebBrowser
    {
        public const string IeDriverPath = @"..\..\Tools\IEDriver";
        public const string BaseUrl = "http://localhost:28231/";

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

        public static void Close()
        {
            var driver = ScenarioContext.Current["browser"] as IWebDriver;

            Debug.Assert(driver != null, "driver != null");
            driver.Quit();

            ScenarioContext.Current.Remove("browser");

        }
    }
}

