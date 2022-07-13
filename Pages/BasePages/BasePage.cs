using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using SpecflowPlaywrightPOC.Hooks;

namespace SpecflowPlaywrightPOC.Pages.BasePages;

public abstract class BasePage
{
    // NOTE: THIS CLASS IS ONLY FOR SHARING THE DRIVER
    // AND GENERIC, SHARED FUNCTIONS. SUCH AS:
    // > WAITS
    // > CUSTOM CLICKS
    // > NON-SPECIFIC STATE ASSESSMENTS
    //
    // IT IS NOT A DUMPING GROUND FOR FUNCTIONS WHEN VWFS STAFF ARE "TOO BUSY" TO PROPERLY LOCATE A CLASS
    // NOR IS IT A "CONVENIENT LOCATION" TO DUMP A PAGE SPECIFIC ACTION

    // *[contains(@class,'CustomSelect')]
    // ReSharper disable once InconsistentNaming

    public readonly IPage _page;
    private readonly IBrowserContext _contextBrowser;
    protected BasePage(Context context)
    {
        _contextBrowser = context.BrowserContext;
        _page = context.Page;
    }

    /*   public void LoadPage(string pageToLoad) {
           // try {
           //           Driver.Url = pageToLoad;
           //           return true;
           //       } catch (Exception e) {
           //           Console.WriteLine("ERROR: Couldn't load the page: " + Driver.Url + " : " + e.StackTrace);
           //           return false;
           //       }
       } */

    public async Task<BasePage> ClickElement(string id)
    {
        await _page.Locator(id).ClickAsync();
        Thread.Sleep(500);
        return this;
    }

    public async Task<BasePage> ClickElementById(string id)
    {
        await _page.Locator($"id={id}").ClickAsync();
        Thread.Sleep(500);
        return this;
    }

    public async Task EnterText(string elementXpath, string text, int waitDuration = 500)
    {
        await _page.Locator(elementXpath).FillAsync(text);
        await _page.Keyboard.PressAsync("Tab");
        await WaitForRequest(waitDuration);
    }

    // public async Task EnterTextWithoutWaiting(string elementXpath, string text, int waitDuration = 500)
    // {
    //     await _page.Locator(elementXpath).FillAsync(text);
    //     await _page.Keyboard.PressAsync("Tab");
    //     await WaitForRequest(waitDuration);
    // }

    public async Task EnterTextById(string id, string text, int waitDuration = 500)
    {
        await _page.Locator($"id={id}").FillAsync(text);
        await _page.Keyboard.PressAsync("Tab");
        await WaitForRequest(waitDuration);
    }

    // public async Task EnterTextByIdWithOutWaiting(string id, string text, int waitDuration = 500)
    // {
    //     await _page.Locator($"id={id}").FillAsync(text);
    //     await _page.Keyboard.PressAsync("Tab");
    //     await WaitForRequest(waitDuration);
    // }

    public async Task EnterNumber(string elementXpath, string text, int waitDuration = 500)
    {
        await _page.Locator(elementXpath).FillAsync(text);
        await _page.Keyboard.PressAsync("Tab");
        await WaitForRequest(waitDuration);
    }

    public async Task SelectItemFromPosMenu(string target, string selection, int waitDuration = 500)
    {
        Thread.Sleep(waitDuration);
        await _page.Locator(target).ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        var selectedOption = _page.Locator($"//ul[@class='CustomSelect']/li[text()='{selection}']");
        await selectedOption.ClickAsync();
        await WaitForRequest(waitDuration);
    }

    // public async Task SelectItemFromPosMenuWithoutWaiting(string target, string selection, int waitDuration = 500)
    // {
    //     Thread.Sleep(waitDuration);
    //     await _page.Locator(target).ClickAsync();
    //     await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    //     var selectedOption = _page.Locator($"//ul[@class='CustomSelect']/li[text()='{selection}']");
    //     await selectedOption.ClickAsync();
    // }

    public async Task SelectItemFromPosMenuByID(string id, string selection, int waitDuration = 500)
    {
        Thread.Sleep(waitDuration);
        await _page.Locator($"id={id}").ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        var selectedOption = _page.Locator($"//ul[@class='CustomSelect']/li[text()='{selection}']");
        await selectedOption.ClickAsync();
        await WaitForRequest(waitDuration);
    }

    // public async Task SelectItemFromPosMenuByIDWithoutWaiting(string id, string selection, int waitDuration = 500)
    // {
    //     Thread.Sleep(waitDuration);
    //     await _page.Locator($"id={id}").ClickAsync();
    //     await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    //     var selectedOption = _page.Locator($"//ul[@class='CustomSelect']/li[text()='{selection}']");
    //     await selectedOption.ClickAsync();
    // }

    public async Task CloseTab()
    {
        await WaitForRequest(1000);
        await _contextBrowser.Pages[_contextBrowser.Pages.Count - 1].CloseAsync();
        await _contextBrowser.Pages[0].SetViewportSizeAsync(1920, 1080);
        // await _page.CloseAsync();
    }

    /*     protected bool EnterTextThenTab(By target, string text, int waitDuration = 0) {
             try {
                 WaitForJqueryAjax();
                 GetElementBy(target).SendKeys(text);
                 GetElementBy(target).SendKeys(Keys.Tab);
                 if (waitDuration != 0) Thread.Sleep(waitDuration);
                 WaitForJqueryAjax();
                 return true;
             } catch (NoSuchElementException e) {
                 Console.WriteLine("ERROR: Couldn't send keys to target: " + e.StackTrace);
                 throw;
             }
         }
         /*
                         protected bool ClearFieldEnterTextThenTab(By target, string text, int waitDuration = 0) {
                             try {
                                 WaitUntilElementEnabled(target);
                                 WaitUntilElementVisible(target);
                                 GetElementBy(target).Clear();
                                 GetElementBy(target).SendKeys(Keys.Tab);
                                 if (waitDuration != 0) Thread.Sleep(waitDuration);
                                 GetElementBy(target).SendKeys(text);
                                 GetElementBy(target).SendKeys(Keys.Tab);
                                 if (waitDuration != 0) Thread.Sleep(waitDuration);
                                 return true;
                             } catch (NoSuchElementException e) {
                                 Console.WriteLine("ERROR: Couldn't send keys to target: " + e.StackTrace);
                                 throw;
                             }
                         }

                         protected bool ClearField(By target, int waitDuration = 0) {
                             try {
                                 //WaitUntilElementEnabled(target);
                                 //WaitUntilElementVisible(target);
                                 WaitForJqueryAjax();
                                 GetElementBy(target).Clear();
                                 if (waitDuration != 0) Thread.Sleep(waitDuration);
                                 WaitForJqueryAjax();
                                 return true;
                             } catch (NoSuchElementException e) {
                                 Console.WriteLine("ERROR: Couldn't clear target: " + e.StackTrace);
                                 throw;
                             }

                         }

                         protected void MoveToElement(By target) {
                             try {
                                 var actions = new Actions(Driver);
                                 actions.MoveToElement(Driver.FindElement(target));
                                 actions.Perform();
                             } catch (NoSuchElementException e) {
                                 Console.WriteLine("ERROR: Couldn't move to the requested target: " + e.StackTrace);
                                 throw;
                             }
                         }

                         protected void SelectItemFromMenu(By target, string selection, int waitDuration = 0) {
                             try {
                                 //WaitUntilElementEnabled(target);
                                 //WaitUntilElementVisible(target);
                                 WaitForJqueryAjax();
                                 var menu = new SelectElement(Driver.FindElement(target));
                                 menu.SelectByText(selection);
                                 //WaitForPageToUpdate();
                                 WaitForJqueryAjax();
                                 if (waitDuration != 0) Thread.Sleep(waitDuration);
                             } catch (Exception e) {
                                 var allOptions = new SelectElement(Driver.FindElement(target)).Options.ToList();
                                 allOptions.ForEach(i => Console.Write("{0}\n", i.Text));
                                 Console.WriteLine("ERROR: Unable to select the requested item from your requested target menu: " +
                                                   e.StackTrace);
                                 throw;
                             }
                         }

                         protected void SelectItemFromMenu(By target, int selection, int waitDuration = 0) {
                             try {
                                 var menu = new SelectElement(Driver.FindElement(target));
                                 menu.SelectByIndex(selection);
                                 if (waitDuration != 0) Thread.Sleep(waitDuration);
                             } catch (Exception e) {
                                 Console.WriteLine("ERROR: Unable to select the requested item from your requested target menu: " +
                                                   e.StackTrace);
                                 throw;
                             }
                         }

                         protected void SelectItemFromCustomMenu(By target, string selection, int waitDuration = 0) {
                             try {
                                 //WaitUntilElementEnabled(target);
                                 //WaitUntilElementVisible(target);
                                 WaitForJqueryAjax();
                                 Driver.FindElement(target).Click();
                                 Thread.Sleep(500);

                                 var filter = By.XPath("//div[@class='CustomSelectFilter']/input");
                                 GetElementBy(filter).SendKeys(selection);
                                 Thread.Sleep(1000);

                                 GetElementBy(filter).SendKeys(Keys.Tab);

                                 WaitForJqueryAjax();
                                 if (waitDuration != 0) Thread.Sleep(waitDuration);
                             } catch (Exception e) {
                                 Console.WriteLine("ERROR: Unable to select the requested item from your requested target menu: " +
                                                   e.StackTrace);
                                 throw;
                             }
                         }

                         protected void SelectItemFromMenuThenTab(By target, string selection, int waitDuration = 0) {
                             try {
                                 //WaitUntilElementEnabled(target);
                                 //WaitUntilElementVisible(target);
                                 WaitForJqueryAjax();
                                 var menu = new SelectElement(Driver.FindElement(target));
                                 menu.SelectByText(selection);
                                 WaitForJqueryAjax();
                                 Driver.FindElement(target).SendKeys(Keys.Tab);
                                 if (waitDuration != 0) Thread.Sleep(waitDuration);
                             } catch (Exception e) {
                                 Console.WriteLine("ERROR: Unable to select the requested item from your requested target menu: " +
                                                   e.StackTrace);
                                 throw;
                             }
                         }

                         protected bool WaitUntilTargetContainsText(By target, string expectedText) {
                             try {
                                 var time = TimeSpan.FromSeconds(10);
                                 var wait = new WebDriverWait(Driver, time);
                                 wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(Driver.FindElement(target), expectedText)); //wait until it's true ffs'
                                 return true;
                             } catch (Exception e) {
                                 Console.WriteLine("ERROR: Target did not contain '" + expectedText + "' after waiting " +
                                                   e.StackTrace);
                                 throw;
                             }
                         }

                         protected void SwitchToWindowByHandle(string target) {
                             try {
                                 Driver.SwitchTo().Window(target);
                             } catch (Exception e) {
                                 Console.WriteLine("ERROR: Could not switch to a window with the handle '" + target + "': " + e.StackTrace);
                                 throw;
                             }
                         }

                         protected void SwitchToWindowByTitle(string target) {
                             try {
                                 if (!WindowWithThisTitleExists(Driver.WindowHandles, target)) {
                                     throw new NotFoundException(target);
                                 }

                             } catch (Exception e) {
                                 Console.WriteLine("ERROR: Could not switch to a window with the title '" + target + "': " + e.StackTrace);
                                 throw;
                             }
                         }

                         private bool WindowWithThisTitleExists(IEnumerable<string> handles, string target) {

                             foreach (var handle in handles) {
                                 if (Driver.SwitchTo().Window(handle).Title == target) {
                                     return true;
                                 }

                             }
                             return false;
                         }

                         protected bool GetCheckBoxStatus(By target) {
                             return Driver.FindElement(target).Selected;
                         }


                    //protected void WaitForPageToUpdate()
                    //{
                    //    //ContainerApplicationLoading might be the grey stuff
                    //    //ctl00_ctl00_ctl00_ctl00_UpdProgress
                    //    try
                    //    {
                    //        var time = TimeSpan.FromSeconds(1);
                    //        var wait = new WebDriverWait(Driver, time);
                    //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id("ctl00_ctl00_ctl00_ctl00_UpdProgress")) );
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Console.WriteLine("ERROR: Busy graphic is still visible " +
                    //                          e.StackTrace);
                    //        throw;
                    //    }
                    //}
                    */
    private async Task WaitForRequest(int waitDuration)
    {
        var updateProgress = _page.Locator("//div[@id='UpdProgress']");
        await updateProgress.WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Hidden });
        var cursor = _page.Locator("//body[@style='cursor: wait;']");
        await cursor.WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Detached });
        Thread.Sleep(waitDuration);
        // var response = await _page.WaitForResponseAsync(response => response.Url.Contains("aspx") && response.Status.Equals(200));
    }
}
