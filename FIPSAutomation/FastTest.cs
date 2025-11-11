using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Model;
using Deque.AxeCore.Playwright;
using DocumentFormat.OpenXml.Spreadsheet;
using find_information_products_services_tests.HomePageTestCases.constants;
using find_information_products_services_tests.HomePageTestCases.utilities;
using FiPSAutomation.HomePageTestCases;
using Microsoft.Playwright;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using static find_information_products_services_tests.HomePageTestCases.utilities.ExcelReader;

namespace find_information_products_services_tests.HomePageTestCases
{
    internal class FastTest : BaseTest
    {

        [Test, Order(1), Category("smoke")]
        public async Task LoginWithUsernameAndPassword()
        {
            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
        }

        //[Test, Order(2), Category("functional")]
        //public async Task VerifyTilesHeading()
        //{
        //    await Assertions.Expect(page.Locator(FipsLocator.HOME_PAGE_TILES)).ToBeVisibleAsync();
        //    await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "All products and services" })).ToBeVisibleAsync();
        //    await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
        //    await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Keep information updated" })).ToBeVisibleAsync();
        //    await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "About this service" })).ToBeVisibleAsync();
        //    await Assertions.Expect(page.GetByText("Search and filter the products and services.", new() { Exact = true })).ToBeVisibleAsync();
        //    await Assertions.Expect(page.GetByText("Find products and services by how they are categorised", new() { Exact = true })).ToBeVisibleAsync();
        //    await Assertions.Expect(page.GetByText("How to update information about products listed in this service.", new() { Exact = true })).ToBeVisibleAsync();
        //    await Assertions.Expect(page.GetByText("Find out what this service is and how it works.", new() { Exact = true })).ToBeVisibleAsync();
        //}

        //[Test, Order(6), Category("functional")]
        //public async Task ClickSubcategoryLinksForEPAndEYWorkforceUS94AC()   //excel sheet not created as story incomplete
        //{
        //    List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "UGSubcategory_EPandEYWorkforce");
        //    // Iterate through each data row
        //    foreach (var row in dataRows)
        //    {
        //        // Print a log to the NUnit output for traceability
        //        TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

        //        // Assert that the filter tag exists and is visible
        //        await Assertions.Expect(FilterText).ToBeVisibleAsync();

        //        //Assert the text content of the filter tag toHaveTextAsync checks that the element has the exact text.
        //        await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);

        //        //Locate and assert the page header 
        //        await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();

        //        //Assert the "User groups" subheading
        //        await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");

        //        bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
        //        Assert.That(isUsertypeChecked, Is.True);

        //        //verifying selectedUserTypes
        //        await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
        //        //await Assertions.Expect(page.GetByLabel("Adult learner (18+)")).ToBeVisibleAsync();

        //        await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

        //        extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
        //    }
        //}

    }
}
