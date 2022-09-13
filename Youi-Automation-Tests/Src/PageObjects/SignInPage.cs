using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public class SignInPage:BasePage
    {
        public SignInPage(IWebDriver driver):base(driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.FindElement(By.CssSelector(".ico-login")).Displayed);
        }
        //youitest@automation.com, 12345678

        public SignInPage goToLoginIn()
        {
            driver.FindElement(By.CssSelector(".ico-login")).Click();
            return this;
        }

        public SignInPage SetEmail(string email)
        {
            driver.FindElement(By.CssSelector("#Email")).SendKeys(email);
            return this;
        }

        public SignInPage SetPassword(string password)
        {
            driver.FindElement(By.CssSelector("#Password")).SendKeys(password);
            return this;
        }

        public HomePage SignIn()
        {
            driver.FindElement(By.CssSelector(".login-button")).Click();
            return new HomePage(driver);
        }
    }
}
