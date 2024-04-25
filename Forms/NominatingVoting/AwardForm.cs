using HSINTechCICDAutomationPipeline.Core;
using HSINTechCICDAutomationPipeline.Helper;
using HSINTechCICDAutomationPipeline.Pages.NominatingVoting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSINTechCICDAutomationPipeline.Forms.NominatingVoting
{
    public class AwardForm
    {
        private IWebDriver? driver = null;
        private BasePage? basepage = null;
        private JavaScript? javascript = null;

        public AwardForm(IWebDriver d)
        {
            this.driver = d;
            javascript = new JavaScript(d);
        }


        public void AddnomineeVote()
        {
            var awardpage = new AwardPage();
            basepage = new BasePage(driver);

            basepage.ClickOnElement(awardpage.addnomineevote);
        }
        
        public void CandidateSearchBox(string candidatename)
        {
            var awardpage = new AwardPage();
            basepage = new BasePage(driver);

            basepage.EnterTextPressEnterUsingSendkeys(awardpage.candidatesearchbox, candidatename);
        }

        public void NominationReason(string enternominationreason)
        {
            var awardpage = new AwardPage();
            basepage = new BasePage(driver);

            basepage.EnterText(awardpage.nominationreason, enternominationreason);
        }

        
        public void AddnomineeVoteToNominateaCandidate()
        {
            var awardpage = new AwardPage();
            basepage = new BasePage(driver);

            javascript.performClick(awardpage.addnomineevotetonominateaaandidate,2000);
        }


    }
}
