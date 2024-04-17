using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Reflection;

namespace HSINTechCICDAutomationPipeline.Core
{
    public class TestBase
    {

        //============================== Extent Report Variables ==================================
        public static ExtentReports extent;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;

        private readonly IWebDriver driver;


        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
        }

        public static void reportLogger(string testcasename)
        {
            extent = new ExtentReports();
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");

            Directory.CreateDirectory(dir + "\\ExecutionResult\\");
            Directory.CreateDirectory(dir + "\\ExecutionResult\\TestExecutionResult");
            Random rand = new Random();
            string randoomno = rand.Next(1000).ToString();
            //dirpath = dir + "\\TestResults\\TestCaseName\\" + "_" + testcasename;
            //dirpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\TestData\\" + "_" + testcasename;

            dirpath = dir + "\\ExecutionResult\\TestExecutionResult\\" + "_" + testcasename;

            // AventStack.ExtentReports.Reporter.ExtentV3HtmlReporter htmlReporter = new AventStack.ExtentReports.Reporter.ExtentV3HtmlReporter(dirpath);
            //AventStack.ExtentReports.Reporter.ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);
            AventStack.ExtentReports.Reporter.ExtentV3HtmlReporter htmlReporter = new AventStack.ExtentReports.Reporter.ExtentV3HtmlReporter(dirpath);


            htmlReporter.Config.Theme = Theme.Dark;

            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", System.Net.Dns.GetHostName());
            extent.AddSystemInfo("User Name", System.Security.Principal.WindowsIdentity.GetCurrent().Name);


        }

        public static string ScreenCaptureAsBase64String(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }

        public static string Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");

            string finalpth = dir + "\\ExecutionResult\\ScreenShots\\" + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath);
            return localpath;
        }



    }

}
