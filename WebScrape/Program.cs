﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebScrape
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // link ChromeDriver.exe to program
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("test-type");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--ignore-certificate-errors");
            var driver = new ChromeDriver(@"/Users/gsmith/Desktop/Visual Studio Projects/WebScrape/WebScrape/bin/", options);

            Console.WriteLine("Scrape on!");

            // use web driver to go to yahoo finance page page
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");

            // wait for the finance page to load
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // click the sign in button
            var signIn = driver.FindElementByXPath("//*[@id=\"pf-splash\"]/section/a");
            signIn.Click();

            // use element class selector to select username input box
            IWebElement login = driver.FindElement(By.Name("username"));
            login.SendKeys("gregsmith446@intracitygeeks.org");
            login.Submit(); //submit the login email

            // wait for password page to load
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // before typing in the password
            IWebElement pword = driver.FindElement(By.Id("login-passwd"));
            pword.SendKeys("SILICONrhode1!");
            driver.FindElement(By.Id("login-signin")).Click();

            // X-Out of the popup on the finance page
            var popUp = driver.FindElementByXPath("//*[@id=\"__dialog\"]/section/button");
            popUp.Click();
            Console.WriteLine("No More Popups");

            // navigate to the portfolio data
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");
        }
}
}

