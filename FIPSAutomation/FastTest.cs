using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using find_information_products_services_tests.constants;
using find_information_products_services_tests.utilities;
using FiPSAutomation;
using Microsoft.Playwright;
using static find_information_products_services_tests.utilities.ExcelReader;

namespace find_information_products_services_tests
{
    internal class FastTest : BaseTest
    {

        [Test, Order(1), Category("smoke")]
        public async Task LoginWithUsernameAndPassword()
        {
            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
        }

        [Test, Order(2), Category("functional")]
        public async Task VerifyMissingProductOrServiceLink_ProductsPageUS219AC()
        {
            goToLink("products");
            await page.Locator(FipsLocator.MISSING_PROD_SERVICE_LINK).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.REQUEST_NEW_PRODUCT_DESC)).ToContainTextAsync("If you cannot find a product or service, make a ");
            await page.GetByRole(AriaRole.Link, new() { NameString = "request for a new product entry" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Request a new product entry" })).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "VerifyMissingProductOrServiceLink_ProductsPageUS219AC");
        }
    }
}
