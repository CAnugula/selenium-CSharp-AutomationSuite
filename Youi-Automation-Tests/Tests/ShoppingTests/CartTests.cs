using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Youi_Automation_Tests.Tests.ShoppingTests
{
    [TestClass]
    public class CartTests : BaseTest
    {
        [TestMethod]
        public void Cart_AddItemsAndValidate()
        {
            var homePage = Login();

            var cartItemsCount = homePage.GoToShoppingCart().GetItemCountInShoppingCart();
            if (cartItemsCount != 0)
            {
                homePage.GoToShoppingCart().RemoveAndUpdateCartItems();
            }

            var productPage = homePage.GoToBooks();

            // Add items to cart
            productPage.AddItemToCart("Fiction");
            productPage.HasLoadingSpinnerDisappeared();
            productPage.AddItemToCart("Health Book");
            productPage.HasLoadingSpinnerDisappeared();

            Assert.AreEqual(productPage.GetItemCountInShoppingCart(), 2);
            Assert.AreEqual(homePage.GoToShoppingCart().GetCartSubTotal(), 34.00);
        }

    }
}
