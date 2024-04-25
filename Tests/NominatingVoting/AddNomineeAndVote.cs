using HSINTechCICDAutomationPipeline.Core;
using HSINTechCICDAutomationPipeline.Forms.NominatingVoting;
using HSINTechCICDAutomationPipeline.Forms.Practice;
using HSINTechCICDAutomationPipeline.Helper;
using HSINTechCICDAutomationPipeline.Pages.NominatingVoting;
using HSINTechCICDAutomationPipeline.Pages.Practice;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
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
        private Helper.JavaScript? javascript = null;
        LoginLogoutForm? loginlogoutform = null;
        NominateAndVoteForYourCompanyForm nominateandvoteforyourcompanyform = null;
        AwardForm awardform = null;


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
            var awardpage = new AwardPage();
            basepage = new BasePage(driver);
            javascript = new Helper.JavaScript(driver);
            loginlogoutform = new LoginLogoutForm(driver);
            nominateandvoteforyourcompanyform = new NominateAndVoteForYourCompanyForm(driver);
            awardform = new AwardForm(driver);

            basepage.LaunchURL(jsonfilevariables.clearProURL);
            Console.WriteLine("Open google home page");

            //Login 
            loginlogoutform.LoginClearPro(jsonfilevariables.clearProURLUserID, jsonfilevariables.clearProURLPassword);

            //As an Employee, I want to see all the nominations for each category so that I can decide on who to support.
            //Verify all the nominations for each category 
            nominateandvoteforyourcompanyform.InnovationCreativityAwardcategory();
            nominateandvoteforyourcompanyform.CustomerCentricityAward();
            nominateandvoteforyourcompanyform.ExcellenceAward();
            nominateandvoteforyourcompanyform.TeamPlayerAward();

            //As a Nominator, I want to be able to find people within my company on the platform so that I choose someone to nominate.
            //View Nominees for Team Player Award
            nominateandvoteforyourcompanyform.ViewNomineesforTeamPlayerAward();
            awardform.AddnomineeVote();
            awardform.CandidateSearchBox("Andrew Baker");

            //As a Nominator, I want to submit a nomination by selecting a colleague and providing a brief description of their outstanding achievement.

            awardform.NominationReason("Because this person is Great and Excellent Team Player");
            awardform.AddnomineeVoteToNominateaCandidate();

            string candidateisrequiredErrorMessage = basepage.ReturnText(awardpage.candidateisrequiredErrorMessage);
            if(candidateisrequiredErrorMessage != null)
            {
                javascript.performClick(awardpage.cancel, 2000);
            }

            //Vote


            //Logout
            loginlogoutform.LogoutClearPro();

        }

    }
}
