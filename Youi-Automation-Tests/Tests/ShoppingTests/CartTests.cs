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

            var cartItemsCount = homePage.goToShoppingCart().getItemCountInShoppingCart();
            if (cartItemsCount != 0)
            {
                homePage.goToShoppingCart().removeAndUpdateCartItems();
            }

            var productPage = homePage.goToBooks();

            // Add items to cart
            productPage.addItemToCart("Fiction");
            productPage.HasLoadingSpinnerDisappeared();
            productPage.addItemToCart("Health Book");
            productPage.HasLoadingSpinnerDisappeared();

            Assert.AreEqual(productPage.getItemCountInShoppingCart(), 2);
            Assert.AreEqual(homePage.goToShoppingCart().getCartSubTotal(), 34.00);
        }

    }
}
