// <copyright file="DemoQABrowserWindowsActions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpecflowPlaywrightPOC.Pages.Demo;

using System.Threading.Tasks;
using Microsoft.Playwright;

public class DemoQABrowserWindowsActions : DemoQABrowserWindowsObjects
{
    private readonly IPage _page = null;

    public DemoQABrowserWindowsActions(IPage page)
    {
        _page = page;
    }

    public async Task ClickButton(string textButton)
    {
        await _page.ClickAsync(Button(textButton));
    }
}
