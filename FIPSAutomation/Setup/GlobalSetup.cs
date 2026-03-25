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
            //Initializes Playwright and starts a Chromium browser in headless mode -

            Playwright = await Microsoft.Playwright.Playwright.CreateAsync(); 
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true, //false,
                Args = new List<string> { "--start-maximized" },
            });
            //Configures the browser context and opens a new page -
            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport //Sets viewport size for consistent UI testing.
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
                await Browser.CloseAsync(); //Closes the browser and releases Playwright resources
            }
            Playwright?.Dispose();
            ExtentReportHelper.FlushReport(); //Finalizes and flushes reports
        }

        private async Task LoginAndAcceptCookiesAsync()
        {
            using FileStream stream = File.OpenRead(
                Directory.GetParent(Environment.CurrentDirectory)!
                    .Parent!.Parent!.FullName + "//FIPS.env.json");

            LoginConfig = await JsonSerializer.DeserializeAsync<LoginConfig>(stream); //Reads the environment config from FIPS.env.json

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
                    //byte[] usernameBytes = Convert.FromBase64String(Environment.GetEnvironmentVariable("USERNAME"));
                    //string username = Encoding.UTF8.GetString(usernameBytes);
                    ////Console.WriteLine("XXXXXXXXXXXXX: decodedString:"+ username);
                    ////extentTest?.Log(Status.Pass, "decodedString:" + username);
                    //await page.GetByPlaceholder("Email or phone").FillAsync(username);

                    await Page.GetByPlaceholder("Email or phone").FillAsync(StringUtility.Base64Decode(LoginConfig.UserName));
                    await Page.GetByRole(AriaRole.Button, new() { NameString = "Next" }).ClickAsync();

                    await Page.GetByPlaceholder("Password").ClickAsync();
                    //byte[] passwordBytes = Convert.FromBase64String(Environment.GetEnvironmentVariable("PASSWORD"));
                    //string password = Encoding.UTF8.GetString(passwordBytes);
                    //await page.GetByPlaceholder("Password").FillAsync(password);
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
