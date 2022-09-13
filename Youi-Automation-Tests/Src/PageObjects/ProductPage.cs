using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Youi_Automation_Tests.Src.Component;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public class ProductPage:BasePage
    {
        public ProductPage(IWebDriver driver):base(driver)
        {
        }

        public List<ItemBoxComponent> GetProductList()
        {
            var ItemList = new List<IWebElement>(GetElements(".product-item"))
                .ConvertAll(new Converter<IWebElement,ItemBoxComponent>(e => new ItemBoxComponent(e)));

            return ItemList;
        }

        public void AddItemToCart(string itemName)
        {
            GetProductList().Find(e => e.getProductTitle().Contains(itemName)).clickAddToCart();
        }
    }
}
