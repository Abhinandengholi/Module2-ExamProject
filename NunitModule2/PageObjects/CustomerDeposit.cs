using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    internal class CustomerDeposit
    {
        public IWebDriver driver;
        public CustomerDeposit(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange

        [FindsBy(How = How.XPath, Using = "//button[text()='Customer Login']//parent::div[@class='center']")]
        private IWebElement? CustomrLoginbutton { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='userSelect']")]
        private IWebElement? SelectName { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='userSelect']//child::option[text()='Harry Potter']")]
        private IWebElement? Specificname { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement? Loginbutton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Deposit')]//parent::div[@class='center']")]
        private IWebElement? Depositbutton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='amount']")]
        private IWebElement? Depositamount { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default']")]
        private IWebElement? Depositfinalbutton { get; set; }



        //Act
        public void Deposit(string amount)
        {
            IWebElement pageLoadedElement = CoreCodes.Waits(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Customer Login']//parent::div[@class='center']")));
            CustomrLoginbutton?.Click();
            IWebElement pageLoadedElement1 = CoreCodes.Waits(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='userSelect']")));
            SelectName?.Click();
            IWebElement pageLoadedElement2 = CoreCodes.Waits(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='userSelect']//child::option[text()='Harry Potter']")));
            Specificname?.Click();            
            Loginbutton?.Click();
            Depositbutton?.Click();
            Depositamount?.Click();
            Depositamount?.SendKeys(amount);
            Depositfinalbutton?.Click();


        }

    } 
}
