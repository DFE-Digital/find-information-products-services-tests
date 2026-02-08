using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using DocumentFormat.OpenXml.Wordprocessing;
using find_information_products_services_tests.constants;
using find_information_products_services_tests.utilities;
using FiPSAutomation;
using Microsoft.Playwright;
using static find_information_products_services_tests.utilities.ExcelReader;

namespace find_information_products_services_tests
{
    [TestFixture]
    [Category("Fast Test")]
    [Order(2)]
    internal class FastTest : BaseTest
    {

        [Test, Order(1), Category("smoke")]
        public async Task LoginWithUsernameAndPasswordUS231AC2()
        {
            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
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

        [Test, Order(19), Category("functional")]
        public async Task ClickSubcategoryLinksForTypeUS276AC2()
        {
            List<FipsSheetRow> dataRows = ExcelReader.getRowsFromExcelFileBySheetName("testdata.xlsx", "category_type");
            foreach (var row in dataRows)
            {
                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator} passed");

                goToLink(row.Product_Locator);
                var requestTag = page.Locator(row.Filter_Tag);
                await Assertions.Expect(requestTag).ToBeVisibleAsync();
                await Assertions.Expect(requestTag).ToHaveTextAsync(row.Message);
                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("Type");
                bool isRequestChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
                Assert.That(isRequestChecked, Is.True);
                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_RESULTS_MESSAGE)).ToContainTextAsync("Showing");

                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Checkbox_Locator}") + " passed");
            }
        }
    }
}
