using OpenQA.Selenium;

namespace Youi_Automation_Tests.Src.Component
{
    public class ItemBoxComponent: BaseComponent
    {
        public ItemBoxComponent(IWebElement root): base(root)
        {
        }

        public void clickAddToCart()
        {
            root.FindElement(By.CssSelector(".product-box-add-to-cart-button")).Click();
        }

        public string getProductTitle()
        {
           return root.FindElement(By.CssSelector(".product-title")).Text;
        }
    }
}
