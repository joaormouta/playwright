using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SpecflowPlaywrightPOC.Resources.Constants;
namespace SpecflowPlaywrightPOC.Utilities.Helpers
{
    public static class TestDataHelper
    {
        public static T LoadFromFile<T>(string testCountry, string testEnvironment,
            string subFolderNameInTypeDir, string fileName) where T : class
            {
            var testDataFolder = GetTestDataFolder(testCountry, testEnvironment);
            var typeFolder = Path.Combine(testDataFolder, typeof(T).Name);
            string pathToFile;
            if (string.IsNullOrWhiteSpace(subFolderNameInTypeDir))
            {
                pathToFile = Path.Combine(typeFolder, $"{fileName}.json");
            }
            else
            {
                pathToFile = Path.Combine(typeFolder, subFolderNameInTypeDir, $"{fileName}.json");
            }

            if (!File.Exists(pathToFile))
            {
                var errorMessage = $"No '{subFolderNameInTypeDir}' '{fileName}.json' TestData file exists at '{pathToFile}'";
                Console.WriteLine(errorMessage);
                Debug.WriteLine(errorMessage);
                return null;
            }

            var rawText = File.ReadAllText(pathToFile);
            var contexts = JsonConvert.DeserializeObject<T>(rawText, new StringEnumConverter());
            return contexts;
        }

        private static string GetTestDataFolder(string testCountry, string testEnvironment)
        {
            return Path.Combine(FileFolderConstantsForAllTests.ProjectDirectory,
                "TestData", testCountry, testEnvironment);
        }
    }
}