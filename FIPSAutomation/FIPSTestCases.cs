using AventStack.ExtentReports;
using Deque.AxeCore.Playwright;
using DocumentFormat.OpenXml.Wordprocessing;
using find_information_products_services_tests.constants;
using find_information_products_services_tests.utilities;
using Microsoft.Playwright;
using static find_information_products_services_tests.utilities.ExcelReader;

namespace FiPSAutomation
{
    public class FIPSTestCases : BaseTest
    {
        [Test, Order(1)]
        public async Task LoginWithUsernameAndPasswordUS231AC2()
        {
            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
        }

        [Test, Order(2), Category("functional")]
        public async Task HomePageVerificationUS12AC1()
        {
            await Assertions.Expect(page).ToHaveTitleAsync("Find information about products and services - FIPS");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Find information about products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use this service to explore what DfE delivers. Build on existing work, avoid duplication, and work more effectively across teams.")).ToBeVisibleAsync();
            var searchlink = page.Locator(FipsLocator.HOME_SEARCH_LOCATOR);
            await Assertions.Expect(searchlink).ToHaveTextAsync(" Search products and services ");

            //About this service link is removed -
            //var link1 = page.Locator(FipsLocator.ABOUT_SERVICE_LOCATOR);
            //await Assertions.Expect(link1).ToHaveTextAsync("About this service"); 

            extentTest?.Log(Status.Pass, "HomePageVerificationUS12AC1 assertion passed");
        }

        [Test, Order(3), Category("functional")]
        public async Task ClickSearchButtonUS12AC2()
        {
            await page.Locator(FipsLocator.HOME_SEARCH_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "ClickSearchButtonUS12AC2 passed");
        }

        [Test, Order(4), Category("functional")]
        public async Task VerifyTilesAreVisibleUS12AC4()
        {
            await Assertions.Expect(page.Locator(FipsLocator.HOME_PAGE_TILES)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "All products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Keep information updated" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "About this service" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Search and filter the products and services.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Find products and services by how they are categorised", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("How to update information about products listed in this service.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Find out what this service is and how it works.", new() { Exact = true })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyTilesAreVisibleUS12AC4 passed");
        }

        [Test, Order(5), Category("functional")]
        public async Task ClickAllProductsAndServicesUS12AC5()
        {
            await page.Locator(FipsLocator.ALL_PRODUCT_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "ClickAllProductsAndServicesUS12AC5 passed");
        }

        [Test, Order(6), Category("functional")]
        public async Task ClickBrowseCategoriesUS12AC6()
        {
            await page.Locator(FipsLocator.BROWSE_CATEGORY_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "ClickBrowseCategoriesUS12AC6 passed");
        }

        [Test, Order(7), Category("functional")]
        public async Task ClickAboutThisServiceTileUS12AC()
        {
            await page.Locator(FipsLocator.ABOUT_SERVICE_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("About this service", new() { Exact = true })).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "ClickAboutThisServiceTileUS12AC passed");
        }

        [Test, Order(8), Category("functional")]
        public async Task ClickKeepInformationUpdatedTileUS12AC8()
        {
            await page.Locator(FipsLocator.KEEP_INFO_UPDATE_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Keep information updated" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Search" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "request a new product entry" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Request a new product entry" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "About this service" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "About this service" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Contact us" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Contact us" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CONTACT_US_EMAIL_DESC)).ToBeVisibleAsync();
            await page.GoBackAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Find information about products and services" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Find information about products and services" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "ClickKeepInformationUpdatedTileUS12AC8 passed");
        }

        [Test, Order(9), Category("functional")]
        public async Task CheckBrowseCategoriesPageDescriptionUS05AC2()
        {

            await page.Locator(FipsLocator.BROWSE_CATEGORY_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Find products and services by how they are categorised", new() { Exact = true })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "CheckBrowseCategoriesPageDescriptionUS05AC2 passed");
        }

        [Test, Order(10), Category("functional")]
        public async Task CheckCategoriesListAndDescriptionUS05AC3()
        {
            //verifying Channel link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Channel" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The delivery channel through which a product or service is provided to users.", new() { Exact = true })).ToBeVisibleAsync();
            // await Assertions.Expect(page.GetByText("9 options", new() { Exact = true })).ToBeVisibleAsync();   //removing description check after discussion with PM

            //verifying Group Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Business area" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The business area or portfolio responsible for a product or service.", new() { Exact = true })).ToBeVisibleAsync();
            //  await Assertions.Expect(page.GetByText("11 main categories", new() { Exact = true })).ToBeVisibleAsync();

            //verifying Phase Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Phase" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The stage a product or service is at in the service delivery lifecycle.", new() { Exact = true })).ToBeVisibleAsync();
            //  await Assertions.Expect(page.GetByText("8 options", new() { Exact = true })).ToBeVisibleAsync();

            //verifying Type Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Type" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The type of service delivery and functionality provided.", new() { Exact = true })).ToBeVisibleAsync();
            //  await Assertions.Expect(page.GetByText("5 options", new() { Exact = true })).ToBeVisibleAsync();

            //verifying User group Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "User group" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The users of the product or service.", new() { Exact = true })).ToBeVisibleAsync();
            // await Assertions.Expect(page.GetByText("11 main categories", new() { Exact = true })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "CheckCategoriesListAndDescriptionUS05AC3 passed");
        }

        [Test, Order(11), Category("functional")]
        public async Task ClickCategoriesLinksUS05AC4()
        {
            //await page.GotoAsync(URLConstant.DEV_FIPS_URL + "categories/channel");
            goToLink("categories/channel");
            await Assertions.Expect(page.GetByText("The delivery channel through which a product or service is provided to users.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Channel" })).ToBeVisibleAsync();

            //await page.Locator("a").Filter(new() { HasTextString = "Channel" }).Nth(1).ClickAsync(); 
            //await page.GetByText("The delivery channel through which a product or service is provided to users.").ClickAsync();
            //await page.Locator("a[href='/categories/channel']").Nth(1).ClickAsync();
            //await page.GetByRole(AriaRole.Link, new() { NameString = "Channel" }).ClickAsync();

            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync();
            //await page.GotoAsync(URLConstant.DEV_FIPS_URL + "categories/group");
            goToLink("categories/business-area");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Business area" })).ToBeVisibleAsync();
            await page.GoBackAsync();

            goToLink("categories/phase");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Phase" })).ToBeVisibleAsync();
            await page.GoBackAsync();

            goToLink("categories/type");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Type" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync();

            //await page.Locator(FipsLocator.USER_GROUP_CHEVRON_LINK).ClickAsync();
            goToLink("categories/user-group");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "User group" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync();

            extentTest?.Log(Status.Pass, "ClickCategoriesLinksUS05AC4 passed");
        }

        [Test, Order(12), Category("functional")]
        public async Task VerifyPhaseCategoryListUS35AC1()
        {
            goToLink("categories/phase");
            await Assertions.Expect(page.GetByText("The stage a product or service is at in the service delivery lifecycle.", new() { Exact = true })).ToBeVisibleAsync();
            // await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Request" })).ToBeVisibleAsync();
            // await Assertions.Expect(page.Locator(FipsLocator.PHASE_REQUEST_LINK_DESC)).ToHaveTextAsync("View products in this category";
            // await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Explore" })).ToBeVisibleAsync();
            // await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Triage" })).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Discovery" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Alpha" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Did not progress" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Private beta" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Public beta" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Live" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Decommissioning" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Decommissioned" })).ToBeVisibleAsync();

            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync(); //verifying Back link
            extentTest?.Log(Status.Pass, "VerifyPhaseCategoryListUS35AC1 passed");
        }

        //[Test, Order(14), Category("functional")]
        //public async Task ClickRequestSubcategoryLinkAC2()
        //{
        //    //await page.Locator("[aria-hidden='true'][href='/products?phase=request']").WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
        //    //await page.Locator(FipsLocator.PHASE_REQUEST_LINK).ClickAsync();

        //    goToLink("products?phase=request");
        //    //clickLink(FipsLocator.PHASE_REQUEST_LINK);
        //    //await Task.Delay(5000);
        //    await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
        //    var requestTag = page.Locator("ul.moj-filter-tags li a:has-text('request')");

        //    // Assert that the filter tag exists and is visible
        //    await Assertions.Expect(requestTag).ToBeVisibleAsync();
        //    //await Assertions.Expect(page.Locator(".moj-filter__tag")).ToHaveTextAsync(" Request");
        //}

        [Test, Order(13), Category("functional")]
        public async Task ClickSubcategoryLinksForPhaseCategory_US275AllAC()
        {
            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "category_phase");
            // Iterate through each data row
            foreach (var row in dataRows)
            {
                // Print a log to the NUnit output for traceability
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator} passed");

                goToLink(row.Product_Locator);
                await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).ToContainTextAsync("your selected filters");
                var requestTag = page.Locator(row.Filter_Tag);

                // Assert that the filter tag exists and is visible
                await Assertions.Expect(requestTag).ToBeVisibleAsync();

                //Assert the text content of the filter tag toHaveTextAsync checks that the element has the exact text.
                await Assertions.Expect(requestTag).ToHaveTextAsync(row.Message);

                //Locate and assert the page header and "phase" subheading
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("Phase");
                bool isRequestChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isRequestChecked, Is.True);
                await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator}") + " passed");
            }
        }

        [Test, Order(14), Category("functional")]
        public async Task VerifyChannelCategoryListUS26AC1()
        {
            goToLink("categories/channel");
            await Assertions.Expect(page.GetByText("The delivery channel through which a product or service is provided to users.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Chat" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CHAT_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Email" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Face-to-face" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Native app" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Other digital media" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Phone" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Print media" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "SMS" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Web" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelCategoryListUS26AC1 passed");
        }

        [Test, Order(15), Category("functional")]
        public async Task ClickSubcategoryLinksForChannel_US273AllAC()
        {
            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "category_channel");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator} passed");

                goToLink(row.Product_Locator);
                await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).ToContainTextAsync("your selected filters");
                var requestTag = page.Locator(row.Filter_Tag);
                await Assertions.Expect(requestTag).ToBeVisibleAsync();
                await Assertions.Expect(requestTag).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("Channel");
                bool isRequestChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isRequestChecked, Is.True);
                await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
                await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator}") + " passed");
            }
        }

        [Test, Order(16), Category("functional")]
        public async Task VerifyBusinessAreaCategoryListUS27AC1()
        {
            goToLink("categories/business-area");
            await Assertions.Expect(page.GetByText("The business area or portfolio responsible for a product or service.", new() { Exact = true })).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Commercial" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Customer Experience and Design" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.OPERATIONSANDINFRA_CXD_LINK_DESC)).ToHaveTextAsync("View products in this category");
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Enterprise Data" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Children and Families" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Funding and Financial Oversight" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Operations and Infrastructure" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Regional Digital Services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Schools Digital" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Sector Facing Services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Skills and Growth" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Strategy" })).ToBeVisibleAsync();

            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync(); //verify Back link on page

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaCategoryListAC passed");
        }

        [Test, Order(17), Category("functional")]
        public async Task ClickSubcategoryLinksForBusinessArea_US274AllAC()
        {
            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "category_businessarea");

            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator} passed");

                goToLink(row.Product_Locator);
                await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).ToContainTextAsync("your selected filters");
                var requestTag = page.Locator(row.Filter_Tag);
                await Assertions.Expect(requestTag).ToBeVisibleAsync();
                await Assertions.Expect(requestTag).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("Business area");
                bool isRequestChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isRequestChecked, Is.True);
                await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
                await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator}") + " passed");
            }
        }

        [Test, Order(18), Category("functional")]
        public async Task VerifyTypeCategoryListUS29AC1()
        {
            goToLink("categories/type");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Type" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The type of service delivery and functionality provided.", new() { Exact = true })).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "API" })).ToBeVisibleAsync();
            // await Assertions.Expect(page.Locator(FipsLocator.TYPE_API_LINK_DESC)).ToHaveTextAsync("View products in this category");
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Campaign" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.TYPE_CAMPAIGN_LINK_DESC)).ToHaveTextAsync("View products in this category");
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Data" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Information" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Transactional" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyTypeCategoryListUS29AC1 passed");
        }

        [Test, Order(19), Category("functional")]
        public async Task ClickSubcategoryLinksForTypeUS29AC2()
        {
            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "category_type");
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

                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("Type");

                bool isRequestChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isRequestChecked, Is.True);

                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator}") + " passed");
            }
        }

        [Test, Order(20), Category("functional")]
        public async Task VerifyUserGroupCategoryListUS30AC()
        {
            goToLink("categories/user-group");
            await Assertions.Expect(page.GetByText("The users of the product or service.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Adult learner (18+)" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_ADULTLEARNER_LINK_DESC)).ToHaveTextAsync("4 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Careers adviser or work coach" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_CAREERSADVISER_LINK_DESC)).ToHaveTextAsync("3 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Child or young person" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_CHILDORYOUNGPERSON_LINK_DESC)).ToHaveTextAsync("5 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Department for Education workforce" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_DFEWORKFORCE_LINK_DESC)).ToHaveTextAsync("4 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Education provider and early years workforce" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_EPANDEYWORKFORCE_LINK_DESC)).ToHaveTextAsync("7 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Employer" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_EMPLOYER_LINK_DESC)).ToHaveTextAsync("3 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Local authority workforce" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_LAWORKFORCE_LINK_DESC)).ToHaveTextAsync("5 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "NEET or career seeker" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_NEETORCS_LINK_DESC)).ToHaveTextAsync("5 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Parent or carer" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_PARENTORCARER_LINK_DESC)).ToHaveTextAsync("8 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Professional external user of DfE data" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_PROFEXTERUSERDFE_LINK_DESC)).ToHaveTextAsync("6 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Social care workforce" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERGROUP_SCWORKFORCE_LINK_DESC)).ToHaveTextAsync("8 sub-categories");

            extentTest?.Log(Status.Pass, "VerifyUserGroupCategoryListUS30AC passed");
        }

        [Test, Order(21), Category("functional")]
        public async Task VerifyUGAdultLearner18SubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_AdultLearner18_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Adult learner (18+)");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();

                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                //await Assertions.Expect(page.GetByText(dataRows[1].Col3, new() { Exact = true })).ToBeVisibleAsync();

                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);
                //await Assertions.Expect(page.GetByText(dataRows[2].Col3, new() { Exact = true })).ToBeVisibleAsync();

                //await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                for (int i = 3; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGAdultLearner18SubcategoryListUS30AC passed");
            }
        }

        [Test, Order(22), Category("functional")]
        public async Task VerifyUGCareersAdviserOrWorkCoachSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_CareersAdviser_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Careers adviser or work coach");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGCareersAdviserOrWorkCoachSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(23), Category("functional")]
        public async Task VerifyUGChildOrYoungPersonSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_ChildOrYoungPers_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Child or young person");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGChildOrYoungPersonSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(24), Category("functional")]
        public async Task VerifyUGDfEWorkforceSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_DfEWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Department for Education workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGDfEWorkforceSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(25), Category("functional")]
        public async Task VerifyUGEPAndEYWorkforceSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_EPandEYWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Education provider and early years workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGEPAndEYWorkforceSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(26), Category("functional")]
        public async Task VerifyUGEmployerSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_Employer_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Employer");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGEmployerSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(27), Category("functional")]
        public async Task VerifyUGLocalAuthorityWorkforceSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_LAWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Local authority workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGLocalAuthorityWorkforceSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(28), Category("functional")]
        public async Task VerifyUGNEETOrCareerSeekerSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_NEETOrCareerSeek_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("NEET or career seeker");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGNEETOrCareerSeekerSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(29), Category("functional")]
        public async Task VerifyUGParentOrCarerSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_ParentorCarer_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Parent or carer");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGParentOrCarerSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(30), Category("functional")]
        public async Task VerifyUGProfExternalUserofDfEDataSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_ProfExtUserofDfE_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Professional external user of DfE data");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGProfExternalUserofDfEDataSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(31), Category("functional")]
        public async Task VerifyUGSocialCareWorkforceSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_SocialCWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Social care workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGSocialCareWorkforceSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(32), Category("functional")]
        public async Task ClickSubcategoryLinksForAdultLearnerUS90AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_AdultLearner");
            // Iterate through each data row
            foreach (var row in dataRows)
            {
                // Print a log to the NUnit output for traceability
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);

                // Assert that the filter tag exists and is visible
                await Assertions.Expect(FilterText).ToBeVisibleAsync();

                //Assert the text content of the filter tag toHaveTextAsync checks that the element has the exact text.
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);

                //Locate and assert the page header 
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();

                //Assert the "User groups" subheading
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");

                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);

                //verifying selectedUserTypes
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                //await Assertions.Expect(page.GetByLabel("Adult learner (18+)")).ToBeVisibleAsync();

                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(33), Category("functional")]
        public async Task ClickSubcategoryLinksForCareersAdviserOrWorkCoachUS91AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_CareersAdviser");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(34), Category("functional")]
        public async Task ClickSubcategoryLinksForChildOrYoungPersonUS92AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_ChildOrYoungPers");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(35), Category("functional")]
        public async Task ClickSubcategoryLinksForDfEWorkforceUS93AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_DfEWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(36), Category("functional")]
        public async Task ClickSubcategoryLinksForEmployerUS96AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_Employer");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(37), Category("functional")]
        public async Task ClickSubcategoryLinksForLocalAuthorityWorkforceUS97AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_LAWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(38), Category("functional")]
        public async Task ClickSubcategoryLinksForNEETOrCareerSeekerUS98AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_NEETOrCareerSeek");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(39), Category("functional")]
        public async Task ClickSubcategoryLinksForParentOrCarerUS99AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_ParentOrCarer");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(40), Category("functional")]
        public async Task ClickSubcategoryLinksForProfExternalUserofDfEDataUS100AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcateg_ProfExtUserofDfEData");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(41), Category("functional")]
        public async Task VerifyFooterCookiesLinkUS13AC()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Cookies" }).ClickAsync();
            await Assertions.Expect(page.GetByText("Cookie preferences", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Button, new() { NameString = "Save cookie preferences" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Cancel" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Change cookie preferences" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Back to home" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyFooterCookiesLinkUS13AC passed");
        }

        [Test, Order(42), Category("functional")]
        public async Task VerifyCookiesPageFunctionalitiesUS13AC()
        {
            goToLink("cookies");
            await page.Locator(FipsLocator.SAVE_COOKIES_RADIO_OFF).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Save cookie preferences" }).ClickAsync();
            bool alert = await page.Locator(FipsLocator.SAVE_COOKIES_ALERT).IsVisibleAsync();
            Assert.That(alert, Is.True);
            await Assertions.Expect(page.Locator(FipsLocator.SAVE_COOKIES_ALERT)).ToContainTextAsync("Your cookie preferences have been saved.");
            await page.Locator(FipsLocator.SAVE_COOKIES_RADIO_ON).CheckAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Cancel" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Find information about products and services" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyCookiesPageFunctionalitiesUS13AC passed");
        }

        [Test, Order(43), Category("functional")]
        public async Task VerifyCookiesPageBackToHomeFunctionalityUS13AC()
        {
            goToLink("cookies");
            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to home" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Find information about products and services" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyCookiesPageBackToHomeFunctionalityUS13AC passed");
        }

        [Test, Order(44), Category("functional")]
        public async Task VerifyAccessibilityLinkUS16AC()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Accessibility statement" }).ClickAsync();
            await Assertions.Expect(page.GetByText("Accessibility statement", new() { Exact = true })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Find information about products and services" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Find information about products and services" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyAccessibilityLinkUS16AC passed");
        }

        [Test, Order(45), Category("functional")]
        public async Task VerifyGiveFeedbackOrReportAProblemWithThisPageLinkUS162AC()
        {
            goToLink("");
            string feedbackText = "Verifying feedback form - User can enter their feedback or report a problem with this page and submit the form successfully.";
            await page.GetByRole(AriaRole.Link, new() { NameString = "tell us about a problem with this page" }).ClickAsync();
            await Assertions.Expect(page.GetByText("What do you want to tell us?", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.FEEDBACK_FORM_ERROR_MSG)).ToContainTextAsync("Your feedback must be 1000 characters or fewer");
            await page.Locator(FipsLocator.FEEDBACK_TEXTBOX).FillAsync(feedbackText);
            await page.GetByRole(AriaRole.Button, new() { NameString = "Submit feedback" }).ClickAsync();
            await Task.Delay(2000);
            await Assertions.Expect(page.GetByText("Thank you for your feedback", new() { Exact = true })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyGiveFeedbackOrReportAProblemWithThisPageLinkUS162AC passed");
        }

        [Test, Order(46), Category("functional")]
        public async Task ValidateMaxCharsinGiveFeedbackOrReportAProblemFormUS162AC()
        {
            goToLink("");
            string feedbackText = "Validating more than 1000 characters for feedback form. User should not be able to submit their feedback after entering more than limited characters in given textarea. abc defghi jklm nop qrst uvw xyz012 34567Validating 1000 characters for feedback form. User should be able to enter their feedback or report a problem with this page and submit the form successfully. abc defghi jklm nop qrst uvw xyz012 34567Validating 1000 characters for feedback form. User should be able to enter their feedback or report a problem with this page and submit the form successfully. abc defghi jklm nop qrst uvw xyz012 34567Validating 1000 characters for feedback form. User should be able to enter their feedback or report a problem with this page and submit the form successfully. abc defghi jklm nop qrst uvw xyz012 34567Validating 1000 characters for feedback form. User should be able to enter their feedback or report a problem with this page and submit the form successfully. abc defghi jklm nop qrst uvw xyz. Test";
            await page.GetByRole(AriaRole.Link, new() { NameString = "tell us about a problem with this page" }).ClickAsync();
            await Assertions.Expect(page.GetByText("What do you want to tell us?", new() { Exact = true })).ToBeVisibleAsync();
            await page.Locator(FipsLocator.FEEDBACK_TEXTBOX).FillAsync(feedbackText);
            await Assertions.Expect(page.Locator(FipsLocator.FEEDBACK_MAXCHARS_ERROR_MSG)).ToHaveTextAsync("You have 6 characters too many");
            await page.GetByRole(AriaRole.Button, new() { NameString = "Submit feedback" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.FEEDBACK_SUBMIT_ERROR_MSG)).ToContainTextAsync("There is a problem");
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Your feedback must be 1000 characters or fewer" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "ValidateMaxCharsinGiveFeedbackOrReportAProblemFormUS162AC passed");
        }

        [Test, Order(47), Category("functional")]
        public async Task VerifyMainProductPageHeaderAndListUS103AC()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Products" }).ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyMainProductPageHeaderAndListUS103AC passed");
        }

        [Test, Order(48), Category("functional")]
        public async Task VerifyUserGroupsSearchFunctionalityUS103AC()
        {
            await page.Locator(FipsLocator.USER_GROUPS_LISTBOX).FillAsync("Ac");
            await page.Locator(FipsLocator.USER_GROUPS_OPTION1).ClickAsync();
            await Assertions.Expect(page.GetByLabel("Academy and trust workforce  (Education provider and early years workforce)")).ToBeCheckedAsync();
            await page.Locator(FipsLocator.USER_GROUPS_LISTBOX).ClickAsync();
            await Task.Delay(1000);
            await page.Locator(FipsLocator.USER_GROUPS_LISTBOX).FillAsync("Ac");
            await Task.Delay(1000);
            await page.Locator(FipsLocator.USER_GROUPS_OPTION2).ClickAsync();
            await Assertions.Expect(page.GetByLabel("Academy headteacher (secondary)  (Academy and trust workforce)")).ToBeCheckedAsync();
            //await page.GetByRole(AriaRole.Option, new() { NameString = "Chief Social Worker for" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();

            //selecting another user groups value -
            await page.Locator(FipsLocator.USER_GROUPS_LISTBOX).FillAsync("DFE");
            await page.Locator(FipsLocator.USER_GROUPS_OPTION3).ClickAsync();
            await Assertions.Expect(page.GetByLabel("Colleague supporting DfE users  (Department for Education workforce)")).ToBeCheckedAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Task.Delay(1000);
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyUserGroupsSearchFunctionalityUS103AC passed");
        }

        [Test, Order(49), Category("functional")]
        public async Task VerifyProductNameSearchboxFunctionalityUS103AC()
        {
            await page.Locator(FipsLocator.KEYWORD_SEARCH_TEXTBOX).FillAsync("app");
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Task.Delay(1000);
            await page.Locator(FipsLocator.KEYWORD_SEARCH_TEXTBOX).FillAsync(string.Empty);

            extentTest?.Log(Status.Pass, "VerifyProductNameSearchboxFunctionalityUS103AC passed");
        }

        [Test, Order(50), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_CommercialCategoryUS234AC1()
        {
            goToLink("products");
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_COMMERCIAL_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("result for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_COMMERCIAL_FILTERTAG)).
                             ToHaveTextAsync("Commercial × Remove Commercial filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaCategorywiseSearchFunctionalityUS234AC1 passed");
        }

        [Test, Order(51), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_CustomerExpAndDesignUS234AC2()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_CUST_EXP_DESIGN_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_CUST_EXP_DESIGN_FILTERTAG)).
                             ToHaveTextAsync("Customer Experience and Design × Remove Customer Experience and Design filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_CustomerExpAndDesignUS234AC2 passed");
        }

        [Test, Order(52), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_ChildrenAndFamiliesUS234AC3()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_CHILD_AND_FAMILIES_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_CHILD_AND_FAMILIES_FILTERTAG)).
                             ToHaveTextAsync("Children and Families × Remove Children and Families filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_ChildrenAndFamiliesUS234AC3 passed");
        }

        [Test, Order(53), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_EnterpriseDataUS234AC4()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_ENTERPRISE_DATA_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_ENTERPRISE_DATA_FILTERTAG)).
                             ToHaveTextAsync("Enterprise Data × Remove Enterprise Data filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            // going to next pages to check products list -
            await page.Locator(FipsLocator.PAGE_2_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?group=enterprise-data&page=2");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.NEXT_PAGE_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?group=enterprise-data&page=3");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_EnterpriseDataUS234AC4 passed");
        }

        [Test, Order(54), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_FundingAndFinancialOversightUS234AC5()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_FUND_FINANCIAL_OS_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FUND_FINANCIAL_OS_FILTERTAG)).
                             ToHaveTextAsync("Funding and Financial Oversight × Remove Funding and Financial Oversight filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_FundingAndFinancialOversightUS234AC5 passed");
        }

        [Test, Order(55), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_OperationsAndInfraUS234AC6()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_OPS_AND_INFRA_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_OPS_AND_INFRA_FILTERTAG)).
                             ToHaveTextAsync("Operations and Infrastructure × Remove Operations and Infrastructure filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_OperationsAndInfraUS234AC6 passed");
        }

        [Test, Order(56), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_RegionalDigitalServicesUS234AC7()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_REGION_DIGI_SERVICES_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_REGION_DIGI_SERVICES_FILTERTAG)).
                             ToHaveTextAsync("Regional Digital Services × Remove Regional Digital Services filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_RegionalDigitalServicesUS234AC7 passed");
        }

        [Test, Order(57), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_SchoolsDigitalUS234AC8()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_SCHOOLS_DIGI_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_SCHOOLS_DIGI_FILTERTAG)).
                             ToHaveTextAsync("Schools Digital × Remove Schools Digital filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_SchoolsDigitalUS234AC8 passed");
        }

        [Test, Order(58), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_SectorFacingServicesUS234AC9()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_SECTOR_FACING_SERVICES_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_SECTOR_FACING_SERVICES_FILTERTAG)).
                             ToHaveTextAsync("Sector Facing Services × Remove Sector Facing Services filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_SectorFacingServicesUS234AC9 passed");
        }

        [Test, Order(59), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_SkillsAndGrowthUS234AC10()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_SKILLS_AND_GROWTH_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_SKILLS_AND_GROWTH_FILTERTAG)).
                             ToHaveTextAsync("Skills and Growth × Remove Skills and Growth filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_SkillsAndGrowthUS234AC10 passed");
        }

        [Test, Order(60), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_StrategyCategoryUS234AC11()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_STRATEGY_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_STRATEGY_FILTERTAG)).
                             ToHaveTextAsync("Strategy × Remove Strategy filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_StrategyCategoryUS234AC11 passed");
        }

        [Test, Order(61), Category("functional")]
        public async Task VerifyBusinessAreaSearchFunctionality_NotCategorisedUS234AC12()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_NOT_CATEGORISED_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_NOT_CATEGORISED_FILTERTAG)).
                             ToHaveTextAsync("Not categorised × Remove Not categorised filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            // going to next pages to check products list -
            await page.Locator(FipsLocator.PAGE_2_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?group=__not_categorised__&page=2");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PAGE_3_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?group=__not_categorised__&page=3");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaSearchFunctionality_NotCategorisedUS234AC12 passed");
        }

        [Test, Order(62), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_ChatCategoryUS235AC1()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_CHAT_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                         ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CHAT_FILTERTAG)).
                                                         ToHaveTextAsync("Chat × Remove Chat filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_ChatCategoryUS235AC1 passed");
        }

        [Test, Order(63), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_EmailCategoryUS235AC2()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_EMAIL_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                         ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_EMAIL_FILTERTAG)).
                                                         ToHaveTextAsync("Email × Remove Email filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_EmailCategoryUS235AC2 passed");
        }

        [Test, Order(64), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_FaceToFaceCategoryUS235AC3()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_FACETOFACE_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                        ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FACETOFACE_FILTERTAG)).
                                                        ToHaveTextAsync("Face-to-face × Remove Face-to-face filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_FaceToFaceCategoryUS235AC3 passed");
        }

        [Test, Order(65), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_NativeAppCategoryUS235AC4()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_NATIVE_APP_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                        ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_NATIVE_APP_FILTERTAG)).
                                                        ToHaveTextAsync("Native app × Remove Native app filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_NativeAppCategoryUS235AC4 passed");
        }

        [Test, Order(66), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_OtherDigitalMediaCategoryUS235AC5()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_OTHER_DIGI_MEDIA_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                         ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_OTHER_DIGI_MEDIA_FILTERTAG)).
                                         ToHaveTextAsync("Other digital media × Remove Other digital media filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_OtherDigitalMediaCategoryUS235AC5 passed");
        }

        [Test, Order(67), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_PhoneCategoryUS235AC6()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_PHONE_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                         ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_PHONE_FILTERTAG)).
                                                         ToHaveTextAsync("Phone × Remove Phone filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_PhoneCategoryUS235AC6 passed");
        }

        [Test, Order(68), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_PrintMediaCategoryUS235AC7()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_PRINT_MEDIA_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                         ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_PRINT_MEDIA_FILTERTAG)).
                                                         ToHaveTextAsync("Print media × Remove Print media filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_PrintMediaCategoryUS235AC7 passed");
        }

        [Test, Order(69), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_SMSCategoryUS235AC8()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_SMS_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                         ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_SMS_FILTERTAG)).
                                                         ToHaveTextAsync("SMS × Remove SMS filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_SMSCategoryUS235AC8 passed");
        }

        [Test, Order(70), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_WebCategoryUS235AC9()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_WEB_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                         ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_WEB_FILTERTAG)).
                                                         ToHaveTextAsync("Web × Remove Web filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            //going to next pages to check products list -
            await page.Locator(FipsLocator.PAGE_2_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?channel=web&page=2");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PAGE_3_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?channel=web&page=3");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.NEXT_PAGE_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?channel=web&page=4");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Task.Delay(1000);
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_WebCategoryUS235AC9 passed");
        }

        [Test, Order(71), Category("functional")]
        public async Task VerifyChannelSearchFunctionality_NotCategorisedUS235AC10()
        {
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_NOT_CATEGORISED_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                         ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_NOT_CATEGORISED_FILTERTAG)).
                                                         ToHaveTextAsync("Not categorised × Remove Not categorised filter");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyChannelSearchFunctionality_NotCategorisedUS235AC10 passed");
        }

        [Test, Order(72), Category("functional")]
        public async Task VerifyPhaseSearchFunctionality_DiscoveryCategoryUS236AC1()
        {
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_DISCOVERY_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                    ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_DISCOVERY_FILTERTAG)).
                                 ToHaveTextAsync("Discovery × Remove Discovery filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.GetByText("No products found matching your filters.")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CLEAR_ALL_FILTERS_DESC)).ToContainTextAsync(" to see all products.");
            await page.Locator(FipsLocator.CLEAR_ALL_FILTERS_LINK).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseSearchFunctionality_DiscoveryCategoryUS236AC1 passed");
        }

        [Test, Order(73), Category("functional")]
        public async Task VerifyPhaseSearchFunctionality_AlphaCategoryUS236AC2()
        {
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_ALPHA_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                    ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_ALPHA_FILTERTAG)).
                                 ToHaveTextAsync("Alpha × Remove Alpha filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.GetByText("No products found matching your filters.")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CLEAR_ALL_FILTERS_DESC)).ToContainTextAsync(" to see all products.");
            await page.Locator(FipsLocator.CLEAR_ALL_FILTERS_LINK).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseSearchFunctionality_AlphaCategoryUS236AC2 passed");
        }

        [Test, Order(74), Category("functional")]
        public async Task VerifyPhaseSearchFunctionality_DidNotProgressCategoryUS236AC3()
        {
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_DID_NOT_PROGRESS_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                    ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_DID_NOT_PROGRESS_FILTERTAG)).
                                 ToHaveTextAsync("Did not progress × Remove Did not progress filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.GetByText("No products found matching your filters.")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CLEAR_ALL_FILTERS_DESC)).ToContainTextAsync(" to see all products.");
            await page.Locator(FipsLocator.CLEAR_ALL_FILTERS_LINK).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseSearchFunctionality_DidNotProgressCategoryUS236AC3 passed");
        }

        [Test, Order(75), Category("functional")]
        public async Task VerifyPhaseSearchFunctionality_PrivateBetaCategoryUS236AC4()
        {
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_PRIVATE_BETA_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                    ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_PRIVATE_BETA_FILTERTAG)).
                                 ToHaveTextAsync("Private beta × Remove Private beta filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseSearchFunctionality_PrivateBetaCategoryUS236AC4 passed");
        }

        [Test, Order(76), Category("functional")]
        public async Task VerifyPhaseSearchFunctionality_PublicBetaCategoryUS236AC5()
        {
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_PUBLIC_BETA_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                    ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_PUBLIC_BETA_FILTERTAG)).
                                 ToHaveTextAsync("Public beta × Remove Public beta filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.NEXT_PAGE_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?phase=public-beta&page=2");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseSearchFunctionality_PublicBetaCategoryUS236AC5 passed");
        }

        [Test, Order(77), Category("functional")]
        public async Task VerifyPhaseSearchFunctionality_LiveCategoryUS236AC6()
        {
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_LIVE_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                    ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_LIVE_FILTERTAG)).
                                 ToHaveTextAsync("Live × Remove Live filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseSearchFunctionality_LiveCategoryUS236AC6 passed");
        }

        [Test, Order(78), Category("functional")]
        public async Task VerifyPhaseSearchFunctionality_DecommissioningCategoryUS236AC7()
        {
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_DECOMMISSIONING_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                    ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_DECOMMISSIONING_FILTERTAG)).
                                 ToHaveTextAsync("Decommissioning × Remove Decommissioning filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseSearchFunctionality_DecommissioningCategoryUS236AC7 passed");
        }

        [Test, Order(79), Category("functional")]
        public async Task VerifyPhaseSearchFunctionality_DecommissionedCategoryUS236AC8()
        {
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_DECOMMISSIONED_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                    ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_DECOMMISSIONED_FILTERTAG)).
                                 ToHaveTextAsync("Decommissioned × Remove Decommissioned filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseSearchFunctionality_DecommissionedCategoryUS236AC8 passed");
        }

        [Test, Order(80), Category("functional")]
        public async Task VerifyPhaseSearchFunctionality_NotCategorisedCategoryUS236AC9()
        {
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_NOT_CATEGORISED_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                    ToContainTextAsync("your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_NOT_CATEGORISED_FILTERTAG)).
                                 ToHaveTextAsync("Not categorised × Remove Not categorised filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseSearchFunctionality_NotCategorisedCategoryUS236AC9 passed");
        }

        [Test, Order(81), Category("functional")]
        public async Task VerifyTypeSearchFunctionality_APICategoryUS237AC1()
        {
            goToLink("products");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_API_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                   ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_API_FILTERTAG)).
                                                   ToHaveTextAsync("API × Remove API filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyTypeSearchFunctionality_APICategoryUS237AC1 passed");
        }

        [Test, Order(82), Category("functional")]
        public async Task VerifyTypeSearchFunctionality_CampaignCategoryUS237AC2()
        {
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_CAMPAIGN_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                   ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_CAMPAIGN_FILTERTAG)).
                                                   ToHaveTextAsync("Campaign × Remove Campaign filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyTypeSearchFunctionality_CampaignCategoryUS237AC2 passed");
        }

        [Test, Order(83), Category("functional")]
        public async Task VerifyTypeSearchFunctionality_DataCategoryUS237AC3()
        {
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_DATA_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                      ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_DATA_FILTERTAG)).
                      ToHaveTextAsync("Data    × Remove Data    filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyTypeSearchFunctionality_DataCollectionAndReportingCategoryUS237AC3 passed");
        }

        [Test, Order(84), Category("functional")]
        public async Task VerifyTypeSearchFunctionality_InformationCategoryUS237AC4()
        {
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_INFORMATION_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                      ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_INFORMATION_FILTERTAG)).
                      ToHaveTextAsync("Information × Remove Information filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            //going to next pages to check products list -
            await page.Locator(FipsLocator.PAGE_2_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?type=information&page=2");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PAGE_3_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?type=information&page=3");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyTypeSearchFunctionality_InformationCategoryUS237AC4 passed");
        }

        [Test, Order(85), Category("functional")]
        public async Task VerifyTypeSearchFunctionality_TransactionalCategoryUS237AC5()
        {
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_TRANSACTIONAL_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                      ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_TRANSACTIONAL_FILTERTAG)).
                      ToHaveTextAsync("Transactional × Remove Transactional filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            //going to next pages to check products list -
            await page.Locator(FipsLocator.PAGE_2_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?type=transactional&page=2");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PAGE_3_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?type=transactional&page=3");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyTypeSearchFunctionality_TransactionalCategoryUS237AC5 passed");
        }

        [Test, Order(86), Category("functional")]
        public async Task VerifyTypeSearchFunctionality_NotCategorisedCategoryUS237AC6()
        {
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_NOT_CATEGORISED_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                      ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_NOT_CATEGORISED_FILTERTAG)).
                      ToHaveTextAsync("Not categorised × Remove Not categorised filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyTypeSearchFunctionality_NotCategorisedCategoryUS237AC6 passed");
        }

        [Test, Order(87), Category("functional")]
        public async Task VerifyTypeCategorywiseSearchFunctionalityUS103AC()
        {
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_API_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.TYPE_INFORMATION_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                      ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_API_FILTERTAG)).
                      ToHaveTextAsync("API × Remove API filter");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_INFORMATION_FILTERTAG)).
                      ToHaveTextAsync("Information × Remove Information filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await page.Locator(FipsLocator.NEXT_PAGE_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?type=api&type=information&page=2");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyTypeCategorywiseSearchFunctionalityUS103AC passed");
        }

        [Test, Order(88), Category("functional")]
        public async Task ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC1()
        {
            goToLink("products");
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_SCHOOLS_DIGI_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_WEB_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_PUBLIC_BETA_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_API_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                             ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_PUBLIC_BETA_FILTERTAG)).
                                                             ToHaveTextAsync("Public beta × Remove Public beta filter");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_WEB_FILTERTAG)).
                                                             ToHaveTextAsync("Web × Remove Web filter");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_API_FILTERTAG)).
                                                             ToHaveTextAsync("API × Remove API filter");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_SCHOOLS_DIGI_FILTERTAG)).
                                                             ToHaveTextAsync("Schools Digital × Remove Schools Digital filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC1 passed");
        }

        [Test, Order(89), Category("functional")]
        public async Task ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC2()
        {
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_OPS_AND_INFRA_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_LIVE_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_TRANSACTIONAL_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                 ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_LIVE_FILTERTAG)).
                                                 ToHaveTextAsync("Live × Remove Live filter");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_TRANSACTIONAL_FILTERTAG)).
                                                 ToHaveTextAsync("Transactional × Remove Transactional filter");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_OPS_AND_INFRA_FILTERTAG)).
                                                 ToHaveTextAsync("Operations and Infrastructure × Remove Operations and Infrastructure filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Task.Delay(1000);
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC2 passed");
        }

        [Test, Order(90), Category("functional")]
        public async Task ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC3()
        {
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_SKILLS_AND_GROWTH_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.BA_STRATEGY_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_DECOMMISSIONED_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                      ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_DECOMMISSIONED_FILTERTAG)).
                                                 ToHaveTextAsync("Decommissioned × Remove Decommissioned filter");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_SKILLS_AND_GROWTH_FILTERTAG)).
                                                 ToHaveTextAsync("Skills and Growth × Remove Skills and Growth filter");
            await Assertions.Expect(page.Locator(FipsLocator.BA_STRATEGY_FILTERTAG)).
                                                 ToHaveTextAsync("Strategy × Remove Strategy filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC3 passed");
        }

        [Test, Order(91), Category("functional")]
        public async Task ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC4()
        {
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_CHILD_AND_FAMILIES_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_FACETOFACE_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.CHANNEL_WEB_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                      ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FACETOFACE_FILTERTAG)).
                                                 ToHaveTextAsync("Face-to-face × Remove Face-to-face filter");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_WEB_FILTERTAG)).
                                                 ToHaveTextAsync("Web × Remove Web filter");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_CHILD_AND_FAMILIES_FILTERTAG)).
                                                 ToHaveTextAsync("Children and Families × Remove Children and Families filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC4 passed");
        }

        [Test, Order(92), Category("functional")]
        public async Task ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC5()
        {
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_FUND_FINANCIAL_OS_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_LIVE_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_INFORMATION_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                     ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_LIVE_FILTERTAG)).
                                                     ToHaveTextAsync("Live × Remove Live filter");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_INFORMATION_FILTERTAG)).
                                                     ToHaveTextAsync("Information × Remove Information filter");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FUND_FINANCIAL_OS_FILTERTAG)).
                                 ToHaveTextAsync("Funding and Financial Oversight × Remove Funding and Financial Oversight filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC5 passed");
        }

        [Test, Order(93), Category("functional")]
        public async Task ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC6()
        {
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_ENTERPRISE_DATA_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_NOT_CATEGORISED_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_DATA_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                     ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_NOT_CATEGORISED_FILTERTAG)).
                                                             ToHaveTextAsync("Not categorised × Remove Not categorised filter");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_DATA_FILTERTAG)).
                                                             ToHaveTextAsync("Data    × Remove Data    filter");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_ENTERPRISE_DATA_FILTERTAG)).
                                                             ToHaveTextAsync("Enterprise Data × Remove Enterprise Data filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "ValidateFilterLogicUpdate_ANDLogic_SearchFunctionalityUS220TC6 passed");
        }

        [Test, Order(94), Category("functional")]
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

        [Test, Order(95), Category("functional")]
        public async Task VerifyProductOverviewPageHeadersUS168AC()
        {
            // await page.Locator(FipsLocator.PRODUCT_LINK).ClickAsync(); //not working as link is visually hidden
            // await page.Locator("a").Filter(new() { HasTextString = "Accessibility and inclusion" }).Nth(1).ClickAsync(); //not working as link is visually hidden
            goToLink("product/VRM-926");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Accessibility and inclusion manual" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.FIPS_ID_LINK)).ToHaveTextAsync("VRM-926");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_COLUMN)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_COLUMN)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CONTACTS_COLUMN)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.VIEW_PRODUCT_COLUMN)).ToBeVisibleAsync();

            var targetHeader = page.Locator(".govuk-table__head .govuk-table__row").
                                                   Filter(new() { HasTextString = "Phase" }).
                                                   Filter(new() { HasTextString = "Business area" }).
                                                   Filter(new() { HasTextString = "Contacts" }).
                                                   Filter(new() { HasTextString = "View product" });
            var targetValueRow = page.Locator(".govuk-table__body .govuk-table__row").
                                                   Filter(new LocatorFilterOptions { HasTextString = "Live" }).
                                                   Filter(new LocatorFilterOptions { HasTextString = "Customer Experience and Design" }).
                                                   Filter(new LocatorFilterOptions { HasTextString = "1 contacts" }).
                                                   Filter(new LocatorFilterOptions { HasTextString = "View product" });
            await Assertions.Expect(targetHeader).ToBeVisibleAsync();
            await Assertions.Expect(targetValueRow).ToBeVisibleAsync();

            // Assert that when clicking on '1 contacts' link Contacts description is displayed -
            await targetValueRow.GetByRole(AriaRole.Link, new LocatorGetByRoleOptions { NameString = "1 contacts" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.RESPONSIBILITIES_AND_CONTACTS_HEADER)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SERVICE_OWNER_LOCATOR)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CONTACTS_NAME_LINK)).ToBeVisibleAsync();

            // clicking on 'View products', product details page opens in new tab -            
            var newTab = await page.RunAndWaitForPopupAsync(async () =>
            {
                await targetValueRow.GetByRole(AriaRole.Link, new() { NameString = "View product" }).ClickAsync();
            });
            await newTab.WaitForLoadStateAsync();

            // Assertions in the new tab -
            await Assertions.Expect(newTab).ToHaveURLAsync("https://accessibility.education.gov.uk/");
            await Assertions.Expect(newTab).ToHaveTitleAsync("Accessibility and inclusive design manual | Accessibility manual - Department for Education");
            await Assertions.Expect(newTab.GetByRole(AriaRole.Heading, new() { NameString = "Accessibility and inclusive design manual" })).ToBeVisibleAsync();
            await newTab.CloseAsync();
            // Assertions back on the original page -
            await Assertions.Expect(page).ToHaveTitleAsync("Accessibility and inclusion manual - FIPS");

            extentTest?.Log(Status.Pass, "VerifyProductOverviewPageHeadersUS168AC passed");
        }

        [Test, Order(96), Category("functional")]
        public async Task VerifyProductDetailsInTableUS168AC()
        {
            goToLink("product/VRM-926");
            var expectedTableData = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "Phase", "Phase: \n                                        Live" },
                    { "Business area", "Business area: \nCustomer Experience and Design" },
                    { "Contacts", "1 contacts" },
                    { "View product", "View product: \n                                        View product" }
                },
            };

            // Call the generic assertion method within the test
            await AssertTableColumnValues(page, expectedTableData, FipsLocator.PRODUCT_DETAIL_TABLE);

            extentTest?.Log(Status.Pass, "VerifyProductDetailsInTableUS168AC passed");
        }

        [Test, Order(97), Category("functional")]
        public async Task VerifyProductOverviewPageLinksUS168AC()
        {
            //Assertion for Overview link - 
            await Assertions.Expect(page.Locator(FipsLocator.OVERVIEW_LINK)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.OVERVIEW_LINK).ClickAsync(); //use other place
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Description" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Standards and guidance for designing and building accessible and inclusive products and services in DfE.")).ToBeVisibleAsync();

            //Assertion for Categories link - 
            await Assertions.Expect(page.Locator(FipsLocator.CATEGORIES_LINK)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CATEGORIES_LINK).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Categories" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CATEGORIES_TABLE)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Users of this product" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USERS_OF_PRODUCT_TABLE)).ToBeVisibleAsync();

            //Assertion for Propose a change link - 
            await Assertions.Expect(page.Locator(FipsLocator.PROPOSE_A_CHANGE_LINK)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PROPOSE_A_CHANGE_LINK).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PROPOSED_FORM)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Propose a change to product details" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use this form to propose changes to this product's information. An administrator will review your suggestions before they are added.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("This form should only be submitted by a permanent member of DfE staff.", new() { Exact = true })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyProductOverviewPageLinksUS168AC passed");
        }

        [Test, Order(98), Category("functional")]
        public async Task VerifyCategoriesDetailsInTableUS168AC()
        {
            await page.Locator(FipsLocator.CATEGORIES_LINK).ClickAsync();
            var expectedTableData = new List<Dictionary<string, string>>
            {

                new Dictionary<string, string>
                {
                    { "Name", "Customer Experience and Design" },
                    { "Type", "Business area" },
                    { "Description", "Partner with DfE teams to champion user needs and connect, improve and simplify services." }
                },

                new Dictionary<string, string>
                {
                    { "Name", "Web" },
                    { "Type", "Channel" },
                    { "Description", "Real-time text-based communication delivered through web or mobile interfaces, often supporting automated and human interactions." }
                },

                new Dictionary<string, string>
                {
                    { "Name", "Live" },
                    { "Type", "Phase" },
                    { "Description", "Continously improving." }
                },

                new Dictionary<string, string>
                {
                    { "Name", "Information" },
                    { "Type", "Type" },
                    { "Description", "Provide guidance, policy content, or structured information to help people make decisions or understand their responsibilities." }
                }
            };

            await AssertTableColumnValues(page, expectedTableData, FipsLocator.CATEGORIES_DETAIL_TABLE);

            extentTest?.Log(Status.Pass, "VerifyCategoriesDetailsInTableUS168AC passed");
        }

        [Test, Order(99), Category("functional")]
        public async Task VerifyUsersOfTheProductTableUS168AC()
        {
            //goToLink("product/VRM-926/categories");
            var expectedTableData = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "Name", "Department for Education workforce" },
                },
            };

            await AssertTableColumnValues(page, expectedTableData, FipsLocator.USER_PRODUCT_TABLE);

            extentTest?.Log(Status.Pass, "VerifyUsersOfTheProductTableUS168AC passed");
        }

        [Test, Order(100), Category("functional")]
        public async Task ClickSubcategoriesLinkInCategoriesTableUS168AC()
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Customer Experience and Design" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Customer Experience and Design" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).
                    ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            // bug raised for below line issue, once fixed this TC will pass
            await Assertions.Expect(page.Locator(FipsLocator.BA_CUST_EXP_DESIGN_FILTERTAG)).
                    ToHaveTextAsync("Customer Experience and Design × Remove Customer Experience and Design filter");
            await page.GoBackAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Web" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Web" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).
                    ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_WEB_FILTERTAG)).
                    ToHaveTextAsync("Web × Remove Web filter");
            await page.GoBackAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Live" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Live" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).
                     ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_LIVE_FILTERTAG)).
                     ToHaveTextAsync("Live × Remove Live filter");
            await page.GoBackAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Information" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Information" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).
                      ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_INFORMATION_FILTERTAG)).
                      ToHaveTextAsync("Information × Remove Information filter");
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "ClickSubcategoriesLinkInCategoriesTableUS168AC passed");
        }

        [Test, Order(101), Category("functional")]
        public async Task ClickSubcategoryLinkInUsersProductTableUS168AC()
        {
            goToLink("product/VRM-926/categories"); // this can be removed when bug in above method is fixed
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Department for Education workforce" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Department for Education workforce" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.USER_GROUPS_FILTERTAG)).ToHaveTextAsync("Department for Education workforce × Remove Department for Education workforce filter");
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "ClickSubcategoryLinkInUsersProductTableUS168AC passed");
        }

        [Test, Order(102), Category("functional")]
        public async Task VerifyProposeAChangeFormUS168AC()
        {
            goToLink("product/VRM-926/categories");
            await page.Locator(FipsLocator.PROPOSE_A_CHANGE_LINK).ClickAsync();
            //  await page.Locator("ul#side-navigation li:nth-child(3) a").ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Product details" })).
                                                       ToBeVisibleAsync();
            await Assertions.Expect(page.GetByLabel("Product title")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCT_TITLE_TEXTBOX)).
                                                       ToHaveValueAsync("Accessibility and inclusion manual");
            await Assertions.Expect(page.GetByLabel("Short description")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHORT_DESCRIPTION_TEXTBOX)).
                                                       ToHaveValueAsync("Standards and guidance for designing and building accessible and inclusive products and services in DfE.");
            await Assertions.Expect(page.GetByLabel("Product URL")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCT_URL_TEXTBOX)).
                                                       ToHaveValueAsync("https://accessibility.education.gov.uk/");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new()
            { NameString = "Product classification" })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCT_CLASSIFICATION_PHASE)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SELECTED_PHASE_RADIOBUTTON)).ToBeCheckedAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCT_CLASSIFICATION_BUSINESSAREA)).
                                                      ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SELECTED_BUSINESSAREA_RADIOBUTTON)).ToBeCheckedAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCT_CLASSIFICATION_CHANNELS)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SELECTED_CHANNEL_CHECKBOXES)).ToBeCheckedAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCT_CLASSIFICATION_TYPES)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SELECTED_TYPES_CHECKBOXES)).ToBeCheckedAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new()
            { NameString = "Additional information" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByLabel("Tell us in your own words who the users of the product are")).
                                                     ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.ADDITIONAL_INFO_TEXTBOX)).ToHaveValueAsync("");
            await Assertions.Expect(page.GetByText("Tell us if any of the team roles have changed", new()
            { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByLabel("Delivery Manager")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.DELIVERY_MANAGER_TEXTBOX)).ToHaveValueAsync("");
            await Assertions.Expect(page.GetByLabel("Information Asset Owner")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.INFO_ASSET_OWNER_TEXTBOX)).
                                                      ToHaveValueAsync("");
            await Assertions.Expect(page.GetByLabel("Product Manager")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCT_MANAGER_TEXTBOX)).ToHaveValueAsync("");
            await Assertions.Expect(page.GetByLabel("Senior Responsible Officer")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SENIOR_RESP_OFFICER_TEXTBOX)).
                                                      ToHaveValueAsync("");
            await Assertions.Expect(page.GetByLabel("Reason for proposed changes")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.REASON_HINT_TEXT)).
                                                      ToHaveTextAsync("Tell us why you're proposing these changes. This will help the reviewer understand your request.");
            await Assertions.Expect(page.Locator(FipsLocator.REASON_FOR_CHANGE_TEXTBOX)).ToHaveValueAsync("");
            await Assertions.Expect(page.Locator(FipsLocator.SUBMIT_CHANGE_BUTTON)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Cancel" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyProposeAChangeFormUS168AC passed");
        }

        [Test, Order(103), Category("functional")]
        [Ignore("This test triggers product update email to FIPS Inbox. So, skipped for now")]
        public async Task EditAndSubmitProposeAChangeFormUS168AC()
        {
            await page.Locator(FipsLocator.PRODUCT_TITLE_TEXTBOX).
                                           FillAsync("Automation Test - Accessibility and inclusion manual");
            await page.Locator(FipsLocator.SHORT_DESCRIPTION_TEXTBOX).
                                           FillAsync("Automation Test - Validating that 'Short description' textbox can contain more than 500 characters and there is No limit on characters. Entering description - Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE - End of description test");
            await page.Locator(FipsLocator.PRODUCT_URL_TEXTBOX).
                                           FillAsync("https://accessibility.education.gov.uk/automation-test");
            await page.Locator(FipsLocator.CHANGED_PHASE_RADIOBUTTON).CheckAsync();
            await page.Locator(FipsLocator.CHANGED_BUSINESSAREA_RADIOBUTTON).CheckAsync();
            await page.Locator(FipsLocator.ADDED_CHANNEL_CHECKBOXES).CheckAsync();
            await page.Locator(FipsLocator.ADDED_TYPES_CHECKBOXES).CheckAsync();
            await page.Locator(FipsLocator.ADDITIONAL_INFO_TEXTBOX).
                                           FillAsync("Additional Info - adding automation test case for editing the form");
            await page.Locator(FipsLocator.DELIVERY_MANAGER_TEXTBOX).FillAsync("Automation Delivery Manager");
            await page.Locator(FipsLocator.INFO_ASSET_OWNER_TEXTBOX).FillAsync("Automation Info Asset Owner");
            await page.Locator(FipsLocator.PRODUCT_MANAGER_TEXTBOX).FillAsync("Automation Product Manager");
            await page.Locator(FipsLocator.SENIOR_RESP_OFFICER_TEXTBOX).
                                           FillAsync("Automation Senior Resp Officer");
            await page.Locator(FipsLocator.REASON_FOR_CHANGE_TEXTBOX).
                                           FillAsync("Running the automation test for the proposed change form edit and submission scenario.");
            await Task.Delay(1000);
            await page.Locator(FipsLocator.SUBMIT_CHANGE_BUTTON).ClickAsync();
            bool successMsg = await page.Locator(FipsLocator.SUCCESS_MESSAGE_ALERT).IsVisibleAsync();
            Assert.That(successMsg, Is.True);
            await Assertions.Expect(page.Locator(FipsLocator.SUCCESS_MESSAGE_ALERT)).
                                          ToContainTextAsync("Your proposed changes have been submitted. The FIPS team may contact you if additional action or information is needed.");

            extentTest?.Log(Status.Pass, "EditAndSubmitProposeAChangeFormUS168AC passed");
        }

        [Test, Order(104), Category("functional")]
        public async Task EditProposeAChangeFormAndClickCancelUS168AC()
        {
            // goToLink("product/VRM-926/propose-change");
            await page.Locator(FipsLocator.PROPOSE_A_CHANGE_LINK).ClickAsync();
            await page.Locator(FipsLocator.PRODUCT_TITLE_TEXTBOX).
                                           FillAsync("Automation Test - Accessibility and inclusion manual");
            await page.Locator(FipsLocator.SHORT_DESCRIPTION_TEXTBOX).
                                           FillAsync("Automation Test - Validating that 'Short description' textbox can contain more than 500 characters and there is No limit on characters. Entering description - Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE - End of description test");
            await page.Locator(FipsLocator.PRODUCT_URL_TEXTBOX).
                                           FillAsync("https://accessibility.education.gov.uk/automation-test");
            await page.Locator(FipsLocator.CHANGED_PHASE_RADIOBUTTON).CheckAsync();
            await page.Locator(FipsLocator.CHANGED_BUSINESSAREA_RADIOBUTTON).CheckAsync();
            await page.Locator(FipsLocator.ADDED_CHANNEL_CHECKBOXES).CheckAsync();
            await page.Locator(FipsLocator.ADDED_TYPES_CHECKBOXES).CheckAsync();
            await page.Locator(FipsLocator.ADDITIONAL_INFO_TEXTBOX).
                                           FillAsync("Additional Info - adding automation test case for editing the form");
            await page.Locator(FipsLocator.DELIVERY_MANAGER_TEXTBOX).FillAsync("Automation Delivery Manager");
            await page.Locator(FipsLocator.INFO_ASSET_OWNER_TEXTBOX).FillAsync("Automation Info Asset Owner");
            await page.Locator(FipsLocator.PRODUCT_MANAGER_TEXTBOX).FillAsync("Automation Product Manager");
            await page.Locator(FipsLocator.SENIOR_RESP_OFFICER_TEXTBOX).
                                           FillAsync("Automation Senior Resp Officer");
            await page.Locator(FipsLocator.REASON_FOR_CHANGE_TEXTBOX).
                                           FillAsync("Running the automation test for the proposed change edit and submission scenario.");
            await Task.Delay(1000);
            await page.GetByRole(AriaRole.Link, new() { NameString = "Cancel" }).ClickAsync();
            await Assertions.Expect(page).ToHaveTitleAsync("Accessibility and inclusion manual - FIPS");
            await page.Locator(FipsLocator.PROPOSE_A_CHANGE_LINK).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCT_TITLE_TEXTBOX)).
                                                       ToHaveValueAsync("Accessibility and inclusion manual");

            extentTest?.Log(Status.Pass, "EditProposeAChangeFormAndClickCancelUS168AC passed");
        }

        [Test, Order(105), Category("smoke")]
        public async Task VerifyPrivacyPolicyLinkUS15AC()
        {
            var newTab = await page.RunAndWaitForPopupAsync(async () =>
            {
                await page.GetByRole(AriaRole.Link, new() { NameString = "Privacy policy" }).ClickAsync();
            });

            await newTab.WaitForLoadStateAsync();
            await newTab.GetByRole(AriaRole.Button, new() { NameString = "Accept additional cookies" }).ClickAsync();
            await newTab.GetByRole(AriaRole.Button, new() { NameString = "Hide cookie message" }).ClickAsync();

            // Assertions in the new tab -
            await Assertions.Expect(newTab).ToHaveURLAsync("https://www.gov.uk/government/organisations/department-for-education/about/personal-information-charter");
            await Assertions.Expect(newTab).ToHaveTitleAsync("Personal information charter - Department for Education - GOV.UK");
            await Assertions.Expect(newTab.GetByRole(AriaRole.Heading, new() { NameString = "Personal information charter" })).ToBeVisibleAsync();
            await newTab.CloseAsync();
            // Assertions back on the original page -
            await Assertions.Expect(page).ToHaveTitleAsync("Propose changes to Accessibility and inclusion manual - FIPS");

            extentTest?.Log(Status.Pass, "VerifyPrivacyPolicyLinkUS15AC passed");
        }

        [Test, Order(106), Category("functional")]
        public async Task VerfiyImproveMissingOrInaccurateInformationLinkUS169AC()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BETA_PHASE_BANNER_DESC)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "improve missing or inaccurate information" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Keep information updated" })).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Search" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "request a new product entry" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Request a new product entry" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "About this service" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "About this service" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Contact us" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Contact us" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Find information about products and services" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Find information about products and services" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerfiyImproveMissingOrInaccurateInformationLinkUS169AC passed");
        }

        [Test, Order(107), Category("functional")]
        public async Task VerifyUGSocialWorkerSubcategoryListUS101AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_SocialWorker_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Social care workforce - Social worker");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGSocialWorkerSubcategoryListUS101AC passed");
            }
        }

        [Test, Order(108), Category("functional")]
        public async Task ClickSubcategoryLinksForSocialCareWorkforceUS101AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_SCWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(109), Category("functional")]
        public async Task ClickSubcategoryLinksForSocialWorkerUS128AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_SocialWorker");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(110), Category("functional")]
        public async Task ClickSubcategoryLinksForEPAndEYWorkforceUS94AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_EPandEYWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(111), Category("functional")]
        public async Task VerifyUGEPEYAcademyAndTrustWorkforceSubcategoryListUS130AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "UG_EPEYAcademyTruWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Education provider and early years workforce - Academy and trust workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGEPEYAcademyAndTrustWorkforceSubcategoryListUS130AC passed");
            }
        }

        [Test, Order(112), Category("functional")]
        public async Task ClickSubcategoryLinksForEPEYAcademyAndTrustWorkforceUS130AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "EPEYSubcateg_AcademyTWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(113), Category("functional")]
        public async Task VerifyUGEPEYAlternatProvSettingWorkforceSubcategListUS131AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "UG_EPEYAltProvSetWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Education provider and early years workforce - Alternative provision setting workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGEPEYAlternatProvSettingWorkforceSubcategListUS131AC passed");
            }
        }

        [Test, Order(114), Category("functional")]
        public async Task ClickSubcategoryLinksForAlternatProvSettingWorkforceEPEYUS131AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "EPEYSubcateg_AltProSetWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);
                //bug raised for missing UG subcategory, once fixed this TC will pass
                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(115), Category("functional")]
        public async Task VerifyUGEPEYEarlyYearsWorkforceSubcategoryListUS132AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "UG_EPEYEarlyYearsWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Education provider and early years workforce - Early years workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGEPEYEarlyYearsWorkforceSubcategoryListUS132AC passed");
            }
        }

        [Test, Order(116), Category("functional")]
        public async Task ClickSubcategoryLinksForEarlyYearsWorkforceEPEYUS132AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "EPEYSubcatg_EarlyYearsWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(117), Category("functional")]
        public async Task VerifyUGEPEYFurtherEducationWorkforceSubcategoryListUS133AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "UG_EPEYFurtherEduWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Education provider and early years workforce - Further education workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGEPEYFurtherEducationWorkforceSubcategoryListUS133AC passed");
            }
        }

        [Test, Order(118), Category("functional")]
        public async Task ClickSubcategoryLinksForFurtherEducationWorkforceEPEYUS133AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "EPEYSubcatg_FurtherEduWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);
                //bug raised for missing UG subcategory, once fixed this TC will pass
                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(119), Category("functional")]
        public async Task VerifyUGEPEYHigherEducationWorkforceSubcategoryListUS134AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "UG_EPEYHigherEduWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Education provider and early years workforce - Higher education workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGEPEYHigherEducationWorkforceSubcategoryListUS134AC passed");
            }
        }

        [Test, Order(120), Category("functional")]
        public async Task ClickSubcategoryLinksForHigherEducationWorkforceEPEYUS134AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "EPEYSubcatg_HigherEduWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(121), Category("functional")]
        public async Task VerifyUGEPEY_SENDProfessionalSubcategoryListUS135AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "UG_EPEY_SENDProfessional_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Education provider and early years workforce - SEND professional");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGEPEYHigherEducationWorkforceSubcategoryListUS134AC passed");
            }
        }

        [Test, Order(122), Category("functional")]
        public async Task ClickSubcategoryLinksForSENDProfessionalEPEYUS135AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "EPEYSubcateg_SENDProfessional");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);

                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(123), Category("functional")]
        public async Task VerifyUGEPEYSchoolWorkforceSubcategoryListUS136AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "UG_EPEY_SchoolWorkforce_list");
            if (dataRows.Count > 1)
            {
                goToLink(dataRows[0].Col1);
                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Education provider and early years workforce - School workforce");
                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGEPEYSchoolWorkforceSubcategoryListUS136AC passed");
            }
        }

        [Test, Order(124), Category("functional")]
        public async Task ClickSubcategoryLinksForSchoolWorkforceEPEYUS136AC()
        {
            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "EPEYSubcateg_SchoolWorkforce");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

                goToLink(row.Product_Locator);
                // bug raised for missing UG subcategory, once fixed this TC will pass
                var FilterText = page.Locator(row.Filter_Tag);
                await Assertions.Expect(FilterText).ToBeVisibleAsync();
                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isUsertypeChecked, Is.True);
                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
            }
        }

        [Test, Order(125), Category("functional")]
        public async Task VerifyFeedbackLinks_ContentChangeUS207AC()
        {
            goToLink("");
            await Assertions.Expect(page.Locator(FipsLocator.FEEDBACK_BANNER)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SURVEY_LINK_TEXT)).ToContainTextAsync("Give us feedback about this service");
            var newTab = await page.RunAndWaitForPopupAsync(async () =>
            {
                await page.Locator(FipsLocator.SURVEY_LINK_TEXT).ClickAsync();
            });
            await newTab.WaitForLoadStateAsync();

            // Assertions in the new tab -
            await Assertions.Expect(newTab).ToHaveURLAsync("https://dferesearch.fra1.qualtrics.com/jfe/form/SV_bHoLXsj3BfAh3ZI");
            await Assertions.Expect(newTab).ToHaveTitleAsync("Qualtrics Survey | Qualtrics Experience Management");
            await Assertions.Expect(newTab.Locator(FipsLocator.SURVEY_FIRST_PAGE)).ToContainTextAsync("Thank you for taking the time to give feedback on your experience of using ‘Find Information about Products and Services’ (FIPS) today.  ");
            await newTab.CloseAsync();

            // Assertions back on the original page -
            await Assertions.Expect(page).ToHaveTitleAsync("Find information about products and services - FIPS");

            extentTest?.Log(Status.Pass, "VerifyFeedbackLinks_ContentChangeUS207AC passed");
        }

        [Test, Order(126), Category("functional")]
        [Ignore("This test triggers product entry request email to FIPS Inbox. So, skipped for now")]
        public async Task VerifyRequestNewProductEntryForm_AddingProductUS141AC()
        {
            goToLink("products");
            await page.Locator(FipsLocator.MISSING_PROD_SERVICE_LINK).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "request for a new product entry" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Request a new product entry" })).
                                                                             ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.REQUEST_NEW_PRODUCT_FORM)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use this form to request a new product to be added to FIPS. An administrator will review your request before it is added.", new()
            { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("This form should only be submitted by a permanent member of DfE staff.", new()
            { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Product details" })).
                                                                                              ToBeVisibleAsync();
            await Assertions.Expect(page.GetByLabel("Product title")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TITLE).FillAsync("Automation - Test Product Title");
            await Assertions.Expect(page.GetByLabel("Description")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_DESCRIPTION).
                FillAsync("Automation Test - Adding description of more than 1000 characters - Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE - Test description ends.");
            await Assertions.Expect(page.GetByLabel("Product URL (optional)")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_URL).FillAsync("https://automation-test-product.education.gov.uk/");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Product classification" })).
                                                                                             ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHECK_PHASE_TEXT)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_PHASE1).CheckAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHECK_BUSINESSAREA_TEXT)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_BUSINESSAREA1).CheckAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHECK_CHANNELS_TEXT)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB1).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB2).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB3).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB4).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB5).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB6).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB7).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB8).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB9).CheckAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHECK_TYPES_TEXT)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB1).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB2).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB3).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB4).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB5).CheckAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Additional information" })).
                                                                                              ToBeVisibleAsync();
            await Assertions.Expect(page.GetByLabel("Tell us in your own words who the users of the product are (optional)")).
                                                                                              ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_ADDITIONAL_INFO).
                FillAsync("Additional information - adding automation test case for new product entry form. This product can be used by teachers, school leaders and responsible bodies.");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Team roles (optional)" })).
                                                                                              ToBeVisibleAsync();
            await Assertions.Expect(page.GetByLabel("Delivery Manager")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_DELIVERY_MANAGER).FillAsync("Automation test Delivery Manager");
            await Assertions.Expect(page.GetByLabel("Product Manager")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_MANAGER).FillAsync("Automation test Product Manager");
            await Assertions.Expect(page.GetByLabel("Senior Responsible Officer")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_SENIOR_RESP_OFFICER).FillAsync("Automation test Senior Resp Officer");
            await Assertions.Expect(page.GetByLabel("Notes")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.NOTES_HINT_TEXT)).
                ToHaveTextAsync("Provide any additional information that would help the FIPS team understand this request.");
            await page.Locator(FipsLocator.ADD_NOTES_TEXTBOX).
                FillAsync("Automation test - providing additional information that would help the FIPS team understand this request.");
            await Assertions.Expect(page.Locator(FipsLocator.SUBMIT_REQUEST_BUTTON)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Cancel" })).ToBeVisibleAsync();
            await Task.Delay(2000);
            await page.Locator(FipsLocator.SUBMIT_REQUEST_BUTTON).ClickAsync();
            await Task.Delay(1000);
            bool successMsg = await page.Locator(FipsLocator.ADD_PRODUCT_SUCCESS_ALERT).IsVisibleAsync();
            Assert.That(successMsg, Is.True);
            await Assertions.Expect(page.Locator(FipsLocator.ADD_PRODUCT_SUCCESS_ALERT)).
                ToContainTextAsync("Your new product entry request has been submitted. The FIPS team will review your request and may contact you if additional information is needed.");

            extentTest?.Log(Status.Pass, "VerifyRequestNewProductEntryForm_AddingProductUS141AC passed");
        }

        [Test, Order(127), Category("functional")]
        [Ignore("This test triggers product entry request email to FIPS Inbox. So, skipped for now")]
        public async Task ValidateRequestNewProductForm_SubmitBlankFormUS141AC()
        {
            await Assertions.Expect(page.Locator(FipsLocator.REQUEST_NEW_PRODUCT_FORM)).ToBeVisibleAsync();

            //Clicking on Submit button without entering any details -
            await page.Locator(FipsLocator.SUBMIT_REQUEST_BUTTON).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.ERROR_MESSAGE_BOX)).ToContainTextAsync("There is a problem");
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Please provide a product title" })).
                                                                          ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Please provide a description" })).
                                                                          ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Please provide notes about this request" })).
                                                                          ToBeVisibleAsync();

            //Clicking on error messages links -
            await page.GetByRole(AriaRole.Link, new() { NameString = "Please provide a product title" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.ADD_PRODUCT_TITLE)).ToBeFocusedAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TITLE).FillAsync("Automation test - Product Title A");
            await Assertions.Expect(page.Locator(FipsLocator.TITLE_ERROR_MESSAGE)).
                             ToHaveTextAsync("Error:\r\n                        Please provide a product title");

            await page.GetByRole(AriaRole.Link, new() { NameString = "Please provide a description" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.ADD_PRODUCT_DESCRIPTION)).ToBeFocusedAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_DESCRIPTION).
                       FillAsync("Automation test - Submitted blank form and then verifying all error messages for mandatory fields.");
            await Assertions.Expect(page.Locator(FipsLocator.DESCRIPTION_ERROR_MESSAGE)).
                             ToHaveTextAsync("Error:\r\n                        Please provide a description");

            await page.GetByRole(AriaRole.Link, new() { NameString = "Please provide notes about this request" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.ADD_NOTES_TEXTBOX)).ToBeFocusedAsync();
            await page.Locator(FipsLocator.ADD_NOTES_TEXTBOX).
                         FillAsync("Automation test -  Submitting form after entering only mandatory details");
            await Assertions.Expect(page.Locator(FipsLocator.NOTES_ERROR_MESSAGE)).
                             ToHaveTextAsync("Error:\r\n                        Please provide notes about this request");
            await Task.Delay(2000);
            await page.Locator(FipsLocator.SUBMIT_REQUEST_BUTTON).ClickAsync();
            await Task.Delay(1000);
            bool successMsg = await page.Locator(FipsLocator.ADD_PRODUCT_SUCCESS_ALERT).IsVisibleAsync();
            Assert.That(successMsg, Is.True);
            await Assertions.Expect(page.Locator(FipsLocator.ADD_PRODUCT_SUCCESS_ALERT)).
                ToContainTextAsync("Your new product entry request has been submitted. The FIPS team will review your request and may contact you if additional information is needed.");

            extentTest?.Log(Status.Pass, "ValidateRequestNewProductForm_SubmitBlankFormUS141AC passed");
        }

        [Test, Order(128), Category("functional")]
        public async Task VerifyRequestNewProductForm_AddDetailsAndClickCancelUS141AC()
        {
            goToLink("products");
            await page.Locator(FipsLocator.MISSING_PROD_SERVICE_LINK).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "request for a new product entry" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.REQUEST_NEW_PRODUCT_FORM)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TITLE).FillAsync("Automation test - Product Title B");
            await page.Locator(FipsLocator.ADD_PRODUCT_DESCRIPTION).
                                                 FillAsync("Automation test - Adding description for new product");
            await page.Locator(FipsLocator.ADD_PRODUCT_PHASE2).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_BUSINESSAREA2).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB5).CheckAsync();
            await page.Locator(FipsLocator.ADD_ADDITIONAL_INFO).
                                                FillAsync("Additional information - validating Cancel button functionality");
            await page.Locator(FipsLocator.ADD_DELIVERY_MANAGER).FillAsync("Automation - DfE Delivery Manager");
            await page.Locator(FipsLocator.ADD_NOTES_TEXTBOX).
                                                 FillAsync("Automation test - adding all necessary details and then clicking on Cancel");
            await page.GetByRole(AriaRole.Link, new() { NameString = "Cancel" }).ClickAsync();
            await Assertions.Expect(page).ToHaveTitleAsync("Search and filter products and services - FIPS");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new()
            { NameString = "Search and filter products and services" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyRequestNewProductForm_AddDetailsAndClickCancelUS141AC passed");
        }

        [Test, Order(129), Category("functional")]
        public async Task ValidateNotCategorisedFilterOptions_SearchFunctionalityUS213AC()
        {
            goToLink("products");
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.BA_NOT_CATEGORISED_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.CHANNEL_NOT_CATEGORISED_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_LIVE_CHECKBOX).CheckAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.TYPE_NOT_CATEGORISED_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                     ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_LIVE_FILTERTAG)).
                                                             ToHaveTextAsync("Live × Remove Live filter");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_FILTER_HEADING)).ToHaveTextAsync("Channel");
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_NOT_CATEGORISED_GROUP)).
                                                             ToHaveTextAsync("Not categorised × Remove Not categorised filter");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_FILTER_HEADING)).ToHaveTextAsync("Type");
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_NOT_CATEGORISED_GROUP)).
                                                             ToHaveTextAsync("Not categorised × Remove Not categorised filter");
            await Assertions.Expect(page.Locator(FipsLocator.BA_FILTER_HEADING)).ToHaveTextAsync("Business area");
            await Assertions.Expect(page.Locator(FipsLocator.BA_NOT_CATEGORISED_GROUP)).
                                                             ToHaveTextAsync("Not categorised × Remove Not categorised filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "ValidateNotCategorisedFilterOption_SearchFunctionalityUS213AC passed");
        }

        [Test, Order(130), Category("functional")]
        public async Task ValidateNotCategorisedFilterOptions_CombinedWithKeywordSearchFunctionalityUS213AC()
        {
            await page.Locator(FipsLocator.KEYWORD_SEARCH_TEXTBOX).FillAsync("Apprentice");
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.Locator(FipsLocator.PHASE_NOT_CATEGORISED_CHECKBOX).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.APPLIED_FILTERED_PANEL)).
                                                     ToContainTextAsync("results for your selected filters");
            await Assertions.Expect(page.Locator(FipsLocator.SEARCH_FILTER_HEADING)).ToHaveTextAsync("Search term");
            await Assertions.Expect(page.Locator(FipsLocator.KEYWORD_SEARCH_FILTERTAG)).
                                                             ToHaveTextAsync("Apprentice × Remove Apprentice filter");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_HEADING)).ToHaveTextAsync("Phase");
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_NOT_CATEGORISED_FILTERTAG)).
                                                             ToHaveTextAsync("Not categorised × Remove Not categorised filter");
            await Assertions.Expect(page.Locator(FipsLocator.MISSING_PROD_SERVICE_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "ValidateNotCategorisedFilterOptions_CombinedWithKeywordSearchFunctionalityUS213AC passed");
        }

        [Test, Order(131), Category("accessibility")]
        public async Task AccessibilityTest()
        {
            var axeResults = await page.RunAxe();
            var violations = axeResults.Violations;

            foreach (var violation in axeResults.Violations)
            {
                //extentTest.Fail($"Rule: {violation.Id}");
                extentTest.Info($"Impact: {violation.Impact}");
                extentTest.Info($"Description: {violation.Description}");

                foreach (var node in violation.Nodes)
                {
                    extentTest.Info($"Element: {node.Html}");

                    // Log any failure messages from the 'Any' checks
                    foreach (var check in node.Any)
                    {
                        extentTest.Info($"Check (Any): {check.Message}");
                    }

                    // Log all required checks that failed
                    foreach (var check in node.All)
                    {
                        extentTest.Info($"Check (All): {check.Message}");
                    }

                    // Log checks that passed but are not required
                    //foreach (var check in node.None)
                    //{
                    //    extentTest.Info($"Check (None): {check.Message}");
                    //}
                }
                //Assert.Fail($"Fail: ❌ Rule: {violation.Id}");
            }
        }
    }
}
