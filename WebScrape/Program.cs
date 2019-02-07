using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data.SqlClient;

namespace WebScrape
{
    class Program
    {
        internal static void Main(string[] args)
        {
                // link ChromeDriver.exe to program
                ChromeOptions options = new ChromeOptions();
                // options.AddArgument("--headless");
                options.AddArguments("test-type");
                options.AddArgument("--disable-popup-blocking");
                options.AddArgument("--ignore-certificate-errors");
                var driver = new ChromeDriver(@"\Users\gregs\Desktop\CD\WebScrape\WebScrape\bin", options);

                Console.WriteLine("Scraper starting to navigate to data!");

            // Step 1
            // use web driver to go to yahoo finance page page
            driver.Navigate().GoToUrl("https://login.yahoo.com/config/login?.src=finance&.intl=us&.done=https%3A%2F%2Ffinance.yahoo.com%2Fportfolios");
            // wait for the finance page to load

            // Step 2
            // use element class selector to select username input box
            IWebElement login = driver.FindElement(By.Name("username"));
            login.SendKeys("gregsmith446@intracitygeeks.org");
            login.Submit(); //submit the login email
            Console.WriteLine("navigated to login page");

            // Step 3
            // wait for password page to load
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // before typing in the password
            IWebElement pword = driver.FindElement(By.Id("login-passwd"));
            pword.SendKeys("SILICONrhode1!");
            driver.FindElement(By.Id("login-signin")).Click();
            Console.WriteLine("navigated to password page");

            // Re-navigate to the portfolio data
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view");
            Console.WriteLine("you are now on the portfolio page begin getting data");

            // Step 4
            // X-Out of the popup on the finance page
            var popUp = driver.FindElementByXPath("//*[@id=\"__dialog\"]/section/button");
            popUp.Click();
            Console.WriteLine("Popup has been closed.");
                
            // Step 5 - locate stock data table and its rows
            // Find table with stock data
            IWebElement table = driver.FindElement(By.ClassName("_1TagL"));

            // Find all rows in the table and assign to a list
            IList<IWebElement> rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
            String strRowData = "";

                // Step 6 - loop through rows in table to only get columns
                for (int j = 1; j < rows.Count; j++)
                {
                    // During the loop, get the columns from a particular row and set = 1stTdElem, a list
                    List<IWebElement> lstTdElem = new List<IWebElement>(rows[j].FindElements(By.TagName("td")));

                    if (lstTdElem.Count > 0)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            strRowData = strRowData + lstTdElem[i].Text + ",";
                        }
                    }
                    else
                    {
                        // To print the data into the console and add comma between text
                        Console.WriteLine(rows[0].Text.Replace(" ", ","));
                    }
                }

                // Print the data to the console
                System.Console.WriteLine(strRowData);
        }
    }
}