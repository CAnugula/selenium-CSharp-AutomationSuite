using OpenQA.Selenium;
using Youi_Automation_Tests.Src.Util;

namespace Youi_Automation_Tests.Src.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver):base(driver)
        {
        }

        public ProductPage GoToBooks()
        {
            GetTopMenuList().Find(e => e.Text.ContainsIgnoreCase("Books")).Click();

            return new ProductPage(driver);
        }

    }
}
