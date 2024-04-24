using HSINTechCICDAutomationPipeline.Core;
using HSINTechCICDAutomationPipeline.Pages.NominatingVoting;
using HSINTechCICDAutomationPipeline.Pages.Practice;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSINTechCICDAutomationPipeline.Forms.NominatingVoting
{
    public  class LoginLogoutForm
    {
        private IWebDriver? driver = null;
        private BasePage? basepage = null;
        public LoginLogoutForm(IWebDriver d)
        {
            this.driver = d;
        }


        public void LoginClearPro(string userid, string password)
        {
            var loginlogoutpage = new LoginLogoutPage();
            basepage = new BasePage(driver);

            //Enter User Name
            basepage.ClearandEnterText(loginlogoutpage.userid, userid);
            Console.WriteLine($"Enter {userid} into UserID Field");

            //Enter Password
            basepage.ClearandEnterText(loginlogoutpage.password, password);
            Console.WriteLine($"Enter {password} into Password Field");

            //Click Sign In
            basepage.ClickOnElement(loginlogoutpage.signin);

            //Validation
            string getusername = basepage.ReturnText(loginlogoutpage.captureusername);

            if (getusername.ToLower().Contains(userid.ToLower()))
            {
                Assert.AreEqual("Login successfull with valid user", "Login successfull with valid user");
            }
            else
            {
                Assert.Fail("Invalid user successfully login to the application");
            }
        }

        public void LogoutClearPro()
        {
            var loginlogoutpage = new LoginLogoutPage();
            basepage = new BasePage(driver);

            //Click user account
            basepage.ClickOnElement(loginlogoutpage.captureusername);

            //Click Logout
            basepage.ClickOnElement(loginlogoutpage.logout);


            //Validation
            string getsignin = basepage.ReturnText(loginlogoutpage.signin);

            if (getsignin.Contains("Sign In"))
            {
                Assert.AreEqual("User Successfully Logout", "User Successfully Logout");
            }
            else
            {
                Assert.Fail("User Filed to Logout");
            }
        }



    }
}
