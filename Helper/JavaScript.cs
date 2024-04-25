using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using java.awt;
using java.awt.@event;
using System;
using java.awt.datatransfer;
using System.Threading;
using System.Configuration;
using System.Linq;
using System.Security;

namespace HSINTechCICDAutomationPipeline.Helper
{
    public class JavaScript
    {

        //################################# Setup #################################
        private IWebDriver driver = null;
        private JavaScript javascript = null;

        public JavaScript(IWebDriver d)
        {
            this.driver = d;
        }

        public void pressTabRobot(int tab)
        {
            Robot robot = new Robot();
            if (tab == 1)
            {
                robot.keyPress(KeyEvent.VK_TAB);
            }
            else if (tab == 2)
            {
                robot.keyPress(KeyEvent.VK_TAB);
                robot.delay(500);
                robot.keyPress(KeyEvent.VK_TAB);
            }

            else if (tab == 3)
            {
                robot.keyPress(KeyEvent.VK_TAB);
                robot.delay(500);
                robot.keyPress(KeyEvent.VK_TAB);
                robot.delay(500);
                robot.keyPress(KeyEvent.VK_TAB);
            }

            else if (tab == 4)
            {
                robot.keyPress(KeyEvent.VK_TAB);
                robot.delay(500);
                robot.keyPress(KeyEvent.VK_TAB);
                robot.delay(500);
                robot.keyPress(KeyEvent.VK_TAB);
                robot.delay(500);
                robot.keyPress(KeyEvent.VK_TAB);
            }
            robot.keyRelease(KeyEvent.VK_TAB);
            robot.delay(1000);

        }


        public void pressEnter()
        {
            Robot robot = new Robot();
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_ENTER);
            robot.delay(1000);
        }

        public void pressEnterOnce()
        {
            Robot robot = new Robot();
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_ENTER);
            robot.delay(1000);
        }

        public void scrollDown1PressEnter1()
        {
            Robot robot = new Robot();
            robot.keyPress(KeyEvent.VK_DOWN);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_DOWN);
            robot.keyRelease(KeyEvent.VK_ENTER);
            robot.delay(1000);
        }
        public void scrollDown2PressEnter2()
        {
            Robot robot = new Robot();
            robot.keyPress(KeyEvent.VK_DOWN);
            robot.keyPress(KeyEvent.VK_DOWN);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_DOWN);
            robot.keyRelease(KeyEvent.VK_ENTER);
            robot.delay(1000);
        }

        //==========================================================================
        public void RefreshPage(int timeinseconds)
        {
            driver.Navigate().Refresh();
            Console.WriteLine("Refresh Page");
            Thread.Sleep(timeinseconds);

        }
        public void AlertAccept(int timeinseconds)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(timeinseconds);
        }

        public void slectctElementFromDropdown(string enterxpath, int index)
        {
            var Document = driver.FindElement(By.XPath(enterxpath));
            //create select element object 
            var selectElement = new SelectElement(Document);
            // select by text
            selectElement.SelectByIndex(index);
            Thread.Sleep(2000);
        }
        public void slectctElementFromDropdownByText(string enterxpath, string text)
        {
            //find the element in selenium webdriver
            IWebElement userNameTxt = driver.FindElement(By.XPath(enterxpath));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            // set the text
            jsExecutor.ExecuteScript("arguments[0].value='" + text + "'", userNameTxt);
            Thread.Sleep(2000);
        }

        public void performClick(string ielement, int timeinseconds)
        {
            IWebElement To = driver.FindElement(By.XPath(ielement));

            Actions act = new Actions(driver);
            act.MoveToElement(To).Click().Perform();
            Thread.Sleep(timeinseconds);
        }
        public void performDoubleClick(string ielement, int timeinseconds)
        {
            IWebElement To = driver.FindElement(By.XPath(ielement));

            Actions act = new Actions(driver);
            act.MoveToElement(To).DoubleClick().Perform();
            Thread.Sleep(timeinseconds);
        }
        public void hoverTheMouseUsingActionClass(string ielement, int timeinseconds)
        {
            IWebElement To = driver.FindElement(By.XPath(ielement));

            Actions act = new Actions(driver);
            act.MoveToElement(To).Perform();
            Thread.Sleep(timeinseconds);
        }
        public void switchFrame(string framename, int timeinseconds)
        {
            driver.SwitchTo().Frame(framename);
            Thread.Sleep(timeinseconds);
        }
        public void switchFrame(int frameindex, int timeinseconds)
        {
            driver.SwitchTo().Frame(frameindex);
            Thread.Sleep(timeinseconds);
        }
        public void switchToDefaultFrame(int timeinseconds)
        {
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(timeinseconds); ;
        }

        public void performClickJavaScript(string element)
        {

            IWebElement m1 = driver.FindElement(By.XPath(element));
            //JavascriptExecutor to click element
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;
            jse1.ExecuteScript("arguments[0].click();", m1);
            Thread.Sleep(2000);
        }

        public string ReturnTextUsingJavaScript(String element)
        {
            //IWebElement webElement = driver.FindElement(By.XPath(element));
            //IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;

            //String text = jse1.ExecuteScript("return arguments[0].text()", webElement).ToString();
            //String text = jse1.ExecuteScript("return document.getElementById('main').innerHTML").ToString();
            //String text = jse1.ExecuteScript("return document.documentElement.text",webElement).ToString();
            //return ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].getText", webElement).ToString();

            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;
            IWebElement webElement = driver.FindElement(By.XPath(element));
            String title = ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].title;", webElement).ToString();
            return title;
        }



        //public void fileUploadAutoIt(string filepath)
        //{
        //    var xrmBrowser = PactsContext.CurrentContext.Client.Browser;
        //    AutoItX3 autoIt = new AutoItX3();
        //    xrmBrowser.ThinkTime(1000);
        //    autoIt.WinActivate("Open"); // Activate - so that next set of actions happen on this window
        //    autoIt.Send(@filepath);
        //    xrmBrowser.ThinkTime(2000);
        //    autoIt.Send("{ENTER}");
        //    xrmBrowser.ThinkTime(1000);
        //}

        public void fileUploadRobot(String filepath)
        {
            //put path to your image in a clipboard
            StringSelection ss = new StringSelection(filepath);
            Toolkit.getDefaultToolkit().getSystemClipboard().setContents(ss, null);
            //imitate mouse events like ENTER, CTRL+C, CTRL+V
            Robot robot = new Robot();
            robot.delay(250);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_ENTER);
            robot.keyPress(KeyEvent.VK_CONTROL);
            robot.keyPress(KeyEvent.VK_V);
            robot.keyRelease(KeyEvent.VK_V);
            robot.keyRelease(KeyEvent.VK_CONTROL);
            robot.delay(250);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(250);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyPress(KeyEvent.VK_ENTER);
        }

        public void fileUploadRobot1(String filepath)
        {
            //put path to your image in a clipboard
            StringSelection ss = new StringSelection(filepath);
            Toolkit.getDefaultToolkit().getSystemClipboard().setContents(ss, null);
            //imitate mouse events like ENTER, CTRL+C, CTRL+V
            Robot robot = new Robot();
            robot.delay(250);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_ENTER);
            robot.keyPress(KeyEvent.VK_CONTROL);
            robot.keyPress(KeyEvent.VK_V);
            robot.keyRelease(KeyEvent.VK_V);
            robot.keyRelease(KeyEvent.VK_CONTROL);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            Thread.Sleep(1000);
            robot.keyPress(KeyEvent.VK_TAB);
            Thread.Sleep(1000);
            robot.keyRelease(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.delay(120);

            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_ENTER);

        }

        public void pressTabEnterRobot()
        {
            //imitate mouse events like ENTER, CTRL+C, CTRL+V
            Robot robot = new Robot();
            robot.keyPress(KeyEvent.VK_TAB);
            robot.keyRelease(KeyEvent.VK_TAB);
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_ENTER);
        }
        public void pressEnterRobot()
        {
            //imitate mouse events like ENTER, CTRL+C, CTRL+V
            Robot robot = new Robot();
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_ENTER);

        }
        public void pressTabRobot()
        {
            //imitate mouse events like ENTER, CTRL+C, CTRL+V
            Robot robot = new Robot();
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_TAB);
            robot.keyRelease(KeyEvent.VK_TAB);
        }

        public void ArrowdownRobot()
        {
            //imitate mouse events like ENTER, CTRL+C, CTRL+V
            Robot robot = new Robot();
            robot.delay(120);
            robot.keyPress(KeyEvent.VK_DOWN);
            robot.keyRelease(KeyEvent.VK_DOWN);
        }

        public void pressEnterAction(int timeinseconds)
        {
            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Enter);
            Thread.Sleep(timeinseconds);
        }

        public void pressEnterTwiceAction(int timeinseconds)
        {
            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Enter);
            builder.SendKeys(Keys.Enter);
            Thread.Sleep(timeinseconds);
        }


        public void enterValueWithActionClass(string entervalue)
        {
            Actions builder = new Actions(driver);
            builder.SendKeys(entervalue).Build().Perform();
            Thread.Sleep(1500);
        }
        public void tabWithActionClass()
        {
            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Tab).Build().Perform();
            Thread.Sleep(1500);
        }
        public void tabTwiceWithActionClass()
        {
            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Tab).Build().Perform();
            builder.SendKeys(Keys.Tab).Build().Perform();
            Thread.Sleep(1500);
        }

        public virtual void SelectUploadFile(string enterxpath, int timeinseconds)
        {
            IWebElement To = driver.FindElement(By.XPath(enterxpath));
            Actions act = new Actions(driver);
            act.MoveToElement(To).Click().Perform();
            Thread.Sleep(timeinseconds);
        }

        public virtual void ScrollUpPage()
        {
            //to perform Scroll on application using Selenium
            Actions act = new Actions(driver);
            act.SendKeys(OpenQA.Selenium.Keys.PageUp).Build().Perform(); //Page Down
            Console.WriteLine("Scroll down perfomed");
            Thread.Sleep(2000);
        }

        public virtual void ScrollDownaPage()
        {
            //to perform Scroll on application using Selenium
            Actions act = new Actions(driver);
            act.SendKeys(OpenQA.Selenium.Keys.PageDown).Build().Perform(); //Page Down
            Console.WriteLine("Scroll down perfomed");
            Thread.Sleep(2000);
        }

        public virtual void ScrollDownaPageJavaScript(string enterxpath)
        {
            var e = driver.FindElement(By.XPath(enterxpath));
            // JavaScript Executor to scroll to element
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", e);
            Console.WriteLine(e.Text);
        }


    }
}
