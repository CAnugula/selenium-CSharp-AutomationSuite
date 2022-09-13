using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Youi_Automation_Tests.Src.Util;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        private readonly int DEFAULT_WAIT_UNTIL = 3; // in minutes

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetElement(string selector)
        {
            return driver.FindElement(By.CssSelector(selector));
        }

        public List<IWebElement> GetElements(string selector)
        {
            return new List<IWebElement>(driver.FindElements(By.CssSelector(selector)));
        }

        public void WaitUntil(Func<IWebDriver, bool> expression)
        {
            new WebDriverWait(driver, TimeSpan.FromMinutes(DEFAULT_WAIT_UNTIL))
               .Until(expression);
        }

        public List<IWebElement> GetTopMenuList()
        {
            return GetElements(".top-menu a");
        }
         
        public int GetItemCountInShoppingCart()
        {
            return Convert.ToInt32(GetElement(".cart-qty").Text.StripNonNumeric());
        }

        public bool HasLoadingSpinnerDisappeared()
        {
            return new WebDriverWait(driver, TimeSpan.FromMinutes(3))
                .Until(d => d.FindElement(By.CssSelector(".ajax-loading-block-window")).GetAttribute("style").Contains("display: none;"));
        }

        public ShoppingCartPage GoToShoppingCart()
        {
            GetElement(".ico-cart").Click();

            return new ShoppingCartPage(driver);
        }

        public CheckoutPage GoToCheckout()
        {
            GetElement("#checkout").Click();

            return new CheckoutPage(driver);
        }

        public string GetOrderStatusMessage()
        {
            new WebDriverWait(driver, TimeSpan.FromMinutes(3))
               .Until(d => d.FindElement(By.CssSelector(".page-title")).Text.Equals("Thank you"));

            return GetElement(".title").Text;
        }
    }
}
