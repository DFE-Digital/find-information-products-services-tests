using AventStack.ExtentReports;
using find_information_products_services_tests.FIPSAutomation.login;
using FiPSAutomation.utilities;
using Microsoft.Playwright;

namespace FiPSAutomation
{
    public abstract class BaseTest
    {
        protected IPage Page => GlobalSetup.Page!;
        protected ExtentTest? ExtentTest;
        protected EnvironmentDetail ActiveEnvironment => GlobalSetup.ActiveEnvironment!;

        [SetUp]
        public void SetUp()
        {
            ExtentTest = ExtentReportHelper.extent?.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public async Task TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                byte[] screenshot = await Page.ScreenshotAsync();
                string base64Screenshot = Convert.ToBase64String(screenshot);

                ExtentTest?.Fail("Test failed",
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot).Build());

                ExtentTest?.Log(Status.Fail, "Test failed");
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                ExtentTest?.Pass("Test passed.");
            }
            else
            {
                ExtentTest?.Skip("Test skipped");
            }
        }

        protected async Task NavigateToAsync(string path)
        {
            await Page.GotoAsync(ActiveEnvironment.ApplicationURL + path);
        }

        protected void LogStep(string message)
        {
            ExtentTest?.Info(message);
        }
    }
}
