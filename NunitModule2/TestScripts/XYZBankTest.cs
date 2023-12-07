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
using AventStack.ExtentReports.Model;
using NUnit.Framework.Interfaces;
using Log = Serilog.Log;


namespace XYZBankNunit.TestScripts
{
    internal class XYZBankTest : CoreCodes
    {
        //Asserts
        [Test, Order(1), Category("Regression Test")]
        public void AddCustomerTest()
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

            XYZBankHomePage xyzbnk = new(driver);
            

            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Searchdata"; 
            List<SearchData> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)
            {
            
                try
                {
                    
                    string? firstname = excelData?.FirstName;
                    string? lastname = excelData?.LastName;
                    string? postcode = excelData?.PostCode;
                    Console.WriteLine($"FirstName: {firstname}, LastName: {lastname}, Postcode: {postcode}");
                    fluentWait.Until(d => xyzbnk);
                   xyzbnk.AddCust(firstname, lastname, postcode);

                    TakeScreenshot();
                    IAlert AccountopenAlert = driver.SwitchTo().Alert();
                    string alert = AccountopenAlert.Text;
                    AccountopenAlert.Accept();
                    Assert.That(alert, Does.Contain("Customer added successfully"));
                    LogTestResult("Add Customer Test", "Customer Added");
                    test = extent.CreateTest("Add Customer Test test success");
                    test.Pass("Add Customer Test test passed");


                }
                catch (AssertionException ex)
                {
                    TakeScreenshot();
                    LogTestResult("Add Customer Test", "Customer Adding Failed", ex.Message);
                    test.Fail("Adding custmr test failed");

                }

            }
        }
    }
}