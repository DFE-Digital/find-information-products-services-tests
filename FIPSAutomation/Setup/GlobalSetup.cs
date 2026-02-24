using AventStack.ExtentReports;
using find_information_products_services_tests.FIPSAutomation.login;
using FiPSAutomation.utilities;
using Microsoft.Playwright;
using System.Text.Json;

namespace FiPSAutomation
{
    [SetUpFixture]
    public class GlobalSetup
    {
        public static IPlaywright? Playwright { get; private set; }
        public static IBrowser? Browser { get; private set; }
        public static IBrowserContext? Context { get; private set; }
        public static IPage? Page { get; private set; }
        public static LoginConfig? LoginConfig { get; private set; }
        public static EnvironmentDetail? ActiveEnvironment { get; private set; }

        [OneTimeSetUp]
        public async Task RunBeforeAnyTests()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true, //false,
                Args = new List<string> { "--start-maximized" },
            });

            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });

            Page = await Context.NewPageAsync();

            ExtentReportHelper.GetInstance();

            await LoginAndAcceptCookiesAsync();
        }

        [OneTimeTearDown]
        public async Task RunAfterAllTests()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }
            Playwright?.Dispose();
            ExtentReportHelper.FlushReport();
        }

        private async Task LoginAndAcceptCookiesAsync()
        {
            using FileStream stream = File.OpenRead(
                Directory.GetParent(Environment.CurrentDirectory)!
                    .Parent!.Parent!.FullName + "//FIPS.env.json");

            LoginConfig = await JsonSerializer.DeserializeAsync<LoginConfig>(stream);

            if (LoginConfig != null)
            {
                ActiveEnvironment = LoginConfig.Envs.FirstOrDefault(e => e.Env == LoginConfig.ActiveEnv);
            }

            if (!LoginConfig!.LoginRequired)
            {
                await Page!.GotoAsync(ActiveEnvironment!.ApplicationURL);
            }
            else
            {
                //await Page!.GotoAsync(ActiveEnvironment!.ApplicationURL);
                await Page!.GotoAsync(ActiveEnvironment!.OAuthURL); // TODO
                try
                {
                    await Page.GetByPlaceholder("Email or phone").ClickAsync();
                    await Page.GetByPlaceholder("Email or phone").FillAsync(StringUtility.Base64Decode(LoginConfig.UserName));
                    await Page.GetByRole(AriaRole.Button, new() { NameString = "Next" }).ClickAsync();
                    await Page.GetByPlaceholder("Password").ClickAsync();
                    await Page.GetByPlaceholder("Password").FillAsync(StringUtility.Base64Decode(LoginConfig.Password));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while login :- " + ex.StackTrace);
                    return;
                }
                await Page.GetByRole(AriaRole.Button, new() { NameString = "Sign in" }).ClickAsync();
                await Page.WaitForURLAsync(LoginConfig.LoginURL); // TODO
                await Page.GetByRole(AriaRole.Button, new() { NameString = "Yes" }).ClickAsync();
                await Page.WaitForURLAsync(ActiveEnvironment.ApplicationURL); // TODO
            }

            await Page.GetByRole(AriaRole.Button, new() { NameString = "Accept analytics cookies" }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Hide cookie message" }).ClickAsync();
        }
    }
}
