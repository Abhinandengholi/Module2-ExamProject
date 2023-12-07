using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using XYZBankBDD.Utilities;
using XYZBankBDD.Hooks;
using NUnit.Framework;

namespace XYZBankBDD.StepDefinitions
{
    [Binding]
    internal class AddCustomerStep:CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;

        [When(@"User will click on the BankManager Login Button")]
        public void WhenUserWillClickOnTheBankManagerLoginButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            IWebElement? managerselect = fluentWait.Until(d => driver?.FindElement(By.XPath("//button[text()='Bank Manager Login']//parent::div[@class='center']")));
            managerselect?.Click();
        }

        [Then(@"Bankmanager Page is loaded in the same page")]
        public void ThenBankmanagerPageIsLoadedInTheSamePage()
        {
            TakeScreenshot(driver);
            try
            {
                Assert.That(driver.Url.Contains("BankingProject"));
                LogTestResult("Customer page Test", "loaded in the same page");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Customer Page Test", " Test Failed", ex.Message);
            }

        }

        [When(@"Selecting Add-Customer option")]
        public void ThenSelectingAdd_CustomerOption()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            IWebElement? optionselect = fluentWait.Until(d => driver?.FindElement(By.XPath("//div[@class='center']//child::button[contains(text(),'Add Customer')]")));
            optionselect?.Click();
        }

        [When(@"Fills the Customer Details '([^']*)','([^']*)','([^']*)'")]
        public void ThenFillsTheCustomerDetails(string firstname, string lastname, string postcode)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement? firstnameInput = fluentWait.Until(d => driver?.FindElement(By.XPath("//input[@placeholder='First Name']")));
            firstnameInput?.Click();
            firstnameInput?.SendKeys(firstname);
            IWebElement? lastnameInput = fluentWait.Until(d => driver?.FindElement(By.XPath("//input[@placeholder='Last Name']")));
            lastnameInput?.Click();
            lastnameInput?.SendKeys(lastname);
            IWebElement? postInput = fluentWait.Until(d => driver?.FindElement(By.XPath("//input[@placeholder='Post Code']"))); 
            postInput?.Click();
            postInput?.SendKeys(postcode);
            

        }

        [When(@"Clicks the Add Customer")]
        public void ThenClicksTheAddCustomer()
        {
           
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            IWebElement? addbutton = fluentWait.Until(d => driver?.FindElement(By.XPath(" //button[@type='submit']")));
            addbutton?.Click();
        }

        [Then(@"Customer details added successfully")]
        public void ThenCustomerDetailsAddedSuccessfully()
        {
            

                IAlert AccountopenAlert = driver.SwitchTo().Alert();
                string alert = AccountopenAlert.Text;
                AccountopenAlert.Accept();
                TakeScreenshot(driver);
                try
                {
                    Assert.That(alert, Does.Contain("Customer added successfully"));
                    LogTestResult("Add Customer Test", "Customer Added");
                }



                catch (AssertionException ex)
                {
                    LogTestResult("Add Customer Test", "Customer Adding Failed", ex.Message);
                }
            
        }
       

    }
}
