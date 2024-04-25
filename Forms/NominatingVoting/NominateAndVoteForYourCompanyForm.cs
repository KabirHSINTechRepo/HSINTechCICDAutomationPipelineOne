using HSINTechCICDAutomationPipeline.Core;
using HSINTechCICDAutomationPipeline.Pages.NominatingVoting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSINTechCICDAutomationPipeline.Forms.NominatingVoting
{
    public class NominateAndVoteForYourCompanyForm
    {
        private IWebDriver? driver = null;
        private BasePage? basepage = null;
        public NominateAndVoteForYourCompanyForm(IWebDriver d)
        {
            this.driver = d;
        }


        public void InnovationCreativityAwardcategory()
        {
            var nominateandvoteforyourcompanypage = new NominateAndVoteForYourCompanyPage();
            basepage = new BasePage(driver);

            //Verify Innovation & Creativity Award           
            string getusername = basepage.ReturnText(nominateandvoteforyourcompanypage.innovationcreativityaward);

            if (getusername.Contains("Innovation & Creativity Award"))
            {
                Assert.AreEqual("Innovation & Creativity Award category Verified", "Innovation & Creativity Award category Verified");
            }
            else
            {
                Assert.Fail("Innovation & Creativity Award category Failed to Verify");
            }
        }

        public void CustomerCentricityAward()
        {
            var nominateandvoteforyourcompanypage = new NominateAndVoteForYourCompanyPage();
            basepage = new BasePage(driver);

            //Verify Innovation & Creativity Award           
            string CustomerCentricityAward = basepage.ReturnText(nominateandvoteforyourcompanypage.customercentricityaward);

            if (CustomerCentricityAward.Contains("Customer Centricity Award"))
            {
                Assert.AreEqual("Customer Centricity Award category Verified", "Customer Centricity Award category Verified");
            }
            else
            {
                Assert.Fail("Customer Centricity Award category Failed to Verify");
            }
        }

        public void ExcellenceAward()
        {
            var nominateandvoteforyourcompanypage = new NominateAndVoteForYourCompanyPage();
            basepage = new BasePage(driver);

            //Verify Innovation & Creativity Award           
            string ExcellenceAward = basepage.ReturnText(nominateandvoteforyourcompanypage.excellenceaward);

            if (ExcellenceAward.Contains("Excellence Award"))
            {
                Assert.AreEqual("Excellence Award category Verified", "Excellence Award category Verified");
            }
            else
            {
                Assert.Fail("Excellence Award category Failed to Verify");
            }
        }

        public void TeamPlayerAward()
        {
            var nominateandvoteforyourcompanypage = new NominateAndVoteForYourCompanyPage();
            basepage = new BasePage(driver);

            //Verify Innovation & Creativity Award           
            string TeamPlayerAward = basepage.ReturnText(nominateandvoteforyourcompanypage.teamplayeraward);

            if (TeamPlayerAward.Contains("Team Player Award"))
            {
                Assert.AreEqual("Team Player Award category Verified", "Team Player Award category Verified");
            }
            else
            {
                Assert.Fail("Team Player Award category Failed to Verify");
            }
        }


        public void ViewNomineesforTeamPlayerAward()
        {
            var nominateandvoteforyourcompanypage = new NominateAndVoteForYourCompanyPage();
            basepage = new BasePage(driver);

            basepage.ExplicitWait(nominateandvoteforyourcompanypage.viewnomineesforteamplayeraward, 15);

            //Click View Nominees for Team Player Award
            basepage.ClickOnElement(nominateandvoteforyourcompanypage.viewnomineesforteamplayeraward);

        }


    }
}
