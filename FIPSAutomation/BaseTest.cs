using AventStack.ExtentReports;
using find_information_products_services_tests.constants;
using FiPSAutomation.utilities;
using Microsoft.Playwright;

namespace FiPSAutomation
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
                Headless = false,//false true
                Args = new List<string> { "--start-maximized" },
            });
            //context = await browser.NewContextAsync();
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });
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
            if (URLConstant.ENVIRONMENT == "dev")
            {
                await page.GotoAsync(URLConstant.DEV_FIPS_URL + link);
            }
            else if (URLConstant.ENVIRONMENT == "test")
            {
                await page.GotoAsync(URLConstant.TEST_FIPS_URL + link);
            }
        }

        public async void clickLink(String link)
        {
            await page.Locator(link).ClickAsync();

        }

        protected async Task loginWithUsernameAndPasswordAndAcceptAndHideCookies()
        {
            if (URLConstant.ENVIRONMENT == "dev")
            {
                await page.GotoAsync(URLConstant.DEV_LOGIN_OAUTH_URL);
                try
                {
                    await page.GetByPlaceholder("Email or phone").ClickAsync();

                    //byte[] decodedBytes = Convert.FromBase64String(Environment.GetEnvironmentVariable("KEY11"));
                    //string decodedString = Encoding.UTF8.GetString(decodedBytes);
                    //await page.GetByPlaceholder("Email or phone").FillAsync(decodedString);
                    await page.GetByPlaceholder("Email or phone").FillAsync(LoginConstant.USERNAME);
                    await page.GetByRole(AriaRole.Button, new() { NameString = "Next" }).ClickAsync();

                    await page.WaitForURLAsync(URLConstant.DEV_LOGIN_SSO_URL);
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
                await page.WaitForURLAsync(URLConstant.DEV_FIPS_URL);
            }
            else if (URLConstant.ENVIRONMENT == "test")
            {
                await page.GotoAsync(URLConstant.TEST_LOGIN_OAUTH_URL);
                try
                {
                    await page.GetByPlaceholder("Email or phone").ClickAsync();

                    //byte[] decodedBytes = Convert.FromBase64String(Environment.GetEnvironmentVariable("KEY11"));
                    //string decodedString = Encoding.UTF8.GetString(decodedBytes);
                    //await page.GetByPlaceholder("Email or phone").FillAsync(decodedString);
                    await page.GetByPlaceholder("Email or phone").FillAsync(LoginConstant.USERNAME);
                    await page.GetByRole(AriaRole.Button, new() { NameString = "Next" }).ClickAsync();

                    await page.WaitForURLAsync(URLConstant.TEST_LOGIN_SSO_URL);
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
                await page.WaitForURLAsync(URLConstant.TEST_FIPS_URL);
            }
            else if(URLConstant.ENVIRONMENT == "WITHOUT_LOGIN") {
                goToLink("");
            }
            extentTest?.Log(Status.Pass, "loginWithUsernameAndPassword passed");

            await page.GetByRole(AriaRole.Button, new() { NameString = "Accept analytics cookies" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Hide cookie message" }).ClickAsync();

            extentTest?.Log(Status.Pass, "acceptCookiesAndHide passed");
        }

        protected async Task AssertTableColumnValues(IPage page, List<Dictionary<string, string>> expectedRows, string govTableLocator)
        {
            var tableLocator = page.Locator(govTableLocator);

            await tableLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

            //headers
            var headersLocator = tableLocator.Locator(".govuk-table__head th");

            await headersLocator.First.WaitForAsync();

            var headers = await headersLocator.AllTextContentsAsync();
            var cleanedHeaders = headers.Select(h => h.Trim()).ToList();

            //all rows
            var rowsLocator = tableLocator.Locator(".govuk-table__body .govuk-table__row");

            await rowsLocator.First.WaitForAsync();

            int actualRowCount = await rowsLocator.CountAsync();

            Assert.That(actualRowCount, Is.EqualTo(expectedRows.Count),
                $"Expected {expectedRows.Count} rows in the table, but found {actualRowCount} rows.");

            for (int rowIndex = 0; rowIndex < actualRowCount; rowIndex++)
            {
                var expectedRowData = expectedRows[rowIndex];
                var dataCellsLocator = rowsLocator.Nth(rowIndex).Locator(".govuk-table__cell");

                //expected columns check with actual columns
                Assert.That(expectedRowData.Count, Is.EqualTo(cleanedHeaders.Count),
                    $"Row {rowIndex + 1}: Expected {cleanedHeaders.Count} columns, but the expected data dictionary has {expectedRowData.Count} keys.");

                foreach (var expectedKvp in expectedRowData)
                {
                    string headerName = expectedKvp.Key.Trim();
                    string expectedValue = expectedKvp.Value.Trim();

                    //find index of header
                    int columnIndex = cleanedHeaders.FindIndex(h => h.Contains(headerName));

                    Assert.That(columnIndex, Is.Not.EqualTo(-1),
                        $"Header '{headerName}' not found in the table headers for row {rowIndex + 1}.");

                    //get cell value
                    var cellLocator = dataCellsLocator.Nth(columnIndex);

                    string actualValue = (await cellLocator.TextContentAsync())?.Trim() ?? string.Empty;

                    Assert.That(actualValue.Trim(), Is.EqualTo(expectedValue),
                        $"Row {rowIndex + 1}, Column '{headerName}': Expected value '{expectedValue}', but found '{actualValue}'.");
                }
            }
        }

    }
}
