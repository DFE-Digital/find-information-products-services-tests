using AventStack.ExtentReports;
using FiPSAutomation.HomePageTestCases.utilities;
using Microsoft.Playwright;

namespace FiPSAutomation.HomePageTestCases
{
    internal class BaseTest
    {
        public IPlaywright playwright;
        public IBrowser browser;
        public IBrowserContext browserContext;
        public IPage page;
        public BaseTest() { }

        private static ExtentReports? extent;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            //var reportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestResults", "extent1.html");
            extent = ExtentReportHelper.InitialiseReport("extent-"+ DateTime.Now.ToString("yyyy-MM-dd HHmmss")+".html", "FiPS Automation Report");
        }

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            ExtentReportHelper.FlushReport();
            //extent?.Flush();
            //await page.CloseAsync();
            //await browserContext.CloseAsync();
        }
    }
}
