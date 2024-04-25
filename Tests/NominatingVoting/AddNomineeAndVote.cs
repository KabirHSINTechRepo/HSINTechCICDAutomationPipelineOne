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

            string name = "Andrew Baker";

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
            awardform.CandidateSearchBox(name);

            //As a Nominator, I want to submit a nomination by selecting a colleague and providing a brief description of their outstanding achievement.

            awardform.NominationReason("Because this person is Great and Excellent Team Player");
            awardform.AddnomineeVoteToNominateaCandidate();

            string candidateisrequiredErrorMessage = basepage.ReturnText(awardpage.candidateisrequiredErrorMessage);
            if(candidateisrequiredErrorMessage != null)
            {
                javascript.performClick(awardpage.cancel, 2000);
            }

            //Click Vote

            int RowCount = driver.FindElements(By.XPath("//*[@id='award-table']/tbody/tr")).Count;
            Console.WriteLine("RowCount in Docket Tab: " + RowCount);

            for (int i = 1; i <= RowCount; i++)
            {
                string nomineename = basepage.ReturnText("//*[@id='award-table']/tbody/tr[" + i + "]/td[1]/div");
                if (nomineename.Contains(name))
                {
                    javascript.performClick("//*[@id='award-table']/tbody/tr[" + i + "]/td[3]/button", 2000);
                    break;
                }

            }
            // Click Vote - PopUp
            awardform.VotePopup();

            //Logout
            loginlogoutform.LogoutClearPro();

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
