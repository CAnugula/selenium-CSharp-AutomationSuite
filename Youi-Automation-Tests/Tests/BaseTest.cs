using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Youi_Automation_Tests.Src.PageObjects;

namespace Youi_Automation_Tests.Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        public TestContext TestContext { get; set; }
        protected IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {            
            SetUpTestData();
            SetUpWebDriver();
        }

        private void SetUpTestData()
        {
            //TODO Set up Test Data
        }

        private void SetUpWebDriver()
        {
            //var options = new ChromeOptions();
            //TODO:Read data from Environment variables
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);//TODO Read from Env.variables
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com");//TODO: Read from Env.var

        }

        protected HomePage Login()
        {
            var signInPage = new SignInPage(driver);
            var homePage = signInPage.goToLoginIn().SetEmail("youitest@automation.com").SetPassword("12345678").SignIn();
            return homePage;
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
