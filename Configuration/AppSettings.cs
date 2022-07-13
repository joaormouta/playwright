using System.Web;

namespace SpecflowPlaywrightPOC.Configuration
{
    public static class AppSettings
    {
        public static string TestEnvironment => GetAppString("TestEnvironment");
        public static string TestCountry => GetAppString("TestCountry");
        public static string ApplicationUrl => GetAppString("ApplicationUrl");
        public static string ApplicationHttpScheme => GetAppString("ApplicationHttpScheme");
        public static string ApplicationUrlDomain => GetAppString("ApplicationUrlDomain");
        public static int CommandTimeout => int.Parse(GetAppString("CommandTimeout"));
        public static int PageLoadTimeout => int.Parse(GetAppString("PageLoadTimeout"));
        public static int TimeoutClickable => int.Parse(GetAppString("TimeoutClickable"));
        public static int TimeoutVisible => int.Parse(GetAppString("TimeoutVisible"));
        public static int TimeoutInvisible => int.Parse(GetAppString("TimeoutInvisible"));
        private static string GetAppString(string name) => $"WebConfigurationManager.AppSettings[{name}]";
    }
}
