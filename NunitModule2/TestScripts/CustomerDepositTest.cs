using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZBankNunit.PageObjects;
using XYZBankNunit.Utilities;

namespace XYZBankNunit.TestScripts
{
    internal class CustomerDepositTest : CoreCodes
    {
        //Asserts
        [Test, Order(1), Category("Regression Test")]
        [TestCase("23000")]      //parametrization 
        public void CustomerDepTest(string amount)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            CustomerDeposit custdep = new(driver);

            try
            {
                fluentWait.Until(d => custdep);
                custdep.Deposit(amount);
                
                IWebElement dep = driver.FindElement(By.XPath("//span[contains(text(),'Deposit Successful')]"));
                string ? depdone = dep.Text;
                TakeScreenshot();
                Assert.That(depdone, Does.Contain("Deposit Successful"));
                TakeScreenshot();


                LogTestResult("deposit  test", "test success");
                test = extent.CreateTest(" Deposit test success");
                test.Pass("Deposit test passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenshot();
                LogTestResult("deposit test", " test failed", ex.Message);
                test.Fail("Deposit test failed");

            }

        }

    }
}




                  