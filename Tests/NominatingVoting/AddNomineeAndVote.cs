using HSINTechCICDAutomationPipeline.Core;
using HSINTechCICDAutomationPipeline.Forms.NominatingVoting;
using HSINTechCICDAutomationPipeline.Forms.Practice;
using HSINTechCICDAutomationPipeline.Helper;
using HSINTechCICDAutomationPipeline.Pages.Practice;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HSINTechCICDAutomationPipeline.Tests.NominatingVoting
{
    [TestClass]
    public class AddNomineeAndVote
    {
        //Declare variable
        private IWebDriver? driver;
        private BasePage? basepage = null;
        LoginLogoutForm? loginlogoutform = null;
        NominateAndVoteForYourCompanyForm nominateandvoteforyourcompanyform = null;

        [TestMethod]
        public void AddNomineeAndVote_TestMethod()
        {
            //*****************************************************************************
            string text = File.ReadAllText(@"./app.json");
            var jsonfilevariables = JsonSerializer.Deserialize<JsonFileVariables>(text);
            //*****************************************************************************

            //========================== Headless Mode ==========================
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless=new");
            driver = new ChromeDriver(options);
            //===================================================================

            //new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            //driver = new ChromeDriver();

            GoogleSeachPage googleseachpage = new GoogleSeachPage();
            basepage = new BasePage(driver);
            loginlogoutform = new LoginLogoutForm(driver);
            nominateandvoteforyourcompanyform = new NominateAndVoteForYourCompanyForm(driver);

            basepage.LaunchURL(jsonfilevariables.clearProURL);
            Console.WriteLine("Open google home page");

            //Login 
            loginlogoutform.LoginClearPro(jsonfilevariables.clearProURLUserID, jsonfilevariables.clearProURLPassword);

            //Verify all the nominations for each category 
            nominateandvoteforyourcompanyform.InnovationCreativityAwardcategory();
            nominateandvoteforyourcompanyform.CustomerCentricityAward();
            nominateandvoteforyourcompanyform.ExcellenceAward();
            nominateandvoteforyourcompanyform.TeamPlayerAward();

            //Logout
            loginlogoutform.LogoutClearPro();

        }

    }
}
