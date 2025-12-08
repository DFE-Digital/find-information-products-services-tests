//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Model;
//using find_information_products_services_tests.constants;
//using find_information_products_services_tests.utilities;
//using FiPSAutomation;
//using Microsoft.Playwright;
//using static find_information_products_services_tests.utilities.ExcelReader;

//namespace find_information_products_services_tests
//{
//    internal class FastTest : BaseTest
//    {

//        [Test, Order(1), Category("smoke")]
//        public async Task LoginWithUsernameAndPassword()
//        {
//            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
//        }
        
//        [Test, Order(2), Category("functional")]
//        public async Task VerifyUGEPEYSchoolWorkforceSubcategoryListUS136AC()
//        {
//            List<SheetRow> dataRows = ExcelReader.getCategoryRowsFromExcelFileBySheetName("testdata.xlsx", "UG_EPEY_SchoolWorkforce_list");
//            if (dataRows.Count > 1)
//            {
//                goToLink(dataRows[0].Col1);
//                await Assertions.Expect(page.Locator(dataRows[0].Col2)).ToHaveTextAsync("Education provider and early years workforce - School workforce");
//                await Assertions.Expect(page.GetByText(dataRows[0].Col3, new() { Exact = true })).ToBeVisibleAsync();
//                await Assertions.Expect(page.Locator(dataRows[1].Col2)).ToHaveTextAsync(dataRows[1].Col3);
//                await Assertions.Expect(page.Locator(dataRows[2].Col2)).ToHaveTextAsync(dataRows[2].Col3);

//                for (int i = 1; i < dataRows.Count; i++)
//                {
//                    if (dataRows[i].Col1 != "")
//                    {
//                        await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = dataRows[i].Col1 })).ToBeVisibleAsync();
//                    }
//                }
//                extentTest?.Log(Status.Pass, "VerifyUGEPEYSchoolWorkforceSubcategoryListUS136AC passed");
//            }
//        }

//        [Test, Order(3), Category("functional")]
//        public async Task ClickSubcategoryLinksForSchoolWorkforceEPEYUS136AC()
//        {
//            List<FipsSheetRowUG> dataRows = ExcelReader.getRowsFromExcelForSelectedUserType("testdata.xlsx", "EPEYSubcateg_SchoolWorkforce");
//            foreach (var row in dataRows)
//            {
//                TestContext.WriteLine($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes} passed");

//                goToLink(row.Product_Locator);

//                var FilterText = page.Locator(row.Filter_Tag);
//                await Assertions.Expect(FilterText).ToBeVisibleAsync();
//                await Assertions.Expect(FilterText).ToHaveTextAsync(row.Message);
//                await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = row.Heading })).ToBeVisibleAsync();
//                await Assertions.Expect(page.Locator(row.Filter_Text_Locator)).ToHaveTextAsync("User groups");
//                bool isUsertypeChecked = await page.Locator(row.Checkbox_Locator).IsCheckedAsync();
//                Assert.That(isUsertypeChecked, Is.True);
//                await Assertions.Expect(page.Locator(row.Selected_UserTypes_Locator)).ToHaveTextAsync(row.Selected_UserTypes);
//                await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");

//                extentTest?.Log(Status.Pass, ($"Running test for: Product={row.Product_Locator}, Filter={row.Selected_UserTypes}") + " passed");
//            }
//        }

       
//    }
//}
