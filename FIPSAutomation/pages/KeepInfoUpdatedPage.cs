using Microsoft.Playwright;

namespace FiPSAutomation.Pages
{
    public class KeepInfoUpdatedPage
    {
        private readonly IPage page;

        public string ServiceEmailDesc => "//*[@id='main-content']/div/div/div[1]/div/p[1]";
        public string EmailLink => "a[href='mailto:fips.service@education.gov.uk']";

        public KeepInfoUpdatedPage(IPage page)
        {
            this.page = page;
        }

        public async Task VerifyHeadingAsync()
        {
            await Assertions.Expect(
                page.GetByRole(AriaRole.Heading, new() { NameString = "Keep information updated" })).ToBeVisibleAsync();
        }

        public async Task ClickSearchLinkAsync()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Search" }).ClickAsync();
        }

        public async Task ClickRequestNewProductEntryLinkAsync()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "request a new product entry" }).ClickAsync();
        }

        public async Task ClickAboutThisServiceLinkAsync()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "About this service" }).ClickAsync();
        }

        public async Task ClickContactUsLinkAsync()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Contact us" }).ClickAsync();
        }

        //public async Task VerifyServiceEmailAsync()
        //{
        //    await Assertions.Expect(ServiceEmailDesc).ToBeVisibleAsync();
        //    await 
        //}
    }
}
