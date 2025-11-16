using AventStack.ExtentReports;
using Deque.AxeCore.Playwright;
using DocumentFormat.OpenXml.Wordprocessing;
using find_information_products_services_tests.HomePageTestCases.constants;
using find_information_products_services_tests.HomePageTestCases.utilities;
using Microsoft.Playwright;
using NUnit.Framework.Constraints;
using static find_information_products_services_tests.HomePageTestCases.utilities.ExcelReader;

namespace FiPSAutomation.HomePageTestCases
{
    public class FIPSTestCases : BaseTest
    {
        [Test, Order(1)]
        public async Task LoginWithUsernameAndPassword()
        {
            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
        }

        [Test, Order(2), Category("functional")]
        public async Task HomePageVerificationAC1()
        {
            await Assertions.Expect(page).ToHaveTitleAsync("Find information about products and services - FIPS");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Find information about products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use this service to explore what DfE delivers. Build on existing work, avoid duplication, and work more effectively across teams.")).ToBeVisibleAsync();
            var searchlink = page.Locator(FipsLocator.HOME_SEARCH_LOCATOR);
            await Assertions.Expect(searchlink).ToHaveTextAsync(" Search products and services ");
            //var link1 = page.Locator(FipsLocator.ABOUT_SERVICE_LOCATOR);
            //await Assertions.Expect(link1).ToHaveTextAsync("About this service");

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
        public async Task VerifyTilesAreVisibleAC4()
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

            extentTest?.Log(Status.Pass, "VerifyTilesAreVisibleAC4 passed");
        }

        [Test, Order(5), Category("functional")]
        public async Task ClickAllProductsAndServicesAC5()
        {
            await page.Locator(FipsLocator.ALL_PRODUCT_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "clickAllProductsAndServicesAC5 passed");
        }

        [Test, Order(6), Category("functional")]
        public async Task ClickBrowseCategoriesAC6()
        {
            await page.Locator(FipsLocator.BROWSE_CATEGORY_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "clickBrowseCategoriesAC6 passed");
        }

        //[Test, Order(8), Category("functional")]
        //public async Task ClickUseTheDataAC7()
        //{
        //    await page.Locator(FipsLocator.USE_DATA_LOCATOR).ClickAsync();
        //    await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Using the data" })).ToBeVisibleAsync();

        //    await page.GoBackAsync();

        //    extentTest?.Log(Status.Pass, "clickUseTheDataAC7 passed");
        //}

        [Test, Order(7), Category("functional")]
        public async Task ClickAboutThisServiceTileAC()
        {
            await page.Locator(FipsLocator.ABOUT_SERVICE_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("About this service", new() { Exact = true })).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "ClickAboutThisServiceTileAC passed");
        }

        [Test, Order(8), Category("functional")]
        public async Task ClickKeepInformationUpdatedTileAC8()
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

            extentTest?.Log(Status.Pass, "ClickKeepInformationUpdatedTileAC8 passed");
        }

        [Test, Order(9), Category("functional")]
        public async Task CheckBrowseCategoriesPageDescriptionAC2()
        {

            await page.Locator(FipsLocator.BROWSE_CATEGORY_LOCATOR).ClickAsync();
            await Assertions.Expect(page.GetByText("Find products and services by how they are categorised", new() { Exact = true })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "CheckBrowseCategoriesPageDescriptionAC2 passed");
        }

        [Test, Order(10), Category("functional")]
        public async Task CheckCategoriesListAndDescriptionAC3()
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

            extentTest?.Log(Status.Pass, "checkCategoriesListAndDescriptionAC3 passed");
        }

        [Test, Order(11), Category("functional")]
        public async Task ClickCategoriesLinksAC4()
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

            extentTest?.Log(Status.Pass, "clickCategoriesLinksAC4 passed");
        }

        [Test, Order(12), Category("functional")]
        public async Task VerifyPhaseCategoryListAC1()
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
            extentTest?.Log(Status.Pass, "CheckPhaseCategoryListAC1 passed");
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
        public async Task ClickSubcategoryLinksForPhaseCategoryAC()
        {
            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "category_phase");
            // Iterate through each data row
            foreach (var row in dataRows)
            {
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

        [Test, Order(14), Category("functional")]
        public async Task VerifyChannelCategoryListAC()
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

            extentTest?.Log(Status.Pass, "VerifyChannelCategoryListAC passed");
        }

        [Test, Order(15), Category("functional")]
        public async Task ClickSubcategoryLinksForChannelAC()
        {
            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "category_channel");
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

                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("Channel");

                bool isRequestChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isRequestChecked, Is.True);

                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator}") + " passed");
            }
        }

        [Test, Order(16), Category("functional")]
        public async Task VerifyBusinessAreaCategoryListAC()
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
        public async Task ClickSubcategoryLinksForBusinessAreaAC()
        {
            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "category_businessarea");
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
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();

                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("Business area");

                bool isRequestChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isRequestChecked, Is.True);

                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator}") + " passed");
            }
        }

        [Test, Order(18), Category("functional")]
        public async Task VerifyTypeCategoryListAC()
        {
            goToLink("categories/type");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Type" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The type of service delivery and functionality provided.", new() { Exact = true })).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "API" })).ToBeVisibleAsync();
            // await Assertions.Expect(page.Locator(FipsLocator.TYPE_API_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Campaign" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.TYPE_CAMPAIGN_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Data collection and reporting" })).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Information" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.TYPE_INFORMATION_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Transactional" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.TYPE_TRANSACTIONAL_LINK_DESC)).ToHaveTextAsync("View products in this category");

            extentTest?.Log(Status.Pass, "VerifyTypeCategoryListAC passed");
        }

        [Test, Order(19), Category("functional")]
        public async Task ClickSubcategoryLinksForTypeAC()
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

                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
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

                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

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
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

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
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

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
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

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
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

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
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

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
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

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
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

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
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

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
            await page.GetByRole(AriaRole.Link, new() { NameString = "Give feedback or report a problem with this page" }).ClickAsync();
            await Assertions.Expect(page.GetByText("What do you want to tell us?", new() { Exact = true })).ToBeVisibleAsync();
            await page.Locator(FipsLocator.FEEDBACK_TEXTBOX_LINK).FillAsync(feedbackText);
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
            await page.GetByRole(AriaRole.Link, new() { NameString = "Give feedback or report a problem with this page" }).ClickAsync();
            await Assertions.Expect(page.GetByText("What do you want to tell us?", new() { Exact = true })).ToBeVisibleAsync();
            await page.Locator(FipsLocator.FEEDBACK_TEXTBOX_LINK).FillAsync(feedbackText);
            await Assertions.Expect(page.Locator(FipsLocator.FEEDBACK_MAXCHARS_ERROR_MESSAGE)).ToHaveTextAsync("You have 6 characters too many");
            await page.GetByRole(AriaRole.Button, new() { NameString = "Submit feedback" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.FEEDBACK_SUBMIT_ERROR_MESSAGE)).ToContainTextAsync("There is a problem");
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Your feedback must be 1000 characters or fewer" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "ValidateMaxCharsinGiveFeedbackOrReportAProblemFormUS162AC passed");
        }

        [Test, Order(47), Category("functional")]
        public async Task VerifyMainProductPageHeaderAndListUS103AC()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Products" }).ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
            //  await Assertions.Expect(page.GetByText("If you cannot find a product or service make a request to add a new entry.", new() { Exact = true })).ToBeVisibleAsync();
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
            await page.Locator(FipsLocator.USER_GROUPS_LISTBOX).FillAsync("Ac");
            await page.Locator(FipsLocator.USER_GROUPS_OPTION2).ClickAsync();
            await Assertions.Expect(page.GetByLabel("Academy headteacher (secondary)  (Academy and trust workforce)")).ToBeCheckedAsync();
            //await page.GetByRole(AriaRole.Option, new() { NameString = "Chief Social Worker for" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();

            //selecting another user groups value -
            await page.Locator(FipsLocator.USER_GROUPS_LISTBOX).FillAsync("DFE");
            await page.Locator(FipsLocator.USER_GROUPS_OPTION3).ClickAsync();
            await Assertions.Expect(page.GetByLabel("Colleague supporting DfE users  (Department for Education workforce)")).ToBeCheckedAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Task.Delay(1000);
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyUserGroupsSearchFunctionalityUS103AC passed");
        }

        [Test, Order(49), Category("functional")]
        public async Task VerifyProductNameSearchboxFunctionalityUS103AC()
        {
            await page.Locator(FipsLocator.PRODUCT_NAME_TEXTBOX).FillAsync("app");
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Task.Delay(1000);
            await page.Locator(FipsLocator.PRODUCT_NAME_TEXTBOX).FillAsync(string.Empty);

            extentTest?.Log(Status.Pass, "VerifyProductNameSearchboxFunctionalityUS103AC passed");
        }

        [Test, Order(50), Category("functional")]
        public async Task VerifyBusinessAreaCategorywiseSearchFunctionalityUS103AC()
        {
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.BUSINESS_AREA_CATEGORY).ClickAsync();
            await page.GetByRole(AriaRole.Checkbox, new() { NameString = "Enterprise Data" }).CheckAsync();
            await page.GetByRole(AriaRole.Checkbox, new() { NameString = "Operations and Infrastructure" }).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Task.Delay(1000);
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_FILTERTAG1)).ToHaveTextAsync("Remove this filter enterprise-data");
            await Assertions.Expect(page.Locator(FipsLocator.BUSINESS_AREA_FILTERTAG2)).ToHaveTextAsync("Remove this filter operations-and-infrastructure");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyBusinessAreaCategorywiseSearchFunctionalityUS103AC passed");
        }

        [Test, Order(51), Category("functional")]
        public async Task VerifyChannelCategorywiseSearchFunctionalityUS103AC()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.CHANNEL_CATEGORY).ClickAsync();
            await page.GetByRole(AriaRole.Checkbox, new() { NameString = "Web (63)" }).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHANNEL_SELECTED_FILTERTAG1)).ToHaveTextAsync("Remove this filter Web");
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Task.Delay(1000);
            //going to next pages to check products list -
            await page.Locator(FipsLocator.PAGE_2_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?channel=web&page=2");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PAGE_3_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?channel=web&page=3");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Task.Delay(1000);

            extentTest?.Log(Status.Pass, "VerifyChannelCategorywiseSearchFunctionalityUS103AC passed");
        }

        [Test, Order(52), Category("functional")]
        public async Task VerifyPhaseCategorywiseSearchFunctionalityUS103AC()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PHASE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.PHASE_CATEGORY).ClickAsync();
            await page.GetByRole(AriaRole.Checkbox, new() { NameString = "Alpha" }).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
            await Assertions.Expect(page.Locator(FipsLocator.MAKE_A_REQUEST_DESC)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("No products found matching your filters.")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CLEAR_FILTER_DESC)).ToBeVisibleAsync();
            await Task.Delay(1000);
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyPhaseCategorywiseSearchFunctionalityUS103AC passed");
        }

        [Test, Order(53), Category("functional")]
        public async Task VerifyTypeCategorywiseSearchFunctionalityUS103AC()
        {
            await Assertions.Expect(page.Locator(FipsLocator.TYPE_CATEGORY)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.TYPE_CATEGORY).ClickAsync();
            await page.GetByRole(AriaRole.Checkbox, new() { NameString = "Campaign (1)" }).CheckAsync();
            await page.GetByRole(AriaRole.Checkbox, new() { NameString = "Information (39)" }).CheckAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.NEXT_PAGE_LINK).ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync("https://find-products-services-test.azurewebsites.net/Products?type=campaign&type=information&page=2");
            await Assertions.Expect(page.Locator(FipsLocator.PRODUCTS_AND_SERVICES_LIST)).ToBeVisibleAsync();
            await Task.Delay(1000);
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear filters" }).ClickAsync();

            extentTest?.Log(Status.Pass, "VerifyTypeCategorywiseSearchFunctionalityUS103AC passed");
        }

        [Test, Order(54), Category("functional")]
        public async Task VerifyMakeARequestLinkOnPageUS103AC()
        {
            goToLink("products");
            await Assertions.Expect(page.Locator(FipsLocator.MAKE_A_REQUEST_DESC)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = "make a request" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Request a new product entry" })).ToBeVisibleAsync();
            await page.GoBackAsync();

            extentTest?.Log(Status.Pass, "VerifyMakeARequestLinkOnPageUS103AC passed");
        }

        [Test, Order(55), Category("functional")]
        public async Task VerifyProductOverviewPageHeadersUS168AC()
        {
            goToLink("product/VRM-926");
            // await page.Locator(FipsLocator.PRODUCT_LINK).ClickAsync();
            // await page.Locator("a").Filter(new() { HasTextString = "Accessibility and inclusion" }).Nth(1).ClickAsync();
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
                                                   Filter(new LocatorFilterOptions { HasTextString = "Operations and Infrastructure" }).
                                                   Filter(new LocatorFilterOptions { HasTextString = "1 contacts" }).
                                                   Filter(new LocatorFilterOptions { HasTextString = "View product" });
            await Assertions.Expect(targetHeader).ToBeVisibleAsync();
            await Assertions.Expect(targetValueRow).ToBeVisibleAsync();

            // Assert that when clicking on '1 contacts' link Contacts description is displayed -
            await targetValueRow.GetByRole(AriaRole.Link, new LocatorGetByRoleOptions { NameString = "1 contacts" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.RESPONSIBILITIES_AND_CONTACTS_HEADER)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.SERVICE_OWNER_LOCATOR)).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CONTACTS_NAME_LINK)).ToBeVisibleAsync();

            //Assert clicking on 'View products',product page opens in new tab -
            //await targetValueRow.GetByRole(AriaRole.Link, new() { NameString = "View product" }).ClickAsync();

        }

        [Test, Order(56), Category("functional")]
        public async Task VerifyProductOverviewPageLinksUS168AC()
        {
            //Assertion for Overview link - 
            await Assertions.Expect(page.Locator(FipsLocator.OVERVIEW_LINK)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Description" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Standards and guidance for designing and building accessible and inclusive products and services in DfE.")).ToBeVisibleAsync();

            //Assertion for categories link - 
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
        }

        [Test, Order(57), Category("functional")]
        public async Task VerifyProductDetailsInTable()
        {
            await page.Locator(FipsLocator.CATEGORIES_LINK).ClickAsync();
            var expectedTableData = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "Phase", "Phase: \n                                        Live" },
                    { "Business area", "Business area: \nOperations and Infrastructure" },
                    { "Contacts", "1 contacts" },
                    { "View product", "View product: \n                                        View product" }
                },
            };

            // Call the generic assertion method within the test
            await AssertTableColumnValues(page, expectedTableData, FipsLocator.PRODUCT_DETAIL_TABLE);
        }

        [Test, Order(58), Category("functional")]
        public async Task VerifyCategoriesDetailsInTable()
        {
            //goToLink("product/VRM-926/categories");
            var expectedTableData = new List<Dictionary<string, string>>
            {

                new Dictionary<string, string>
                {
                    { "Name", "Operations and Infrastructure" },
                    { "Type", "Business area" },
                    { "Description", "Internal operations, technology infrastructure and support services." }
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
        }

        [Test, Order(59), Category("functional")]
        public async Task VerifyUsersOfTheProductTable()
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
        }

        [Test, Order(60), Category("accessibility")]
        public async Task AccessibilityTest()
        {
            var axeResults = await page.RunAxe();
            var violations = axeResults.Violations;

            foreach (var violation in axeResults.Violations)
            {
                extentTest.Fail($"❌ Rule: {violation.Id}");
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
