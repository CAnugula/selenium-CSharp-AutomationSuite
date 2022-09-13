using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public class SignInPage: BasePage
    {
        public SignInPage(IWebDriver driver): base(driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.FindElement(By.CssSelector(".ico-login")).Displayed);
        }

        public SignInPage GoToLoginIn()
        {
            GetElement(".ico-login").Click();

            return this;
        }

        public SignInPage SetEmail(string email)
        {
            GetElement("#Email").SendKeys(email);

            return this;
        }

        public SignInPage SetPassword(string password)
        {
            GetElement("#Password").SendKeys(password);

            return this;
        }

        public HomePage SignIn()
        {
            GetElement(".login-button").Click();

            return new HomePage(driver);
        }
    }
}
