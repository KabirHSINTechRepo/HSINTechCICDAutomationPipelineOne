using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSINTechCICDAutomationPipeline.Pages.NominatingVoting
{
    public class AwardPage
    {
        public string addnomineevote = "//*[@id='add-nominee']";

        public string candidatesearchbox = "//*[@id='candidateId']";
        public string nominationreason = "//*[@id='reason']";

        public string addnomineevotetonominateaaandidate = "//*[@id='submit']";

        public string candidateisrequiredErrorMessage = "//*[text()='Candidate is required']";
        public string cancel = "//*[@id='cancel']";
        public string votepopup = "//*[@id='submit']";

    }
}
