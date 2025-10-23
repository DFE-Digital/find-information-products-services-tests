using AventStack.ExtentReports;
using Deque.AxeCore.Playwright;
using DocumentFormat.OpenXml.Wordprocessing;
using find_information_products_services_tests.HomePageTestCases.constants;
using find_information_products_services_tests.HomePageTestCases.utilities;
using Microsoft.Playwright;
using static find_information_products_services_tests.HomePageTestCases.utilities.ExcelReader;

namespace FiPSAutomation.HomePageTestCases
{
    public class HomeTest : BaseTest
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
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Business area" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The business area or portfolio responsible for a product or service.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("10 main categories", new() { Exact = true })).ToBeVisibleAsync();

            //verifying Phase Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Phase" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The stage a product or service is at in the service delivery lifecycle.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("7 options", new() { Exact = true })).ToBeVisibleAsync();

            //verifying Type Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Type" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The type of service delivery and functionality provided.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("5 options", new() { Exact = true })).ToBeVisibleAsync();

            //verifying User group Link -
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "User group" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("The users of the product or service.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("11 main categories", new() { Exact = true })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "checkCategoriesListAndDescriptionAC3 passed");
        }

        [Test, Order(12), Category("functional")]
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

        [Test, Order(13), Category("functional")]
        public async Task VerifyPhaseCategoryListAC1()
        {
            goToLink("categories/phase");
            await Assertions.Expect(page.GetByText("The stage a product or service is at in the service delivery lifecycle.", new() { Exact = true })).ToBeVisibleAsync();
           // await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Request" })).ToBeVisibleAsync();
           // await Assertions.Expect(page.Locator(FipsLocator.PHASE_REQUEST_LINK_DESC)).ToHaveTextAsync("View products in this category")
           // ;
          // await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Explore" })).ToBeVisibleAsync();
          // await Assertions.Expect(page.Locator(FipsLocator.PHASE_EXPLORE_LINK_DESC)).ToHaveTextAsync("View products in this category");

          // await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Triage" })).ToBeVisibleAsync();
          // await Assertions.Expect(page.Locator(FipsLocator.PHASE_TRIAGE_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Discovery" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Alpha" })).ToBeVisibleAsync();
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

        [Test, Order(14), Category("functional")]
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

        [Test, Order(15), Category("functional")]
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

        [Test, Order(16), Category("functional")]
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

        [Test, Order(17), Category("functional")]
        public async Task VerifyBusinessAreaCategoryListAC()
        {
            goToLink("categories/business-area");
            await Assertions.Expect(page.GetByText("The business area or portfolio responsible for a product or service.", new() { Exact = true })).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Commercial" })).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "CXD" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.OPERATIONSANDINFRA_CXD_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Enterprise Data" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.OPERATIONSANDINFRA_ENTERPRISEDATA_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Families" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.GROUP_FAMILIES_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Funding" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.OPERATIONSANDINFRA_FUNDING_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Operations and Infrastructure" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.Locator(FipsLocator.GROUP_OPERATIONSANDINFRA_LINK_DESC)).ToHaveTextAsync("3 sub-categories");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Regions" })).ToBeVisibleAsync();

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Schools" })).ToBeVisibleAsync();
          //await Assertions.Expect(page.Locator(FipsLocator.GROUP_SCHOOLS_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Skills" })).ToBeVisibleAsync();
          //await Assertions.Expect(page.Locator(FipsLocator.GROUP_SKILLS_LINK_DESC)).ToHaveTextAsync("View products in this category");

            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Strategy" })).ToBeVisibleAsync();
          //await Assertions.Expect(page.Locator(FipsLocator.GROUP_STRATEGY_LINK_DESC)).ToHaveTextAsync("View products in this category");
      
            await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync(); //verify Back link on page
            extentTest?.Log(Status.Pass, "VerifyBusinessAreaCategoryListAC passed");
        }

        [Test, Order(18), Category("functional")]
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

        [Test, Order(19), Category("functional")]
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

        [Test, Order(20), Category("functional")]
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

        [Test, Order(21), Category("functional")]
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

        [Test, Order(22), Category("functional")]
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
                       // await Assertions.Expect(page.Locator(dataRows[i].Col1)).ToHaveTextAsync(dataRows[i].Col3);
                    }
                }
                extentTest?.Log(Status.Pass, "VerifyUGAdultLearner18SubcategoryListUS30AC passed");
            }
        }

        [Test, Order(23), Category("functional")]
        public async Task VerifyUGCareersAdviserOrWorkCoachSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_CareersAdviser_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("Careers adviser or work coach");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGCareersAdviserOrWorkCoachSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(24), Category("functional")]
        public async Task VerifyUGChildOrYoungPersonSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_ChildOrYoungPers_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("Child or young person");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGChildOrYoungPersonSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(25), Category("functional")]
        public async Task VerifyUGDfEWorkforceSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_DfEWorkforce_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("Department for Education workforce");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGDfEWorkforceSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(26), Category("functional")]
        public async Task VerifyUGEPAndEYWorkforceSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_EPandEYWorkforce_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("Education provider and early years workforce");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGEPAndEYWorkforceSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(27), Category("functional")]
        public async Task VerifyUGEmployerSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_Employer_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("Employer");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGEmployerSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(28), Category("functional")]
        public async Task VerifyUGLocalAuthorityWorkforceSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_LAWorkforce_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("Local authority workforce");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGLocalAuthorityWorkforceSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(29), Category("functional")]
        public async Task VerifyUGNEETOrCareerSeekerSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_NEETOrCareerSeek_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("NEET or career seeker");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGNEETOrCareerSeekerSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(30), Category("functional")]
        public async Task VerifyUGParentOrCarerSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_ParentorCarer_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("Parent or carer");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGParentOrCarerSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(31), Category("functional")]
        public async Task VerifyUGProfExternalUserofDfEDataSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_ProfExtUserofDfE_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("Professional external user of DfE data");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGProfExternalUserofDfEDataSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(32), Category("functional")]
        public async Task VerifyUGSocialCareWorkforceSubcategoryListUS30AC()
        {
            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "usergroup_SocialCWorkforce_list");
            if (dataRows.Count > 1)
            {
                SheetRow sheetRow = dataRows[0];
                goToLink(sheetRow.Col1);
                await Assertions.Expect(page.Locator(sheetRow.Col2)).ToHaveTextAsync("Social care workforce");
                await Assertions.Expect(page.GetByText(sheetRow.Col3, new() { Exact = true })).ToBeVisibleAsync();

                for (int i = 1; i < dataRows.Count; i++)
                {
                    if (dataRows[i].Col1 != "")
                    {
                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
                    }
                    await Assertions.Expect(page.Locator(dataRows[i].Col2)).ToHaveTextAsync(dataRows[i].Col3);
                }
                extentTest?.Log(Status.Pass, "VerifyUGSocialCareWorkforceSubcategoryListUS30AC passed");
            }
        }

        [Test, Order(33), Category("accessibility")]
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
