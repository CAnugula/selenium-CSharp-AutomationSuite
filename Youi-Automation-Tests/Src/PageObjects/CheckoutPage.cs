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

        public CheckoutPage SetBillingAddress(BillingAddress billingAddress)
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

        public CheckoutPage ClickContinue()
        {
            GetElement("#billing-buttons-container .new-address-next-step-button").Click();

            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-billing")).GetAttribute("style").Contains("display: none;"));

            return this;
        }

        public CheckoutPage SetShippingAddress()
        {
            GetElement("#shipping-buttons-container .new-address-next-step-button").Click();

            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-shipping")).GetAttribute("style").Contains("display: none;"));

            return this;
        }

        public CheckoutPage SetShippingMethod()
        {
            GetElement("#shipping-method-buttons-container .shipping-method-next-step-button").Click();

            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-shipping-method")).GetAttribute("style").Contains("display: none;"));

            return this;
        }
        public CheckoutPage SetPaymentMethod()
        {
            GetElement("#payment-method-buttons-container .payment-method-next-step-button").Click();

            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-payment-method")).GetAttribute("style").Contains("display: none;"));

            return this;
        }
        public CheckoutPage SetPaymentInformation()
        {
            GetElement("#payment-info-buttons-container .payment-info-next-step-button").Click();
            
            WaitUntil(d => d.FindElement(By.CssSelector("#checkout-step-payment-info")).GetAttribute("style").Contains("display: none;"));

            return this;
        }

        public CheckoutPage SetConfirmOrder()
        {
            GetElement("#confirm-order-buttons-container .confirm-order-next-step-button").Click();

            return this;
        }
        
        public bool IsBillingAddressNewFormDisabled()
        {
            return GetElement("#billing-new-address-form").GetAttribute("style").Contains("display: none;");
        }

        public double GetCartTotal()
        {
            var cartTotalElement = GetElement(".cart-total");
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);
            
            return cartTotalCompoenent.GetTotal();
        }

        public double GetShippingCost()
        {
            var cartTotalElement = GetElement(".cart-total");
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);

            return cartTotalCompoenent.GetShipping();
        }

        public double GetAdditionalFee()
        {
            var cartTotalElement = GetElement(".cart-total");
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);

            return cartTotalCompoenent.GetAdditionalFee();
        }

        public double GetSubTotal()
        {
            var cartTotalElement = GetElement(".cart-total");
            var cartTotalCompoenent = new CartTotalComponent(cartTotalElement);

            return cartTotalCompoenent.GetSubTotal();
        }
    }
}

