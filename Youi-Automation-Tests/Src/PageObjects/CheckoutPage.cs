using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Youi_Automation_Tests.Src.Component;
using Youi_Automation_Tests.Src.DataObject;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public class CheckoutPage: BasePage
    {
        public CheckoutPage(IWebDriver driver):base(driver)
        {
        }

        public CheckoutPage setBillingAddress(BillingAddress billingAddress)
        {
            var billingAddressElement = GetElement("#opc-billing");
            var billingComponent = new BillingAddressComponent(billingAddressElement);

            billingComponent.SetFirstName(billingAddress.firstName);
            billingComponent.SetLastName(billingAddress.lastName);
            billingComponent.SetEmail(billingAddress.email);
            billingComponent.SetCountry(billingAddress.country);
            billingComponent.SetCity(billingAddress.city);
            billingComponent.SetAddress(billingAddress.address);
            billingComponent.SetPostalCode(billingAddress.postalCode);
            billingComponent.SetPhoneNumber(billingAddress.phoneNumber);

            GetElement("#billing-buttons-container .new-address-next-step-button").Click();

            new WebDriverWait(driver, TimeSpan.FromMinutes(3))
                .Until(d => d.FindElement(By.CssSelector("#checkout-step-billing")).GetAttribute("style").Contains("display: none;"));
            return this;
        }

        public CheckoutPage clickContinue()
        {
            GetElement("#billing-buttons-container .new-address-next-step-button").Click();

            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-billing")).GetAttribute("style").Contains("display: none;"));

            return this;
        }

        public CheckoutPage setShippingAddress()
        {
            GetElement("#shipping-buttons-container .new-address-next-step-button").Click();

            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-shipping")).GetAttribute("style").Contains("display: none;"));

            return this;
        }

        public CheckoutPage setShippingMethod()
        {
            GetElement("#shipping-method-buttons-container .shipping-method-next-step-button").Click();

            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-shipping-method")).GetAttribute("style").Contains("display: none;"));

            return this;
        }
        public CheckoutPage setPaymentMethod()
        {
            GetElement("#payment-method-buttons-container .payment-method-next-step-button").Click();

            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-payment-method")).GetAttribute("style").Contains("display: none;"));

            return this;
        }
        public CheckoutPage setPaymentInformation()
        {
            GetElement("#payment-info-buttons-container .payment-info-next-step-button").Click();
            
            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-payment-info")).GetAttribute("style").Contains("display: none;"));

            return this;
        }

        public CheckoutPage setConfirmOrder()
        {
            GetElement("#confirm-order-buttons-container .confirm-order-next-step-button").Click();

            return this;
        }
        
        public bool isBillingAddressNewFormDisabled()
        {
            return GetElement("#billing-new-address-form").GetAttribute("style").Contains("display: none;");
        }

        public double getCartTotal()
        {
            var cartTotalElement = GetElement(".cart-total");
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);
            
            return cartTotalCompoenent.getTotal();
        }

        public double getShippingCost()
        {
            var cartTotalElement = GetElement(".cart-total");
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);

            return cartTotalCompoenent.getShipping();
        }

        public double getAdditionalFee()
        {
            var cartTotalElement = GetElement(".cart-total");
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);

            return cartTotalCompoenent.getAdditionalFee();
        }

        public double getSubTotal()
        {
            var cartTotalElement = GetElement(".cart-total");
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);

            return cartTotalCompoenent.getSubTotal();
        }
    }
}

