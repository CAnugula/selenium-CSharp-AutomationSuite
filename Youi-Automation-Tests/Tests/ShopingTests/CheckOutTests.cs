using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Youi_Automation_Tests.Src.DataObject;

namespace Youi_Automation_Tests.Tests.ShopingTests
{
    [TestClass]
    public class CheckOutTests: BaseTest
    {
        [TestMethod]
        public void Checkout_ValidateTotalWithDefaultSettings()
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
            productPage.addItemToCart("Computing and Internet");
            productPage.HasLoadingSpinnerDisappeared();
            
            var billingAddress = new BillingAddress();
            billingAddress.firstName = "Jason";
            billingAddress.lastName = "Rodrick";
            billingAddress.email = "test@Automation.com";
            billingAddress.country = "Australia";
            billingAddress.city = "Sydney";
            billingAddress.address = "test";
            billingAddress.postalCode = "2334";
            billingAddress.phoneNumber = "0444667766";
            var checkOutPage = productPage.goToShoppingCart()
                                            .clickIAgree()
                                            .goToCheckout();
            if (checkOutPage.isBillingAddressNewFormDisabled())
                checkOutPage.clickContinue()
                    .setShippingAddress()
                    .setShippingMethod()
                    .setPaymentMethod()
                    .setPaymentInformation()
                    .setConfirmOrder();
            else

                checkOutPage 
                .setBillingAddress(billingAddress)
                .setShippingAddress()
                .setShippingMethod()
                .setPaymentMethod()
                .setPaymentInformation()
                .setConfirmOrder();

            Assert.AreEqual(checkOutPage.getCartTotal(), checkOutPage.getShippingCost() + checkOutPage.getAdditionalFee() + checkOutPage.getSubTotal());
            Assert.IsTrue(checkOutPage.getOrderStatusMessage().Contains("successfully processed!"));
        }
    }
}
