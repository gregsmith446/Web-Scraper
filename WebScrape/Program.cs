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

            // use web driver to go to google
            driver.Navigate().GoToUrl("http://www.google.com"); //IWebDriver driver = new ChromeDriver(".");


            // use element class selector to type input into search box
            IWebElement query = driver.FindElement(By.Name("q")); //"q" is the name of the class on the input tag on google's HTML 

            //search term
            query.SendKeys("How do I internet?");
            query.Submit();

            Console.WriteLine("Scrape on!");
        }
}
}


