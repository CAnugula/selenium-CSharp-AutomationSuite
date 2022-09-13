using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Youi_Automation_Tests.Src.Component;
using Youi_Automation_Tests.Src.DataObject;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public class CheckoutPage:BasePage
    {
        public CheckoutPage(IWebDriver driver):base(driver)
        {

        }

        public CheckoutPage setBillingAddress(BillingAddress billingAddress)
        {
            var billingAddressElement = driver.FindElement(By.CssSelector("#opc-billing"));
            var billingComponent = new BillingAddressComponent(billingAddressElement);

            billingComponent.SetFirstName(billingAddress.firstName);
            billingComponent.SetLastName(billingAddress.lastName);
            billingComponent.SetEmail(billingAddress.email);
            billingComponent.SetCountry(billingAddress.country);
            billingComponent.SetCity(billingAddress.city);
            billingComponent.SetAddress(billingAddress.address);
            billingComponent.SetPostalCode(billingAddress.postalCode);
            billingComponent.SetPhoneNumber(billingAddress.phoneNumber);

            driver.FindElement(By.CssSelector("#billing-buttons-container .new-address-next-step-button")).Click();
            new WebDriverWait(driver, TimeSpan.FromMinutes(3))
                .Until(d => d.FindElement(By.CssSelector("#checkout-step-billing")).GetAttribute("style").Contains("display: none;"));
            return this;
        }

        public CheckoutPage clickContinue()
        {
            driver.FindElement(By.CssSelector("#billing-buttons-container .new-address-next-step-button")).Click();
            new WebDriverWait(driver, TimeSpan.FromMinutes(3))
                .Until(d => d.FindElement(By.CssSelector("#checkout-step-billing")).GetAttribute("style").Contains("display: none;"));
            return this;
        }

        public CheckoutPage setShippingAddress()
        {
            driver.FindElement(By.CssSelector("#shipping-buttons-container .new-address-next-step-button")).Click();
            new WebDriverWait(driver, TimeSpan.FromMinutes(3))
                .Until(d => d.FindElement(By.CssSelector("#checkout-step-shipping")).GetAttribute("style").Contains("display: none;"));
            return this;
        }

        public CheckoutPage setShippingMethod()
        {
            driver.FindElement(By.CssSelector("#shipping-method-buttons-container .shipping-method-next-step-button")).Click();
            new WebDriverWait(driver, TimeSpan.FromMinutes(3))
               .Until(d => d.FindElement(By.CssSelector("#checkout-step-shipping-method")).GetAttribute("style").Contains("display: none;"));
            return this;
        }
        public CheckoutPage setPaymentMethod()
        {
            driver.FindElement(By.CssSelector("#payment-method-buttons-container .payment-method-next-step-button")).Click();
            new WebDriverWait(driver, TimeSpan.FromMinutes(3))
                .Until(d => d.FindElement(By.CssSelector("#checkout-step-payment-method")).GetAttribute("style").Contains("display: none;"));
            return this;
        }
        public CheckoutPage setPaymentInformation()
        {
            driver.FindElement(By.CssSelector("#payment-info-buttons-container .payment-info-next-step-button")).Click();
            new WebDriverWait(driver, TimeSpan.FromMinutes(3))
               .Until(d => d.FindElement(By.CssSelector("#checkout-step-payment-info")).GetAttribute("style").Contains("display: none;"));
            return this;
        }
        public CheckoutPage setConfirmOrder()
        {
            driver.FindElement(By.CssSelector("#confirm-order-buttons-container .confirm-order-next-step-button")).Click();            
            return this;
        }
        
        public bool isBillingAddressNewFormDisabled()
        {
            return driver.FindElement(By.CssSelector("#billing-new-address-form")).GetAttribute("style").Contains("display: none;");
        }

        public double getCartTotal()
        {
            var cartTotalElement = driver.FindElement(By.CssSelector(".cart-total"));
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);
            return cartTotalCompoenent.getTotal();
        }

        public double getShippingCost()
        {
            var cartTotalElement = driver.FindElement(By.CssSelector(".cart-total"));
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);
            return cartTotalCompoenent.getShipping();
        }

        public double getAdditionalFee()
        {
            var cartTotalElement = driver.FindElement(By.CssSelector(".cart-total"));
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);
            return cartTotalCompoenent.getAdditionalFee();
        }

        public double getSubTotal()
        {
            var cartTotalElement = driver.FindElement(By.CssSelector(".cart-total"));
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);
            return cartTotalCompoenent.getSubTotal();
        }
    }
}
