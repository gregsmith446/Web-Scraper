using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

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
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");
            // wait for the finance page to load
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // click the sign in button
            IWebElement signIn = driver.FindElementByXPath("//*[@id=\"pf-splash\"]/section/a");
            signIn.Click();
            Console.WriteLine("navigated to portfolio page");

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

            // Step 4
            // X-Out of the popup on the finance page
            var popUp = driver.FindElementByXPath("//*[@id=\"__dialog\"]/section/button");
            popUp.Click();
            Console.WriteLine("Popup has been closed.");
            // navigate to the portfolio data
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");
            Console.WriteLine("you are now on the portfolio page begin getting data");
            // possible room for improvement --> optimize wait times by waiting for element specific to the functionality

            // Step 5
            // Get Table Headers Data, "thData", which describe what data is in each collumn below
            // the data will be stored in "strThdata" with each header separated by a comma

            // initialize variable to hold headers as strings
            String strThData = "";
            // get table header for stock symbols
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[1]")).Text + ",";
            // get table header for last price
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[2]")).Text + ",";
            // get table header for change
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[3]")).Text + ",";
            // get table header for %chg
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[4]")).Text + ",";
            // get table header for currency
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[5]")).Text + ",";
            // get table header for market time
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[6]")).Text + ",";
            // get table header for volume
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[7]")).Text + ",";
            // get table header for shares
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[8]")).Text + ",";
            // get table header for avg volume (3m)
            strThData = strThData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[1]/table/thead/tr/th[9]")).Text + ",";

            // Step 5.5
            // print table headers to console
            Console.WriteLine(strThData);

            // Step 6 - locate stock data table and its rows
            // Find table with stock data
            IWebElement table = driver.FindElement(By.ClassName("_1TagL"));

            // Find all rows in the table
            IList<IWebElement> rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
            String strRowData = "";

            // Step 7 - loop through rows to get columns

            // loop through rows
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