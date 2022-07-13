namespace SpecflowPlaywrightPOC.Pages.BasePages
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SpecflowPlaywrightPOC.Resources.Constants;
    using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

    public class BaseElementLocators
    {
        protected IWebDriver driver;
        protected WebDriverWait driverWait;

        internal BaseElementLocators(IWebDriver currentDriver)
        {
            driver = currentDriver;
            // DriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        }

        protected bool IsElementDisplayed(By target, bool continueIfNoElementIsFound)
        {
            try
            {
                var element = driverWait.Until(x => driver.FindElement(target));
                return element.Displayed;
            }
            catch (NoSuchElementException e)
            {
                if (!continueIfNoElementIsFound)
                {
                    Console.WriteLine("ERROR: Element was not detected on the current display: " + e.StackTrace);
                    throw;
                }

                return true;
            }
        }

        protected IWebElement GetElementBy(By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var target =
                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(by)));
            return target;
        }

        protected IWebElement GetElementById(string autoId)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var target =
                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.Id(autoId))));
            return target;
        }

        protected IWebElement GetElementByName(string name)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var target =
                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.Name(name))));
            return target;
        }

        protected IWebElement GetElementByXPath(string xpath)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var target =
                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath(xpath))));
            return target;
        }

        protected IWebElement GetElementByCssSelector(string css)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var target =
                wait.Until(ExpectedConditions.ElementToBeClickable(
                    driver.FindElement(By.CssSelector(css))));
            return target;
        }

        protected IWebElement GetElementByClass(string className)
        {
            var wait = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(30));
            var target =
                wait.Until(condition: ExpectedConditions.ElementToBeClickable(
                    driver.FindElement(By.ClassName(className))));
            return target;
        }

        protected IWebElement WaitUntilElementVisible(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("ERROR: Element with locator '" + elementLocator + "' was not found.");
                throw;
            }
        }

        public IWebElement WaitUntilElementEnabled(By elementLocator, int timeout = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("ERROR: Element with locator '" + elementLocator + "' is not enabled.");
                throw;
            }
        }

        protected ReadOnlyCollection<IWebElement> GetElementsList(By collection)
        {
            return driver.FindElements(collection);
        }

        protected ReadOnlyCollection<IWebElement> GetElementsList(string identifierId)
        {
            return driver.FindElements(By.Id(identifierId));
        }

        protected ReadOnlyCollection<IWebElement> GetElementsListByClass(string className)
        {
            return driver.FindElements(By.ClassName(className));
        }

        protected IWebElement GetElementFromCollection(By collection, int targetIndex)
        {
            var targetCollection = GetElementsList(collection);
            return targetCollection[targetIndex];
        }

        protected IWebElement GetElementFromCollectionById(string identifierId, int targetIndex)
        {
            var collection = GetElementsList(identifierId);
            return collection[targetIndex];
        }

        protected IWebElement GetElementFromCollectionByClass(string identifierClassName, int targetIndex)
        {
            var collection = GetElementsListByClass(identifierClassName);
            return collection[targetIndex];
        }

        protected void WaitForJqueryAjax()
        {
            int delay = 20;
            while (delay > 0)
            {
                Thread.Sleep(Timeouts.DefaultUiTimeout);
                var jquery = (bool)(driver as IJavaScriptExecutor)
                    .ExecuteScript("return window.jQuery == undefined");
                if (jquery)
                {
                    break;
                }

                var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor)
                    .ExecuteScript("return window.jQuery.active == 0");
                if (ajaxIsComplete)
                {
                    break;
                }

                delay--;
            }
        }
    }
}