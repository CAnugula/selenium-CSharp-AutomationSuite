using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Youi_Automation_Tests.Src.Component
{
    public class BillingAddressComponent : BaseComponent
    {
        public BillingAddressComponent(IWebElement root) : base(root)
        {

        }

        public void SetFirstName(string name)
        {
            root.FindElement(By.CssSelector("#BillingNewAddress_FirstName")).Clear();
            root.FindElement(By.CssSelector("#BillingNewAddress_FirstName")).SendKeys(name);
        }
        public void SetLastName(string name)
        {
            root.FindElement(By.CssSelector("#BillingNewAddress_LastName")).Clear();
            root.FindElement(By.CssSelector("#BillingNewAddress_LastName")).SendKeys(name);
        }
        public void SetEmail(string email)
        {
            root.FindElement(By.CssSelector("#BillingNewAddress_Email")).Clear();
            root.FindElement(By.CssSelector("#BillingNewAddress_Email")).SendKeys(email);
        }
        public void SetCountry(string country)
        {
            //root.FindElement(By.CssSelector("#BillingNewAddress_CountryId")).Clear();
            root.FindElement(By.CssSelector("#BillingNewAddress_CountryId")).SendKeys(country);
        }
        public void SetCity(string city)
        {
            root.FindElement(By.CssSelector("#BillingNewAddress_City")).Clear();
            root.FindElement(By.CssSelector("#BillingNewAddress_City")).SendKeys(city);
        }
        public void SetAddress(string address)
        {
            root.FindElement(By.CssSelector("#BillingNewAddress_Address1")).Clear();
            root.FindElement(By.CssSelector("#BillingNewAddress_Address1")).SendKeys(address);
        }
        public void SetPostalCode(string postalCode)
        {
            root.FindElement(By.CssSelector("#BillingNewAddress_ZipPostalCode")).Clear();
            root.FindElement(By.CssSelector("#BillingNewAddress_ZipPostalCode")).SendKeys(postalCode);
        }
        public void SetPhoneNumber(string phoneNumber)
        {
            root.FindElement(By.CssSelector("#BillingNewAddress_PhoneNumber")).Clear();
            root.FindElement(By.CssSelector("#BillingNewAddress_PhoneNumber")).SendKeys(phoneNumber);
        }

        
    }
}
