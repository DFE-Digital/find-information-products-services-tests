using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using find_information_products_services_tests.HomePageTestCases.utilities;
using FiPSAutomation.HomePageTestCases.utilities;
using Microsoft.Playwright;
using Microsoft.VisualBasic;

namespace FiPSAutomation.HomePageTestCases
{
    internal class HomeTest : BaseTest
    {
        private ExtentTest? _extentTest;

        [SetUp]
        public void SetUp() {
            // Create an Extent Test node for each individual test
            _extentTest = ExtentReportHelper.extent?.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test, Order(1)]
        public async Task InitialSetup()
        {
            // Log steps and pass/fail status
            _extentTest?.Log(Status.Info, "Starting search test");

            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,//false true
            });

            browserContext = await browser.NewContextAsync();

            page = await browserContext.NewPageAsync();
        }

        [Test, Order(2), Category("smoke")]
        public async Task LoginWithUsernameAndPassword() {
            await page.GotoAsync("https://login.microsoftonline.com/common/oauth2/v2.0/authorize?response_type=code+id_token&redirect_uri=https%3A%2F%2Ffind-products-services-dev.education.gov.uk%2F.auth%2Flogin%2Faad%2Fcallback&client_id=31ff7feb-28d4-450b-9eef-0d79bb8edb1f&scope=openid+profile+email&response_mode=form_post&nonce=47d64632ccef4060980eed87c512efee_20250915055830&state=redir%3D%252F");
            await page.GetByPlaceholder("Email or phone").ClickAsync();

            await page.GetByPlaceholder("Email or phone").FillAsync(TestConstant.USERNAME);

            await page.GetByRole(AriaRole.Button, new() { NameString = "Next" }).ClickAsync();
            await page.WaitForURLAsync("https://login.microsoftonline.com/common/oauth2/v2.0/authorize?response_type=code+id_token&redirect_uri=https%3A%2F%2Ffind-products-services-dev.education.gov.uk%2F.auth%2Flogin%2Faad%2Fcallback&client_id=31ff7feb-28d4-450b-9eef-0d79bb8edb1f&scope=openid+profile+email&response_mode=form_post&nonce=47d64632ccef4060980eed87c512efee_20250915055830&state=redir%3D%252F&sso_reload=true");

            await page.GetByPlaceholder("Password").ClickAsync();

            await page.GetByPlaceholder("Password").FillAsync(TestConstant.PASSWORD);

            await page.GetByRole(AriaRole.Button, new() { NameString = "Sign in" }).ClickAsync();
            await page.WaitForURLAsync("https://login.microsoftonline.com/common/login");

            await page.GetByRole(AriaRole.Button, new() { NameString = "Yes" }).ClickAsync();
            await page.WaitForURLAsync("https://find-products-services-dev.education.gov.uk/");
            _extentTest?.Log(Status.Pass, "Pressed Enter");
        }

        [Test, Order(3), Category("functional")]
        public async Task AcceptCookiesAndHide() {
            await page.GetByRole(AriaRole.Button, new() { NameString = "Accept analytics cookies" }).ClickAsync();

            await page.GetByRole(AriaRole.Button, new() { NameString = "Hide cookie message" }).ClickAsync();
        }

        [Test, Order(4), Category("functional")]
        public async Task HomePageVerificationAC1() {
            await Assertions.Expect(page).ToHaveTitleAsync("Find information about products and services - FIPS");
            await Assertions.Expect(page.GetByText("Find information about products and services")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use this service to explore what DfE delivers. Build on existing work, avoid duplication, and work more effectively across teams.")).ToBeVisibleAsync();

            var searchlink = page.Locator("[class=\"govuk-button govuk-button--start govuk-button--inverse home-cta-link\"]");
            await Assertions.Expect(searchlink).ToHaveTextAsync(" Search products and services ");
            _extentTest?.Log(Status.Pass, "Search assertion passed"); 

            var link1 = page.Locator("//*[contains(text(),'About this service')]");
            await Assertions.Expect(link1).ToHaveTextAsync("About this service");
            _extentTest?.Log(Status.Pass, "About this service assertion passed");
        }

        [Test, Order(5), Category("functional")]
       public async Task ClickSearchButtonAC2()
        {
            await page.Locator("[class=\"govuk-button govuk-button--start govuk-button--inverse home-cta-link\"]").ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await page.GoBackAsync();
            _extentTest?.Log(Status.Pass, "clickSearchButtonAC2 passed");

        }

        [Test, Order(6), Category("functional")]
        public async Task ClickAboutThisServiceAC3()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "About this service" }).ClickAsync();
           // await page.Locator("//*[contains(text(),'About this service')]").ClickAsync();
            await Assertions.Expect(page.GetByText("About this service")).ToBeVisibleAsync();
            await page.GoBackAsync();
            _extentTest?.Log(Status.Pass, "clickAboutThisServiceAC3 passed");
        }

        [Test, Order(7), Category("functional")]
        public async Task TilesAreVisibleAC4()
        {
            //await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "All products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("All products and services")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Browse categories")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Using this service")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use the data")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Keeping information updated")).ToBeVisibleAsync();
            _extentTest?.Log(Status.Pass, "TilesAreVisibleAC4 passed");
        }

        [Test, Order(8), Category("functional")]
        public async Task ClickAllproductsAndServicesAC5()
        {
            await page.Locator("//h2[text() = 'All products and services']").ClickAsync();
            await Assertions.Expect(page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
            await page.GoBackAsync();
            _extentTest?.Log(Status.Pass, "ClickAllproductsAndServicesAC5 passed");
        }

        [Test, Order(9), Category("functional")]
        public async Task ClickBrowseCategoriesAC6()
        {
            await page.Locator("//h2[text() = 'Browse categories']").ClickAsync();
            //await Assertions.Expect(page.GetByText("Browse categories")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            _extentTest?.Log(Status.Pass, "ClickBrowseCategoriesAC6 passed");
        }

        [Test, Order(10), Category("functional")]
        public async Task ClickUseTheDataAC7()
        {
            await page.Locator("//h2[text() = 'Use the data']").ClickAsync();           
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Using the data" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            _extentTest?.Log(Status.Pass, "ClickUseTheDataAC7 passed");
        }

        [Test, Order(11), Category("functional")]
        public async Task ClickKeepingInformationUpdatedAC8()
        {
            await page.Locator("//h2[text() = 'Keeping information updated']").ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Get help" })).ToBeVisibleAsync();
            await page.GoBackAsync();
            _extentTest?.Log(Status.Pass, "ClickKeepingInformationUpdatedAC8 passed");
        }

        [TearDown]
        public void TearDown() {
            // Add final test status (e.g., Pass, Fail)
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                _extentTest?.Log(Status.Fail, "Test failed");
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                _extentTest?.Log(Status.Pass, "Test passed");
            }
        }
    }
}
