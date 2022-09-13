using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youi_Automation_Tests.Src.Util;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public List<IWebElement> getTopMenuList()
        {
            var listItems = new List<IWebElement>(driver.FindElements(By.CssSelector(".top-menu a")));
            return listItems;
        }
         
        public int getItemCountInShopingCart()
        {
            return Int32.Parse(driver.FindElement(By.CssSelector(".cart-qty")).Text.StripNonNumeric());
        }

        public bool HasLoadingSpinnerDisappeared()
        {
            return new WebDriverWait(driver, TimeSpan.FromMinutes(3))
                .Until(d => d.FindElement(By.CssSelector(".ajax-loading-block-window")).GetAttribute("style").Contains("display: none;"));
        }

        public ShoppingCartPage goToShoppingCart()
        {
            driver.FindElement(By.CssSelector(".ico-cart")).Click();
            return new ShoppingCartPage(driver);
        }

        public CheckoutPage goToCheckout()
        {
            driver.FindElement(By.CssSelector("#checkout")).Click();
            return new CheckoutPage(driver);
        }

        public string getOrderStatusMessage()
        {
            new WebDriverWait(driver, TimeSpan.FromMinutes(3))
               .Until(d => d.FindElement(By.CssSelector(".page-title")).Text.Equals("Thank you"));
            return driver.FindElement(By.CssSelector(".title")).Text;
        }
    }
}
