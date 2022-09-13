using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Youi_Automation_Tests.Tests.ShopingTests
{
    [TestClass]
    public class CartTest:BaseTest
    {
        [TestMethod]
        public void Cart_AddItemsAndValidate()
        {
            var homePage = Login();
            var cartItemsCount = homePage.goToShoppingCart().getItemCountInShopingCart();
            if (cartItemsCount != 0)
            {
                homePage.goToShoppingCart().removeAndUpdateCartItems();
            }
            var productPage = homePage.goToBooks();
            productPage.addItemToCart("Fiction");
            productPage.HasLoadingSpinnerDisappeared();
            productPage.addItemToCart("Health Book");
            productPage.HasLoadingSpinnerDisappeared();

            Assert.AreEqual(productPage.getItemCountInShopingCart(), 2);

            Assert.AreEqual(homePage.goToShoppingCart().getCartSubTotal(), 34.00);           
        }

    }
}
