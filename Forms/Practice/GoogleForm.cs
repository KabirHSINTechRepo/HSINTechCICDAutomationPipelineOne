using HSINTechCICDAutomationPipeline.Core;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSINTechCICDAutomationPipeline.Pages.Practice;
using HSINTechCICDAutomationPipeline.Helper;

namespace HSINTechCICDAutomationPipeline.Forms.Practice
{
    public class GoogleForm
    {
        private IWebDriver? driver = null;
        private BasePage? basepage = null;
        public GoogleForm(IWebDriver d)
        {
            this.driver = d;
        }


        public void EnterTextInGoogleSearchBox(string text)
        {
            var googleseachpage = new GoogleSeachPage();
            basepage = new BasePage(driver);
            basepage.EnterTextPressEnterUsingSendkeys(googleseachpage.googlesearchbox, text);
            Console.WriteLine($"Enter {text} into Search Text box");

        }



    }
}
