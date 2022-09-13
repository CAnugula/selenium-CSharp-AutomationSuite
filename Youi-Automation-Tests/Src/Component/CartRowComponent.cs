using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Youi_Automation_Tests.Src.Component
{
    public class CartRowComponent:BaseComponent
    {
        public CartRowComponent(IWebElement root):base(root)
        {

        }

        public CartRowComponent selectItemToRemove()
        {
            root.FindElement(By.CssSelector("[name='removefromcart']")).Click();
            return this;
        }

        public void updateItemQuantity()
        {
            root.FindElement(By.CssSelector(".qty-input")).Clear();
            root.FindElement(By.CssSelector(".qty-input")).SendKeys("2");
        }
    }
}
