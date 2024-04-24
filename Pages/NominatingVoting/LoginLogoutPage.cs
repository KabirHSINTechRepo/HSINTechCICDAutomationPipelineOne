using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSINTechCICDAutomationPipeline.Pages.NominatingVoting
{
    public  class LoginLogoutPage
    {
        public string userid = "//*[@id='username-login-id']";
        public string password = "//*[@id='password-id']";
        public string signin = "//*[@id='submit']";
        public string captureusername = "//*[@id='root']/div/header/div/div/div/div[2]/div/div/div[2]/div/div[1]";
        public string logout = "//*[text()='Log Out']";



    }
}
