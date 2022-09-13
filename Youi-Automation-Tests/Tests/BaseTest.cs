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
        // TODO: Read below as env variables
        private readonly string WEBSHOP_URL = "https://demowebshop.tricentis.com";
        private readonly string LOGIN_EMAIL = "youitest@automation.com";
        private readonly string LOGIN_PWD = "12345678";
        private readonly int DEFAULT_WAIT = 5; // in seconds

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
            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DEFAULT_WAIT);
            driver.Navigate().GoToUrl(WEBSHOP_URL);

        }

        protected HomePage Login()
        {
            var signInPage = new SignInPage(driver);
            var homePage = signInPage.GoToLoginIn().SetEmail(LOGIN_EMAIL).SetPassword(LOGIN_PWD).SignIn();
            return homePage;
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
