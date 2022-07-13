// <copyright file="LoginStepDefinitions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpecflowPlaywrightPOC.Steps;
using System;
using TechTalk.SpecFlow;

[Binding]
public class NewBaseType
{
    [Then(@"I should see the username with hello")]
    public static void ThenIshouldseetheusernamewithhello()
    {
        Console.WriteLine("Check user with hello");
    }
}

[Binding]
public class LoginStepDefinitions : NewBaseType
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginStepDefinitions"/> class.
    /// </summary>
    public LoginStepDefinitions()
    {
    }

    [Given(@"I have navigated to the application")]
    public static void GivenIhavenavigatedtotheapplication() => Console.WriteLine("Navigate to app");

    [Given(@"I see the application opened")]
    public static void GivenIseetheapplicationopened() => Console.WriteLine("I see app open");

    [When(@"I click the login link")]
    public static void WhenIclicktheloginlink() => Console.WriteLine("Click login");

    [When(@"I enter Username and Password")]
    public static void GivenIenterUsernameandPassword() => Console.WriteLine("Set username and password");

    [When(@"I click the login button")]
    public static void GivenIclicktheloginbutton() => Console.WriteLine("click login button");
}