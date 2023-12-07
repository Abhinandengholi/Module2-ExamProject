using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZBankNunit.Utilities;

namespace XYZBankNunit.PageObjects
{
    internal class XYZBankHomePage
    {
        public IWebDriver driver;
        public XYZBankHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange

        [FindsBy(How = How.XPath, Using = "//button[text()='Bank Manager Login']//parent::div[@class='center']")]
        private IWebElement? ManagerLoginbutton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='center']//child::button[contains(text(),'Add Customer')]")]
        private IWebElement? AddCstmrbutton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='First Name']")]
        private IWebElement? FirstnameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Last Name']")]
        private IWebElement? Lastnameinput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Post Code']")]
        private IWebElement? PostalCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement? Submit { get; set; }
        


        //Act
        public void AddCust(string firstname, string lastname, string postcode)
        {
            IWebElement pageLoadedElement = CoreCodes.Waits(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Bank Manager Login']//parent::div[@class='center']")));
            ManagerLoginbutton?.Click();
            IWebElement pageLoadedElement1 = CoreCodes.Waits(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='center']//child::button[contains(text(),'Add Customer')]")));
            AddCstmrbutton?.Click();
            IWebElement pageLoadedElement2 = CoreCodes.Waits(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='First Name']")));
            FirstnameInput?.Click();
            FirstnameInput?.SendKeys(firstname);
            Lastnameinput?.Click();
            Lastnameinput?.SendKeys(lastname);
            PostalCode?.Click();
            PostalCode?.SendKeys(postcode);
            Submit?.Click();
            IAlert AccountopenAlert = driver.SwitchTo().Alert();
            AccountopenAlert.Accept();

        }
    }
}
