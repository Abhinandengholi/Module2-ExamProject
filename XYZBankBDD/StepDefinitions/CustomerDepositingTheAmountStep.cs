using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Cryptography;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using XYZBankBDD.Hooks;
using XYZBankBDD.Utilities;

namespace XYZBankBDD.StepDefinitions
{
    [Binding]
    internal class CustomerDepositingTheAmountStep:CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;

        [Given(@"User will be on Homepage")]
        public void GivenUserWillBeOnHomepage()
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login";
            driver.Manage().Window.Maximize();


        }

        [When(@"User will click on the Customer Login Button")]
        public void WhenUserWillClickOnTheCustomerLoginButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            IWebElement? custselect = fluentWait.Until(d => driver?.FindElement(By.XPath("//button[text()='Customer Login']//parent::div[@class='center']")));
            custselect?.Click();
        }

        [Then(@"Customer Page is loaded in the same page")]
        public void ThenCustomerPageIsLoadedInTheSamePage()
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

        [When(@"User selects a '([^']*)' from the list")]
        public void WhenUserSelectsAFromTheList(string customer)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            IWebElement? custlog = fluentWait.Until(d => driver?.FindElement(By.XPath("//select[@id='userSelect']")));
            custlog?.Click();

            driver.FindElement(By.XPath("//select[@id='userSelect']//child::option[text()='" + customer + "']")).Click();
            
        }

        [When(@"Clicks the Login Button")]
        public void WhenClicksTheLoginButton()
        {
            driver?.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [When(@"Selecting the deposit option")]
        public void WhenSelectingTheDepositOption()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement? seldep = fluentWait.Until(d => driver?.FindElement(By.XPath("//button[contains(text(),'Deposit')]//parent::div[@class='center']")));
            seldep?.Click();
        }

        [When(@"Enter the  amount '([^']*)' to Deposit")]
        public void WhenEnterTheAmountToDeposit(string amount)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement? amountInput = fluentWait.Until(d=>driver?.FindElement(By.XPath("//input[@placeholder='amount']")));
            amountInput?.Click();
            amountInput?.SendKeys(amount);
            

        }

        [When(@"Clicks the Deposit Button")]
        public void WhenClicksTheDepositButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement? buttn = fluentWait.Until(d => driver?.FindElement(By.XPath("//button[@class='btn btn-default']")));
            buttn?.Click();
        }

        [Then(@"Deposit Success Message Appears")]
        public void ThenDepositSuccessMessageAppears()
        {

            TakeScreenshot(driver);
            try
            {
              

                IWebElement dep = driver?.FindElement(By.XPath("//span[contains(text(),'Deposit Successful')]"));
                string? depdone = dep.Text;
                Assert.That(depdone, Does.Contain("Deposit Successful"));
                LogTestResult("Deposit Test", "Deposit successful");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Deposit Test", "Deposit Test Failed", ex.Message);
            }
        }
    }
}
