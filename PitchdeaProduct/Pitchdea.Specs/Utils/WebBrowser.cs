using TechTalk.SpecFlow;
using WatiN.Core;

namespace Pitchdea.Specs.Utils
{
    public static class WebBrowser
    {
        public const string FireFoxPath = "..\\..\\FirefoxPortableLegacy20\\FirefoxPortable.exe";
        public const string BaseUrl = "http://localhost:28231/";

        public static FireFox Current
        {
            get
            {
                FireFox.PathToExe = FireFoxPath;

                if (!ScenarioContext.Current.ContainsKey("browser"))
                    ScenarioContext.Current["browser"] = new FireFox();
                return ScenarioContext.Current["browser"] as FireFox;
            }
        }
    }
}