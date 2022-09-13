using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Youi_Automation_Tests.Src.Component;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public class ShoppingCartPage:BasePage
    {
        public ShoppingCartPage(IWebDriver driver):base(driver)
        {

        }

        public List<CartRowComponent> getCartItems()
        {
            return new List<IWebElement>(driver.FindElements(By.CssSelector(".cart-item-row")))
                .ConvertAll(new Converter<IWebElement,CartRowComponent>(e => new CartRowComponent(e)));
        }        

        public HomePage removeAndUpdateCartItems()
        {
            getCartItems().Select(e => e.selectItemToRemove()).ToList();
            updateCart();
            return new HomePage(driver);
        }

        public void updateCart()
        {
            driver.FindElement(By.Name("updatecart")).Click();
        }

        private List<CartTotalComponent> getCartTotal()
        {            
            return new List<IWebElement>(driver.FindElements(By.CssSelector(".cart-total")))
                .ConvertAll(new Converter<IWebElement,CartTotalComponent>(e=> new CartTotalComponent(e)));
        }

        public double getCartSubTotal()
        {
            return getCartTotal().FirstOrDefault().getSubTotal();
        }

        public CheckoutPage clickIAgree()
        {
            driver.FindElement(By.CssSelector("#termsofservice")).Click();
            return new CheckoutPage(driver);
        }

    }
}
