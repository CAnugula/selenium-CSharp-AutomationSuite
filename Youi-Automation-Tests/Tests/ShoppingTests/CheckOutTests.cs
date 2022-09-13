using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var cartItemsCount = homePage.goToShoppingCart().getItemCountInShoppingCart();
            if (cartItemsCount != 0)
            {
                homePage.goToShoppingCart().removeAndUpdateCartItems();
            }

            var productPage = homePage.goToBooks();

            // Add items to cart
            productPage.addItemToCart("Fiction");
            productPage.HasLoadingSpinnerDisappeared();

            productPage.addItemToCart("Computing and Internet");
            productPage.HasLoadingSpinnerDisappeared();
            
            // Fill out billing address
            var billingAddress = new BillingAddress();
            billingAddress.firstName = "Jason";
            billingAddress.lastName = "Rodrick";
            billingAddress.email = "test@Automation.com";
            billingAddress.country = "Australia";
            billingAddress.city = "Sydney";
            billingAddress.address = "test";
            billingAddress.postalCode = "2334";
            billingAddress.phoneNumber = "0444667766";

            // Go to checkout
            var checkOutPage = productPage.goToShoppingCart()
                                            .clickIAgree()
                                            .goToCheckout();

            // Existing user
            if (checkOutPage.isBillingAddressNewFormDisabled())
            {
                checkOutPage.clickContinue()
                    .setShippingAddress()
                    .setShippingMethod()
                    .setPaymentMethod()
                    .setPaymentInformation()
                    .setConfirmOrder();
            }
            else
            {
                // Fresh checkout
                checkOutPage
                .setBillingAddress(billingAddress)
                .setShippingAddress()
                .setShippingMethod()
                .setPaymentMethod()
                .setPaymentInformation()
                .setConfirmOrder();
            }

            var calculatedTotal = checkOutPage.getShippingCost() + checkOutPage.getAdditionalFee() + checkOutPage.getSubTotal();

            Assert.AreEqual(checkOutPage.getCartTotal(), calculatedTotal);
            Assert.IsTrue(checkOutPage.getOrderStatusMessage().Contains("successfully processed!"));
        }
    }
}
