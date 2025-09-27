using AventStack.ExtentReports;
using find_information_products_services_tests.HomePageTestCases.constants;
using find_information_products_services_tests.HomePageTestCases.pages;
using FiPSAutomation.HomePageTestCases.utilities;
using Microsoft.Playwright;

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
        protected LoginPage? loginPage { get; private set; }
        protected HomePage? homePage { get; private set; }
        protected CategoriesPage? categoryPage { get; private set; }

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
        public void TearDown()
        {
            // Add final test status (e.g., Pass, Fail)
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                extentTest?.Log(Status.Fail, "Test failed");
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                extentTest?.Log(Status.Pass, "Test passed");
            }
        }

        public async void goToLink(String link) {
            //await page.GoBackAsync();
            await page.GotoAsync(URLConstant.FIPS_URL + link);
        }

        public async void clickLink(String link)
        {
            await page.Locator(link).ClickAsync();

        }

    }
}
