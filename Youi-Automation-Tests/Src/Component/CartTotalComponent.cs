using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Youi_Automation_Tests.Src.Component
{
    public class CartTotalComponent: BaseComponent
    {
        public CartTotalComponent(IWebElement root): base(root)
        {

        }

        public double GetSubTotal()
        {
            return GetSummaryItem("Sub-Total");
        }

        public double GetShipping()
        {
            return GetSummaryItem("Shipping");
        }

        public double GetAdditionalFee()
        {
            return GetSummaryItem("Payment method additional fee:");
        }

        public double GetTotal()
        {
            var rows = GetSummaryRows();

            // equals check
            var value = rows.Find(e => e.FindElement(By.CssSelector(".cart-total-left"))
                            .Text.Equals("Total:"))
                            .FindElement(By.CssSelector(".cart-total-right")).Text;

            return Convert.ToDouble(value);
        }

        private List<IWebElement> GetSummaryRows()
        {
            return new List<IWebElement>(root.FindElements(By.CssSelector("tr")));
        }

        private double GetSummaryItem(string input)
        {
            var rows = GetSummaryRows();

            var value = rows.Find(e => e.FindElement(By.CssSelector(".cart-total-left"))
                            .Text.Contains(input))
                            .FindElement(By.CssSelector(".cart-total-right")).Text;

            return Convert.ToDouble(value);
        }
    }
}
