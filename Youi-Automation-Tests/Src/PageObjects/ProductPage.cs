using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Youi_Automation_Tests.Src.Component;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public class ProductPage:BasePage
    {
        public ProductPage(IWebDriver driver):base(driver)
        {
        }

        public List<ItemBoxComponent> getProductList()
        {
            var ItemList = new List<IWebElement>(driver.FindElements(By.CssSelector(".product-item")))
                .ConvertAll(new Converter<IWebElement,ItemBoxComponent>(e => new ItemBoxComponent(e)));
            return ItemList;
        }

        public void addItemToCart(string itemName)
        {
            getProductList().Find(e => e.getProductTitle().Contains(itemName)).clickAddToCart();

        }
    }
}
