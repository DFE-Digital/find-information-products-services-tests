//using AventStack.ExtentReports;
//using find_information_products_services_tests.HomePageTestCases.constants;
//using find_information_products_services_tests.HomePageTestCases.utilities;
//using FiPSAutomation.HomePageTestCases;
//using Microsoft.Playwright;

//namespace find_information_products_services_tests.HomePageTestCases
//{
//    internal class ExcelTest : BaseTest
//    {
//        [Test, Order(1), Category("smoke")]
//        public async Task LoginWithUsernameAndPassword()
//        {
//            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
//        }

//        [Test, Order(2), Category("functional")]
//        public async Task ClickRequestLinkAC2A()
//        {
//            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "products");
//            // Iterate through each data row
//            foreach (var row in dataRows)
//            {
//                //Task.Delay(1000);
//                // Print a log to the NUnit output for traceability
//                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator} passed");

//                goToLink(row.Product_Locator);

//                var requestTag = page.Locator(row.Filter_Tag);

//                // Assert that the filter tag exists and is visible
//                await Assertions.Expect(requestTag).ToBeVisibleAsync();

//                //Assert the text content of the filter tag toHaveTextAsync checks that the element has the exact text.
//                await Assertions.Expect(requestTag).ToHaveTextAsync(row.Message);

//                //Locate and assert the page header and "phase" subheading
//                await Assertions.Expect(page.GetByRole(AriaRole.Heading,
//                    new() { NameString = row.Heading })).ToBeVisibleAsync();

//                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("Phase");

//                bool isRequestChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
//                Assert.That(isRequestChecked, Is.True);

//                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
//                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator}") + " passed");
//            }
//        }
//    }
//}
