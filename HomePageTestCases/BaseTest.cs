using AventStack.ExtentReports;
using find_information_products_services_tests.HomePageTestCases.constants;
using find_information_products_services_tests.HomePageTestCases.pages;
using FiPSAutomation.HomePageTestCases.utilities;
using Microsoft.Playwright;
using System.Text;

namespace FiPSAutomation.HomePageTestCases
{
    public abstract class BaseTest
    {

        private static ExtentReports? extent;
        protected IPlaywright? playwright { get; private set; }
        protected IBrowser? browser { get; private set; }
        protected IBrowserContext? context { get; private set; }
        protected IPage? page { get; private set; }

        protected ExtentTest? extentTest;

        // Declare properties for each of your page object models
        //protected LoginPage? loginPage { get; private set; }
        //protected HomePage? homePage { get; private set; }
        //protected CategoriesPage? categoryPage { get; private set; }

        [OneTimeSetUp]
        public async Task RunBeforeAnyTests()
        {
            // 1. Initialize Playwright
            playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,//false true
            });
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
            //var reportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestResults", "extent1.html");
            extent = ExtentReportHelper.InitialiseReport("extent-"+ DateTime.Now.ToString("yyyy-MM-dd HHmmss")+".html", "FiPS Automation Report");

            // 2. Initialize each Page Object Model with the same IPage instance
            //loginPage = new LoginPage(page);
            //homePage = new HomePage(page);
            //categoryPage = new CategoriesPage(page);
        }

        [OneTimeTearDown]
        public async Task RunAfterAllTests()
        {
            if (browser != null)
            {
                await browser.CloseAsync();
            }
            playwright?.Dispose();
            ExtentReportHelper.FlushReport();
        }

        [SetUp]
        public void SetUp()
        {
            // Create an Extent Test node for each individual test
            extentTest = ExtentReportHelper.extent?.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public async Task TearDown()
        {
            // Add final test status (e.g., Pass, Fail)
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                byte[] screenshot = await page.ScreenshotAsync();
                string base64Screenshot = Convert.ToBase64String(screenshot);
                extentTest?.Fail("Test failed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot).Build());

                extentTest?.Log(Status.Fail, "Test failed");
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                extentTest?.Log(Status.Pass, "Test passed");
                extentTest?.Pass("Test passed ...");
            }
            else
            {
                extentTest?.Skip("Test skipped");
            }
        }

        public async void goToLink(String link) {
            //await page.GoBackAsync();
            if (URLConstant.TEST_ENVIRONMENT == "dev")
            {
                await page.GotoAsync(URLConstant.FIPS_URL + link);
            }
            else if (URLConstant.TEST_ENVIRONMENT == "test")
            {
                await page.GotoAsync(URLConstant.FIPS_TEST_URL + link);
            }
        }

        public async void clickLink(String link)
        {
            await page.Locator(link).ClickAsync();

        }

        protected async Task loginWithUsernameAndPasswordAndAcceptAndHideCookies()
        {
            if (URLConstant.TEST_ENVIRONMENT == "dev")
            {
                await page.GotoAsync(URLConstant.LOGIN_OAUTH_URL);
                try
                {
                    await page.GetByPlaceholder("Email or phone").ClickAsync();

                    //byte[] decodedBytes = Convert.FromBase64String(Environment.GetEnvironmentVariable("KEY11"));
                    //string decodedString = Encoding.UTF8.GetString(decodedBytes);
                    //await page.GetByPlaceholder("Email or phone").FillAsync(decodedString);
                    await page.GetByPlaceholder("Email or phone").FillAsync(LoginConstant.USERNAME);
                    await page.GetByRole(AriaRole.Button, new() { NameString = "Next" }).ClickAsync();

                    await page.WaitForURLAsync(URLConstant.LOGIN_SSO_URL);
                    await page.GetByPlaceholder("Password").ClickAsync();

                    //byte[] decodedBytes2 = Convert.FromBase64String(Environment.GetEnvironmentVariable("KEY22"));
                    //string decodedString2 = Encoding.UTF8.GetString(decodedBytes2);
                    //await page.GetByPlaceholder("Password").FillAsync(decodedString2);
                    await page.GetByPlaceholder("Password").FillAsync(LoginConstant.PASSWORD);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error with :- " + ex.Message);
                }
                await page.GetByRole(AriaRole.Button, new() { NameString = "Sign in" }).ClickAsync();
                await page.WaitForURLAsync(URLConstant.LOGIN_URL);

                await page.GetByRole(AriaRole.Button, new() { NameString = "Yes" }).ClickAsync();
                await page.WaitForURLAsync(URLConstant.FIPS_URL);
            }
            else if (URLConstant.TEST_ENVIRONMENT == "test") {
                goToLink("");
            }
            extentTest?.Log(Status.Pass, "loginWithUsernameAndPassword passed");

            await page.GetByRole(AriaRole.Button, new() { NameString = "Accept analytics cookies" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Hide cookie message" }).ClickAsync();

            extentTest?.Log(Status.Pass, "acceptCookiesAndHide passed");
        }

    }
}
