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
using HSINTechCICDAutomationPipeline.Pages.Practice;
using HSINTechCICDAutomationPipeline.Core;
using HSINTechCICDAutomationPipeline.Forms.Practice;

namespace HSINTechCICDAutomationPipeline.Tests.Practice
{
    [TestClass]
    public class ImplementJsonFile3
    {
        //Declare variable
        private IWebDriver? driver;
        private BasePage? basepage = null;
        GoogleForm? googleform = null;


        [TestMethod]
        [TestCategory("Regression")]
        public void ImplementJsonFileMethod3()
        {
            string text = File.ReadAllText(@"./app.json");
            //string text = File.ReadAllText(@"C:\\HSINTechChallenge\\KabirHSINTechCICDAutomationPipeline\\app.json");
            var jsonfilevariables = JsonSerializer.Deserialize<JsonFileVariables>(text);


            //*****************************************************************************

            //========================== Headless Mode ==========================
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless=new");
            driver = new ChromeDriver(options);
            //====================================================

            //new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            //driver = new ChromeDriver();

            GoogleSeachPage googleseachpage = new GoogleSeachPage();
            basepage = new BasePage(driver);
            googleform = new GoogleForm(driver);


            basepage.LaunchURL(jsonfilevariables.googleURL);
            Console.WriteLine("Open google home page");

            googleform.EnterTextInGoogleSearchBox(jsonfilevariables.searchkeyword1);



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
