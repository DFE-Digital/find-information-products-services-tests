using AventStack.ExtentReports;
using find_information_products_services_tests.HomePageTestCases.constants;
using FiPSAutomation.HomePageTestCases;
using Microsoft.Playwright;

namespace find_information_products_services_tests.HomePageTestCases
{
    internal class FastTest : BaseTest
    {

        [Test, Order(1), Category("smoke")]
        public async Task LoginWithUsernameAndPassword()
        {
            await page.GotoAsync(URLConstant.LOGIN_OAUTH_URL);
            await page.GetByPlaceholder("Email or phone").ClickAsync();

            await page.GetByPlaceholder("Email or phone").FillAsync(LoginConstant.USERNAME);

            await page.GetByRole(AriaRole.Button, new() { NameString = "Next" }).ClickAsync();
            await page.WaitForURLAsync(URLConstant.LOGIN_SSO_URL);

            await page.GetByPlaceholder("Password").ClickAsync();

            await page.GetByPlaceholder("Password").FillAsync(LoginConstant.PASSWORD);

            await page.GetByRole(AriaRole.Button, new() { NameString = "Sign in" }).ClickAsync();
            await page.WaitForURLAsync(URLConstant.LOGIN_URL);

            await page.GetByRole(AriaRole.Button, new() { NameString = "Yes" }).ClickAsync();
            await page.WaitForURLAsync(URLConstant.FIPS_URL);

            await page.GetByRole(AriaRole.Button, new() { NameString = "Accept analytics cookies" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Hide cookie message" }).ClickAsync();

            extentTest?.Log(Status.Pass, "acceptCookiesAndHide passed");

            extentTest?.Log(Status.Pass, "loginWithUsernameAndPassword passed");
        }

        [Test, Order(2), Category("functional")]
        public async Task ClickRequestLinkAC2()
        {
            goToLink("products?phase=request");

            var requestTag = page.Locator(FipsLocator.PHASE_FILTER_REQUEST_TAG);

            // Assert that the filter tag exists and is visible
            await Assertions.Expect(requestTag).ToBeVisibleAsync();

            // 3. Assert the text content of the filter tag
            // toHaveTextAsync checks that the element has the exact text.
            await Assertions.Expect(requestTag).ToHaveTextAsync("Remove this filter Request");

            // 4. Locate and assert the page header and "phase" subheading
            await Assertions.Expect(page.GetByRole(AriaRole.Heading,
                new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();

            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_TEXT)).ToHaveTextAsync("Phase");

            bool isRequestChecked = await page.Locator("#phase-request").IsCheckedAsync();
            Assert.That(isRequestChecked, Is.True);

            // Get the state of the "explore" checkbox and assert it is false.
            bool isExploreChecked = await page.Locator("#phase-explore").IsCheckedAsync();
            Assert.That(isExploreChecked, Is.False);

            await Assertions.Expect(page.Locator(FipsLocator.SHOWING_PRODUCTS_MESSAGE)).ToContainTextAsync("products and services");
            extentTest?.Log(Status.Pass, "ClickRequestLinkAC2 passed");
        }

        [Test, Order(3), Category("functional")]
        public async Task ClickExploreLinkAC2()
        {
            goToLink("products?phase=explore");

            var exploreTag = page.Locator(FipsLocator.PHASE_FILTER_EXPLORE_TAG);
            await Assertions.Expect(exploreTag).ToBeVisibleAsync();

            // 3. Assert the text content of the filter tag
            // toHaveTextAsync checks that the element has the exact text.
            await Assertions.Expect(exploreTag).ToHaveTextAsync("Remove this filter Explore");

            // 4. Locate and assert the page header and "phase" subheading
            await Assertions.Expect(page.GetByRole(AriaRole.Heading,
                new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();

            await Assertions.Expect(page.Locator(FipsLocator.PHASE_FILTER_TEXT)).ToHaveTextAsync("Phase");

            bool isRequestChecked = await page.Locator("#phase-request").IsCheckedAsync();
            Assert.That(isRequestChecked, Is.False);

            // Get the state of the "explore" checkbox and assert it is false.
            bool isExploreChecked = await page.Locator("#phase-explore").IsCheckedAsync();
            Assert.That(isExploreChecked, Is.True);

            extentTest?.Log(Status.Pass, "ClickExploreLinkAC2 passed");
        }
    }
}
