using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using AngleSharp.Io;
using AventStack.ExtentReports;

namespace HSINTechCICDAutomationPipeline.Tests.Practice
{
    [TestClass]
    public class SeleniumTwo
    {
        //Declare variable
        public IWebDriver? driver;

        [TestMethod]
        [TestCategory("Smoke")]
        public void TestMethod_SeleniumTwo()
        {
            //*****************************************************************************

            //========================== Headless Mode ==========================
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless=new");
            driver = new ChromeDriver(options);
            //====================================================

            //driver = new ChromeDriver(@"C:\HSINTechChallenge\HSINTechCICDAutomationPipeline\bin\Debug\net8.0\chromedriver.exe");

            driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("Open google home page");

            driver.Manage().Window.Maximize();
            Console.WriteLine("Maximize the window");

            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium ChromeDriver");
            Console.WriteLine("Enter Selenium ChromeDriver into Search Text box");

            searchBox.Submit();
            Console.WriteLine("Click Search / Submit");
            Thread.Sleep(3000);

        }


        [TestCleanup]
        public void TeardownTest()
        {
            driver.Quit();
            Console.WriteLine("Close Browser");
            Console.WriteLine("Quit Driver");
        }


    }
}

