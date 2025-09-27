using AventStack.ExtentReports;
using find_information_products_services_tests.HomePageTestCases.constants;
using find_information_products_services_tests.HomePageTestCases.utilities;
using Microsoft.Playwright;

namespace FiPSAutomation.HomePageTestCases
{
    public class HomeTest : BaseTest
    {
        [Test, Order(1), Category("smoke")]
        public async Task LoginWithUsernameAndPassword()
        {
            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
        }

        [Test, Order(2), Category("functional")]
        public async Task HomePageVerificationAC1()
        {
            await Assertions.Expect(page).ToHaveTitleAsync("Find information about products and services - FIPS");
            //await Assertions.Expect(page.GetByText("Find information about products and services")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Find information about products and services" })).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByText("Use this service to explore what DfE delivers. Build on existing work, avoid duplication, and work more effectively across teams.")).ToBeVisibleAsync();

            var searchlink = page.Locator(FipsLocator.HOME_SEARCH_LOCATOR);
            await Assertions.Expect(searchlink).ToHaveTextAsync(" Search products and services ");
            extentTest?.Log(Status.Pass, "Search assertion passed");

            var link1 = page.Locator(FipsLocator.ABOUT_SERVICE_LOCATOR);
            await Assertions.Expect(link1).ToHaveTextAsync("About this service");

            extentTest?.Log(Status.Pass, "homePageVerificationAC1 assertion passed");
        }

        [Test, Order(3), Category("functional")]
        public async Task ClickSearchButtonAC2()
        {
            await page.Locator(FipsLocator.HOME_SEARCH_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "clickSearchButtonAC2 passed");
        }

        [Test, Order(4), Category("functional")]
        public async Task ClickAboutThisServiceAC3()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "About this service" }).ClickAsync();
            await Assertions.Expect(page.GetByText("About this service")).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "clickAboutThisServiceAC3 passed");
        }

        [Test, Order(5), Category("functional")]
        public async Task TilesAreVisibleAC4()
        {
            //await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "All products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("All products and services")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Browse categories")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Using this service")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use the data")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Keeping information updated")).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "tilesAreVisibleAC4 passed");
        }

        [Test, Order(6), Category("functional")]
        public async Task ClickAllproductsAndServicesAC5()
        {
            await page.Locator(FipsLocator.ALL_PRODUCT_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "clickAllproductsAndServicesAC5 passed");
        }

        [Test, Order(7), Category("functional")]
        public async Task ClickBrowseCategoriesAC6()
        {
            await page.Locator(FipsLocator.BROWSE_CATEGORY_LOCATOR).ClickAsync();
            //await Assertions.Expect(page.GetByText("Browse categories")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "clickBrowseCategoriesAC6 passed");
        }

        [Test, Order(8), Category("functional")]
        public async Task ClickUseTheDataAC7()
        {
            await page.Locator(FipsLocator.USE_DATA_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Using the data" })).ToBeVisibleAsync();

            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "clickUseTheDataAC7 passed");
        }

        [Test, Order(9), Category("functional")]
        public async Task ClickKeepingInformationUpdatedAC8()
        {
            await page.Locator(FipsLocator.KEEPING_INFO_UPDATE_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Get help" })).ToBeVisibleAsync();

            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "clickKeepingInformationUpdatedAC8 passed");
        }

        [Test, Order(10), Category("functional")]
        public async Task CheckPageDescriptionAC2()
        {
            await page.Locator(FipsLocator.BROWSE_CATEGORY_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Find products and services by how they are categorised", new() { Exact = true })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "checkPageDescriptionAC2 passed");
        }

        [Test, Order(11), Category("functional")]
        public async Task CheckCategoriesListAndDescriptionAC3()
        {
            //verifying Channel link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Channel" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The delivery channel through which a product or service is provided to users.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("9 options", new() { Exact = true })).ToBeVisibleAsync();

            //verifying Group Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Group" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The business area or portfolio responsible for a product or service.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("5 main categories", new() { Exact = true })).ToBeVisibleAsync();

            //verifying Phase Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Phase" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The stage a product or service is at in the service delivery lifecycle.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("10 options", new() { Exact = true })).ToBeVisibleAsync();

            //verifying Type Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Type" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The type of service delivery and functionality provided.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("4 options", new() { Exact = true })).ToBeVisibleAsync();

            //verifying User group Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "User group" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The users of the product or service.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("11 main categories", new() { Exact = true })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "checkCategoriesListAndDescriptionAC3 passed");
        }

        [Test, Order(12), Category("functional")]
        public async Task ClickCategoriesLinksAC4()
        {
            //await page.GotoAsync(URLConstant.FIPS_URL + "categories/channel");
            goToLink("categories/channel");
            await Assertions.Expect(page.GetByText("The delivery channel through which a product or service is provided to users.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Channel" })).ToBeVisibleAsync();

            //await page.Locator("a").Filter(new() { HasTextString = "Channel" }).Nth(1).ClickAsync();
            //await page.GetByText("The delivery channel through which a product or service is provided to users.").ClickAsync();
            //await page.Locator("a[href='/categories/channel']").Nth(1).ClickAsync();
            //await page.GetByRole(AriaRole.Link, new() { NameString = "Channel" }).ClickAsync();

            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync();
            //await page.GotoAsync(URLConstant.FIPS_URL + "categories/group");
            goToLink("categories/group");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Group" })).ToBeVisibleAsync();

            await page.GoBackAsync();
            //await page.GotoAsync(URLConstant.FIPS_URL + "categories/phase");
            goToLink("categories/phase");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Phase" })).ToBeVisibleAsync();

            await page.GoBackAsync();
            //await page.GotoAsync(URLConstant.FIPS_URL + "categories/type");
            goToLink("categories/type");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Type" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync();

            //await page.Locator(FipsLocator.USER_GROUP_CHEVRON_LINK).ClickAsync();
            //await page.GotoAsync(URLConstant.FIPS_URL + "categories/user-group");
            goToLink("categories/user-group");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "User group" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync();

            extentTest?.Log(Status.Pass, "clickCategoriesLinksAC4 passed");
        }

        [Test, Order(13), Category("functional")]
        public async Task CheckPhaseCategoryListAC1()
        {
            goToLink("categories/phase");
            await Assertions.Expect(page.GetByText("The stage a product or service is at in the service delivery lifecycle.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Request" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_REQUEST_LINK_DESC)).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Explore" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_EXPLORE_LINK_DESC)).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Triage" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_TRIAGE_LINK_DESC)).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Discovery" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_DISCOVERY_LINK_DESC)).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Alpha" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_ALPHA_LINK_DESC)).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Private beta" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_PRIVATEBETA_LINK_DESC)).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Public beta" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_PUBLICBETA_LINK_DESC)).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Live" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_LIVE_LINK_DESC)).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Decommissioning" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_DECOMMISSIONING_LINK_DESC)).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Decommissioned" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_DECOMMISSIONED_LINK_DESC)).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "CheckPhaseCategoryListAC1 passed");
        }

        [Test, Order(14), Category("functional")]
        public async Task ClickRequestLinkAC2()
        {
            //await page.Locator("[aria-hidden='true'][href='/products?phase=request']").WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
            //await page.Locator(FipsLocator.PHASE_REQUEST_LINK).ClickAsync();

            goToLink("products?phase=request");
            //clickLink(FipsLocator.PHASE_REQUEST_LINK);
            //await Task.Delay(5000);
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
            var requestTag = page.Locator("ul.moj-filter-tags li a:has-text('request')");

            // Assert that the filter tag exists and is visible
            await Assertions.Expect(requestTag).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(".moj-filter__tag")).ToHaveTextAsync(" Request");
            //await Assertions.Expect(page.Locator("//h3[normalize-space()='Phase']")).ToHaveTextAsync("Phase");
        }

        [Test, Order(15), Category("functional")]
        public async Task ClickRequestLinkAC2A()
        {
            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "products");
            // Iterate through each data row
            foreach (var row in dataRows)
            {
                //Task.Delay(1000);
                // Print a log to the NUnit output for traceability
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator} passed");

                goToLink(row.Product_Locator);

                var requestTag = page.Locator(row.Filter_Tag);

                // Assert that the filter tag exists and is visible
                await Assertions.Expect(requestTag).ToBeVisibleAsync();

                //Assert the text content of the filter tag toHaveTextAsync checks that the element has the exact text.
                await Assertions.Expect(requestTag).ToHaveTextAsync(row.Message);

                //Locate and assert the page header and "phase" subheading
                await Assertions.Expect(page.GetByRole(AriaRole.Heading,
                    new() { NameString = row.Heading })).ToBeVisibleAsync();

                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("Phase");

                bool isRequestChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isRequestChecked, Is.True);

                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator}") + " passed");
            }
        }
    }
}
