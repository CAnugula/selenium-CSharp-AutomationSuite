using OpenQA.Selenium;

namespace Youi_Automation_Tests.Src.Component
{
    public abstract class BaseComponent
    {
        protected IWebElement root;
        protected IWebDriver driver;

        public BaseComponent(IWebElement root)
        {
            this.root = root;
            this.driver = ((IWrapsDriver)root).WrappedDriver;
        }

        public string GetText() => root.Text;
    }
}
