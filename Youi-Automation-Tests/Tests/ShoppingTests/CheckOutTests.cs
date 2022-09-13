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
            var cartItemsCount = homePage.GoToShoppingCart().GetItemCountInShoppingCart();
            if (cartItemsCount != 0)
            {
                homePage.GoToShoppingCart().RemoveAndUpdateCartItems();
            }

            var productPage = homePage.GoToBooks();

            // Add items to cart
            productPage.AddItemToCart("Fiction");
            productPage.HasLoadingSpinnerDisappeared();

            productPage.AddItemToCart("Computing and Internet");
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
            var checkOutPage = productPage.GoToShoppingCart()
                                            .ClickIAgree()
                                            .GoToCheckout();

            // Existing user
            if (checkOutPage.IsBillingAddressNewFormDisabled())
            {
                checkOutPage.ClickContinue()
                    .SetShippingAddress()
                    .SetShippingMethod()
                    .SetPaymentMethod()
                    .SetPaymentInformation()
                    .SetConfirmOrder();
            }
            else
            {
                // Fresh checkout
                checkOutPage
                .SetBillingAddress(billingAddress)
                .SetShippingAddress()
                .SetShippingMethod()
                .SetPaymentMethod()
                .SetPaymentInformation()
                .SetConfirmOrder();
            }

            var calculatedTotal = checkOutPage.GetShippingCost() + checkOutPage.GetAdditionalFee() + checkOutPage.GetSubTotal();

            Assert.AreEqual(checkOutPage.GetCartTotal(), calculatedTotal);
            Assert.IsTrue(checkOutPage.GetOrderStatusMessage().Contains("successfully processed!"));
        }
    }
}
