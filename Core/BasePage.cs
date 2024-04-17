using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace HSINTechCICDAutomationPipeline.Core
{
    public class BasePage
    {

        private readonly IWebDriver driver;
        public BasePage(IWebDriver d)
        {
            driver = d;
        }
        public void captureScreenshot()
        {
            // Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            //  string screenshot = ss.AsBase64EncodedString;
            //  byte[] screenshotAsByteArray = ss.AsByteArray;
            //  ss.SaveAsFile("E:\\code\\CSharpe\\" + "Step" + GetTimestamp(DateTime.Now) + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            //Console.WriteLine("Screenshot captured in file " + "E:\\code\\CSharpe\\" + "Step" + GetTimestamp(DateTime.Now) + ".jpeg");
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public void LaunchURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

        }
        public void Submit(string locator)
        {
            var searchBox = driver.FindElement(By.XPath(locator));
            searchBox.Submit();
            Console.WriteLine("Click Search / Submit");
            Thread.Sleep(3000);

        }

        public void SwitchFrameTo(int index, int waittime)
        {
            //Switch Frame
            Thread.Sleep(1000);
            driver.SwitchTo().Frame(index);
            Console.WriteLine("Switch Frame: " + index);
            Thread.Sleep(waittime);
        }

        public void NavigateBack(int waittime)
        {
            driver.Navigate().Back();
            Console.WriteLine("Navigate back a browser history");
            Thread.Sleep(waittime);
        }
        public void NavigateForward(int waittime)
        {
            driver.Navigate().Forward();
            Console.WriteLine("Navigate Forward a browser history");
            Thread.Sleep(waittime);
        }

        public void SwitchFrameToName(string nameorid, int waittime)
        {
            //Switch Frame
            Thread.Sleep(1000);
            driver.SwitchTo().Frame(nameorid);
            Console.WriteLine("Switch Frame: " + nameorid);
            Thread.Sleep(waittime);
        }

        public void SwitchtoDefaultFrame(int waittime)
        {
            //Switch to DefaultFrame
            driver.SwitchTo().DefaultContent();
            Console.WriteLine("Switch to Default Frame");
            Thread.Sleep(waittime);
        }

        public void SwitchWindow(int index, int waittime)
        {
            driver.SwitchTo().Window(driver.WindowHandles[index]);
            Console.WriteLine("Switch Window: " + index);
            Thread.Sleep(waittime);
        }
        public void SwitchToDefaultWindow()
        {
            driver.SwitchTo().DefaultContent();
            Console.WriteLine("Switch Default Windows");
            Thread.Sleep(2000);
        }
        public void SwitchWindowToAndCloseWindow(int index, int waittime)
        {
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[index]).Close();
            Console.WriteLine("Switch Window: " + index + "Close Window");
            Thread.Sleep(waittime);
        }

        public void ClickOnElement(string element)
        {
            driver.FindElement(By.XPath(element)).Click();
            Thread.Sleep(1500);
        }

        public void ClickOnElementArrowrownOne(string element)
        {
            driver.FindElement(By.XPath(element)).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.XPath(element)).SendKeys(Keys.ArrowDown);
            Thread.Sleep(1500);
            driver.FindElement(By.XPath(element)).SendKeys(Keys.Enter);
        }

        public void DoubleClickOnElement(string element)
        {
            driver.FindElement(By.XPath(element)).Click();
            driver.FindElement(By.XPath(element)).Click();
            Thread.Sleep(1500);

        }
        public void EnterText(string element, string text)
        {
            driver.FindElement(By.XPath(element)).SendKeys(text);
            Thread.Sleep(1500);
        }
        public void ClearText(string element)
        {
            Actions act = new Actions(driver);
            act.Click(driver.FindElement(By.XPath(element)))
              .SendKeys(Keys.Control + "a" + Keys.Backspace)
              .Build()
              .Perform();
            Thread.Sleep(1000);
            Console.WriteLine("Clear Value");
        }
        public void ClearTextWithSendkeys(string element)
        {
            driver.FindElement(By.XPath(element)).SendKeys(Keys.Control + "a" + Keys.Delete);
            Thread.Sleep(1500);
        }

        public void ClearandEnterText(string element, string text)
        {
            driver.FindElement(By.XPath(element)).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(element)).SendKeys(text);
            Thread.Sleep(1500);
        }

        public void EnterTextPressEnterUsingSendkeys(string element, string text)
        {
            driver.FindElement(By.XPath(element)).SendKeys(text);
            driver.FindElement(By.XPath(element)).SendKeys(Keys.Enter);
            Thread.Sleep(1500);
        }
        public void ClickEnterText(string element, string text)
        {
            driver.FindElement(By.XPath(element)).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath(element)).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath(element)).SendKeys(text);
        }
        public void PerformClickEnterText(string element, string text)
        {
            IWebElement To = driver.FindElement(By.XPath(element));
            Actions act = new Actions(driver);
            act.MoveToElement(To).Click().Perform();
            Thread.Sleep(500);
            act.MoveToElement(To).Click().Perform();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(element)).SendKeys(text);
        }
        public void slectctElementFromDropdown(string enterxpath, int index)
        {
            var Document = driver.FindElement(By.XPath(enterxpath));
            //create select element object 
            var selectElement = new SelectElement(Document);
            // select by text
            selectElement.SelectByIndex(index);
            Thread.Sleep(1000);
        }

        public void slectctElementFromDropdownByText(string enterxpath, string dropdownvalue)
        {
            var Document = driver.FindElement(By.XPath(enterxpath));
            //create select element object 
            var selectElement = new SelectElement(Document);
            // select by text
            selectElement.SelectByText(dropdownvalue);
            Thread.Sleep(1000);
        }

        public string ReturnText(string element)
        {
            string returntext = driver.FindElement(By.XPath(element)).Text;
            Console.WriteLine("Return Text is: " + returntext);
            return returntext;
        }
        public string ReturnTextWithAttributes(string element, string attribute)
        {
            string returntext = driver.FindElement(By.XPath(element)).GetAttribute(attribute);
            Console.WriteLine("Return Text With Attributes is: " + returntext);
            return returntext;
        }

        public string ReturnTitle()
        {
            string returntitle = driver.Title;
            return returntitle;
        }
        public string ReturnCurrentURL()
        {
            string returntitle = driver.Url;
            return returntitle;
        }

        public bool IsElementPresent(string xpathelement)
        {
            try
            {
                driver.FindElement(By.XPath(xpathelement));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        //============================== Wait Statement ================================
        // https://gist.github.com/up1/d925783ea8e5f706f3bb58c3ce1ef7eb
        public void ExplicitWait(String locator, int timeinseconds)
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeinseconds));
            IWebElement searchResult = webdriverWait.Until(x => x.FindElement(By.XPath(locator)));
            Thread.Sleep(1000);
        }

        public void ExplicitWaitWithID(String locatorbyID, int timeinseconds)
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeinseconds));
            IWebElement searchResult = webdriverWait.Until(x => x.FindElement(By.Id(locatorbyID)));
            Thread.Sleep(1000);
        }


        public void ExplicitWaitExpectedCondition(String locator, int timeinseconds)
        {
            //for this method we need to install "DotNetSeleniumExtras.WaitHelpers" from Nuget Package
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeinseconds));
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locator)));
            Thread.Sleep(1000);
        }

        public void ExplicitWaitExpectedConditionElementIsVisible(String locator, int timeinseconds)
        {
            //for this method we need to install "DotNetSeleniumExtras.WaitHelpers" from Nuget Package
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeinseconds));
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            Thread.Sleep(1000);
        }
        public void ExplicitWaitExpectedConditionElementToBeClickable(String locator, int timeinseconds)
        {
            //for this method we need to install "DotNetSeleniumExtras.WaitHelpers" from Nuget Package
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeinseconds));
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
            Thread.Sleep(1000);
        }

        public void FluentWait(String locator, int timeinseconds)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(2);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(timeinseconds);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(locator)));
            Thread.Sleep(1000);
        }

        public void DeleteAllCookies()
        {
            //Clear cache 
            driver.Manage().Cookies.DeleteAllCookies();
            Thread.Sleep(3000);
        }

        public void ClearChromeHistory()
        {
            driver.Navigate().GoToUrl("chrome://settings/clearBrowserData");
            Thread.Sleep(3000);
            IJavaScriptExecutor executer = (IJavaScriptExecutor)driver;
            string buttonCssScript = "return document.querySelector('settings-ui').shadowRoot.querySelector('settings-main').shadowRoot.querySelector('settings-basic-page').shadowRoot.querySelector('settings-section > settings-privacy-page').shadowRoot.querySelector('settings-clear-browsing-data-dialog').shadowRoot.querySelector('#clearBrowsingDataDialog').querySelector('#clearBrowsingDataConfirm')";
            IWebElement clearButton = (IWebElement)executer.ExecuteScript(buttonCssScript);
            clearButton.Click();
            Thread.Sleep(3000);
        }

        //===============================================================================



    }
}
