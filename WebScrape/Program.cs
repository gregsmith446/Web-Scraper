using System;
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

            // use web driver to go to yahoo login page
            driver.Navigate().GoToUrl("https://login.yahoo.com/?.src=fpctx&.intl=us&.lang=en-US&authMechanism=primary&done=https%3A%2F%2Fwww.yahoo.com%2F&eid=100&as=1&login=gregsmith446%40intracitygeeks.org&crumb=BWJEvS0MDbD"); //IWebDriver driver = new ChromeDriver(".");


            // use element class selector to select username input box
            IWebElement login = driver.FindElement(By.Name("username"));
            //login.SendKeys("gregsmith446@intracitygeeks.org");
            login.Submit(); //submit the login email

            // wait for the next page to load
            WebDriverWait plzwait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            plzwait.Until(drv => drv.FindElement(By.Id("login-passwd")));

            // before typing in the password
            IWebElement pword = driver.FindElement(By.Id("login-passwd"));
            pword.SendKeys("SILICONrhode1!");
            // and cicking the login button
            driver.FindElement(By.Id("login-signin")).Click();

            // Wait for Yahoo Main Page to Load
            WebDriverWait waitAgain = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //plzwait.Until(drv => drv.FindElement(By.Id("login-passwd")));


            // After successful login, go to portfolio home page
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");

            Console.WriteLine();

            Console.WriteLine("Scrape on!");
        }
}
}

