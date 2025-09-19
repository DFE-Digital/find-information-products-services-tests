using AventStack.ExtentReports;
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

        [OneTimeSetUp]
        public async Task RunBeforeAnyTests()
        {
            playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,//false true
            });
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
            //var reportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestResults", "extent1.html");
            extent = ExtentReportHelper.InitialiseReport("extent-"+ DateTime.Now.ToString("yyyy-MM-dd HHmmss")+".html", "FiPS Automation Report");
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
    }
}
