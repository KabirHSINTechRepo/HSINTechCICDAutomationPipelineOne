using HSINTechCICDAutomationPipeline.Helper;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;

namespace HSINTechCICDAutomationPipeline.Tests.Practice
{
    [TestClass]
    public class ImplementJsonFile1
    {
        //Declare variable
        private IWebDriver? driver;

        [TestMethod]
        [TestCategory("Regression")]
        public void ImplementJsonFileMethod1()
        {

            string text = File.ReadAllText(@"./app.json");
            //string text = File.ReadAllText(@"C:\\HSINTechChallenge\\KabirHSINTechCICDAutomationPipeline\\app.json");
            var jsonfilevariables = JsonSerializer.Deserialize<JsonFileVariables>(text);


            Console.WriteLine($"First name: {jsonfilevariables.googleURL}");
            Console.WriteLine($"Last name: {jsonfilevariables.searchkeyword1}");
            Console.WriteLine($"Job title: {jsonfilevariables.searchkeyword2}");



            //*****************************************************************************

            //========================== Headless Mode ==========================
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless=new");
            driver = new ChromeDriver(options);
            //====================================================

            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            //driver = new ChromeDriver();


            driver.Navigate().GoToUrl(jsonfilevariables.googleURL);
            Console.WriteLine("Open google home page");

            driver.Manage().Window.Maximize();
            Console.WriteLine("Maximize the window");

            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys(jsonfilevariables.searchkeyword1);
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
