using TechTalk.SpecFlow;
using WatiN.Core;

namespace SFT.Features
{
    public class WebBrowser
    {
        public static string RootUrl
        {
            get { return "http://localhost:8090"; }
        }
        public static IE Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                    ScenarioContext.Current["browser"] = new IE();
                return ScenarioContext.Current["browser"] as IE;
            }
        }

        public static void NavigateTo(string relativeUrl)
        {
            var separator = relativeUrl.StartsWith("/") ? string.Empty : "/";
            Current.GoTo(RootUrl + separator + relativeUrl);
        }
    }
}