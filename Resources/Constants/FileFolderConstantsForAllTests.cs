namespace SpecflowPlaywrightPOC.Resources.Constants
{
    using System;
    using System.IO;

    public static class FileFolderConstantsForAllTests
    {
        private static string WorkingDirectory => Environment.CurrentDirectory;
        public static string ProjectDirectory => Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;

        public static string RootDirectory => AppDomain.CurrentDomain.BaseDirectory;
    }
}
