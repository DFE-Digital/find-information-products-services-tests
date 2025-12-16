using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using find_information_products_services_tests.constants;
using find_information_products_services_tests.utilities;
using FiPSAutomation;
using Microsoft.Playwright;
using static find_information_products_services_tests.utilities.ExcelReader;

namespace find_information_products_services_tests
{
    internal class FastTest : BaseTest
    {

        [Test, Order(1), Category("smoke")]
        public async Task LoginWithUsernameAndPassword()
        {
            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
        }

        [Test, Order(2), Category("functional")]
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

    }
}
