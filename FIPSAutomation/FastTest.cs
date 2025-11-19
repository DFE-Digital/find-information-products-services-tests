using AventStack.ExtentReports.Model;
using FiPSAutomation;

namespace find_information_products_services_tests
{
    internal class FastTest : BaseTest
    {

        [Test, Order(1), Category("smoke")]
        public async Task LoginWithUsernameAndPassword()
        {
            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
        }



        //[Test, Order(3), Category("functional")]
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
