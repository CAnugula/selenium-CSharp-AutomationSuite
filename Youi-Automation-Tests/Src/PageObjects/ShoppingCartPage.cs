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

        public List<CartRowComponent> GetCartItems()
        {
            return new List<IWebElement>(GetElements(".cart-item-row"))
                .ConvertAll(new Converter<IWebElement,CartRowComponent>(e => new CartRowComponent(e)));
        }        

        public HomePage RemoveAndUpdateCartItems()
        {
            GetCartItems().Select(e => e.selectItemToRemove()).ToList();

            UpdateCart();

            return new HomePage(driver);
        }

        public void UpdateCart()
        {
            driver.FindElement(By.Name("updatecart")).Click();
        }

        private List<CartTotalComponent> GetCartTotal()
        {            
            return new List<IWebElement>(GetElements(".cart-total"))
                .ConvertAll(new Converter<IWebElement,CartTotalComponent>(e=> new CartTotalComponent(e)));
        }

        public double GetCartSubTotal()
        {
            return GetCartTotal().FirstOrDefault().GetSubTotal();
        }

        public CheckoutPage ClickIAgree()
        {
            GetElement("#termsofservice").Click();

            return new CheckoutPage(driver);
        }

    }
}
