using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace FiPSAutomation.HomePageTestCases.utilities
{
    internal class ExtentReportHelper
    {
        public static ExtentReports? extent;
        public static ExtentTest? test;

        public static ExtentReports InitialiseReport(string reportPath, string reportName)
        {
            var htmlReporter = new ExtentSparkReporter(Directory.GetParent(Environment.CurrentDirectory)
                .Parent.Parent.FullName + "//playwright-report//" + reportPath);
            htmlReporter.Config.DocumentTitle = reportName;
            htmlReporter.Config.ReportName = "Automation";
            htmlReporter.Config.Encoding = "utf-8";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("tester", "Shalini");
            extent.AddSystemInfo("project", "FiPS");
            extent.AddSystemInfo("org", "DfE");
            extent.AddSystemInfo("build-verson", "1.0.12");

            return extent;
        }

        public static void FlushReport()
        {
            extent?.Flush();
        }
    }
}
