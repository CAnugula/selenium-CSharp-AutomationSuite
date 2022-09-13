using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Youi_Automation_Tests.Src.Component
{
    public class CartTotalComponent:BaseComponent
    {
        public CartTotalComponent(IWebElement root):base(root)
        {

        }

        public List<IWebElement> getRows()
        {
            return new List<IWebElement>(root.FindElements(By.CssSelector("tr")));
        }

        public double getSubTotal()
        {
            return double.Parse(getRows().Find(e => e.FindElement(By.CssSelector(".cart-total-left")).Text.Contains("Sub-Total"))
                .FindElement(By.CssSelector(".cart-total-right")).Text);
        }

        public double getShipping()
        {
            return double.Parse(getRows().Find(e => e.FindElement(By.CssSelector(".cart-total-left")).Text.Contains("Shipping"))
                .FindElement(By.CssSelector(".cart-total-right")).Text);
        }

        public double getAdditionalFee()
        {
            return double.Parse(getRows().Find(e => e.FindElement(By.CssSelector(".cart-total-left")).Text.Contains("Payment method additional fee:"))
                .FindElement(By.CssSelector(".cart-total-right")).Text);
        }

        public double getTotal()
        {
            return double.Parse(getRows().Find(e => e.FindElement(By.CssSelector(".cart-total-left")).Text.Equals("Total:"))
                .FindElement(By.CssSelector(".cart-total-right")).Text);
        }
    }
}
