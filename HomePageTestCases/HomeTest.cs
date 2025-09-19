using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using find_information_products_services_tests.HomePageTestCases.constants;
using FiPSAutomation.HomePageTestCases.utilities;
using Microsoft.Playwright;
using Microsoft.VisualBasic;

namespace FiPSAutomation.HomePageTestCases
{
    public class HomeTest : BaseTest
    {

        [Test, Order(1), Category("smoke")]
        public async Task LoginWithUsernameAndPassword() {
            await page.GotoAsync(URLConstant.LOGIN_OAUTH_URL);
            await page.GetByPlaceholder("Email or phone").ClickAsync();

            await page.GetByPlaceholder("Email or phone").FillAsync(LoginConstant.USERNAME);

            await page.GetByRole(AriaRole.Button, new() { NameString = "Next" }).ClickAsync();
            await page.WaitForURLAsync(URLConstant.LOGIN_SSO_URL);

            await page.GetByPlaceholder("Password").ClickAsync();

            await page.GetByPlaceholder("Password").FillAsync(LoginConstant.PASSWORD);

            await page.GetByRole(AriaRole.Button, new() { NameString = "Sign in" }).ClickAsync();
            await page.WaitForURLAsync(URLConstant.LOGIN_URL);

            await page.GetByRole(AriaRole.Button, new() { NameString = "Yes" }).ClickAsync();
            await page.WaitForURLAsync(URLConstant.FIPS_URL);
            extentTest?.Log(Status.Pass, "Pressed Enter");
        }

        [Test, Order(2), Category("functional")]
        public async Task AcceptCookiesAndHide() {
            await page.GetByRole(AriaRole.Button, new() { NameString = "Accept analytics cookies" }).ClickAsync();

            await page.GetByRole(AriaRole.Button, new() { NameString = "Hide cookie message" }).ClickAsync();
        }

        [Test, Order(3), Category("functional")]
        public async Task HomePageVerificationAC1() {
            await Assertions.Expect(page).ToHaveTitleAsync("Find information about products and services - FIPS");
            await Assertions.Expect(page.GetByText("Find information about products and services")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use this service to explore what DfE delivers. Build on existing work, avoid duplication, and work more effectively across teams.")).ToBeVisibleAsync();

            var searchlink = page.Locator(FipsLocator.HOME_SEARCH_LOCATOR);
            await Assertions.Expect(searchlink).ToHaveTextAsync(" Search products and services ");
            extentTest?.Log(Status.Pass, "Search assertion passed"); 

            var link1 = page.Locator(FipsLocator.ABOUT_SERVICE_LOCATOR);
            await Assertions.Expect(link1).ToHaveTextAsync("About this service");
            extentTest?.Log(Status.Pass, "About this service assertion passed");
        }

        [Test, Order(4), Category("functional")]
       public async Task ClickSearchButtonAC2()
        {
            await page.Locator(FipsLocator.HOME_SEARCH_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await page.GoBackAsync();
            extentTest?.Log(Status.Pass, "clickSearchButtonAC2 passed");

        }

        [Test, Order(5), Category("functional")]
        public async Task ClickAboutThisServiceAC3()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "About this service" }).ClickAsync();
           // await page.Locator("//*[contains(text(),'About this service')]").ClickAsync();
            await Assertions.Expect(page.GetByText("About this service")).ToBeVisibleAsync();
            await page.GoBackAsync();
            extentTest?.Log(Status.Pass, "clickAboutThisServiceAC3 passed");
        }

        [Test, Order(6), Category("functional")]
        public async Task TilesAreVisibleAC4()
        {
            //await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "All products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("All products and services")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Browse categories")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Using this service")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use the data")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Keeping information updated")).ToBeVisibleAsync();
            extentTest?.Log(Status.Pass, "TilesAreVisibleAC4 passed");
        }

        [Test, Order(7), Category("functional")]
        public async Task ClickAllproductsAndServicesAC5()
        {
            await page.Locator(FipsLocator.ALL_PRODUCT_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await page.GoBackAsync();
            extentTest?.Log(Status.Pass, "ClickAllproductsAndServicesAC5 passed");
        }

        [Test, Order(8), Category("functional")]
        public async Task ClickBrowseCategoriesAC6()
        {
            await page.Locator(FipsLocator.BROWSE_CATEGORY_LOCATOR).ClickAsync();
            //await Assertions.Expect(page.GetByText("Browse categories")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            extentTest?.Log(Status.Pass, "ClickBrowseCategoriesAC6 passed");
        }

        [Test, Order(9), Category("functional")]
        public async Task ClickUseTheDataAC7()
        {
            await page.Locator(FipsLocator.USE_DATA_LOCATOR).ClickAsync();           
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Using the data" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            extentTest?.Log(Status.Pass, "ClickUseTheDataAC7 passed");
        }

        [Test, Order(10), Category("functional")]
        public async Task ClickKeepingInformationUpdatedAC8()
        {
            await page.Locator(FipsLocator.KEEPING_INFO_UPDATE_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Get help" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            extentTest?.Log(Status.Pass, "ClickKeepingInformationUpdatedAC8 passed");
        }
    }
}
