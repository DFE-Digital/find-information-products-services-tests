using Microsoft.Playwright;

namespace FiPSAutomation.Pages
{
    public class HomePage
    {
        private readonly IPage page;

        private ILocator SearchButton => page.Locator("[class=\"govuk-button govuk-button--start govuk-button--inverse home-cta-link\"]");
        private ILocator HomeTiles => page.Locator("(//div[@class='govuk-grid-column-full'])[1]");
        private ILocator AboutServiceLocator => page.Locator("//*[@id=\"main-content\"]/div/div/div/div[2]/a[2]");
        private ILocator AllProductsLocator => page.Locator("//h2[text() = 'All products and services']");
        private ILocator BrowseCategoryLocator => page.Locator("//h2[text() = 'Browse categories']");
        private ILocator KeepInfoUpdateLocator => page.Locator("//h2[text() = 'Keep information updated']");

        public HomePage(IPage page)
        {
            this.page = page;
        }

        public async Task VerifyPageTitleAsync()
        {
            await Assertions.Expect(page).ToHaveTitleAsync("Find information about products and services - FIPS");
        }

        public async Task VerifyMainHeadingAsync()
        {
            await Assertions.Expect(
                page.GetByRole(AriaRole.Heading, new() { NameString = "Find information about products and services" })
            ).ToBeVisibleAsync();
        }

        public async Task VerifyServiceDescriptionAsync()
        {
            await Assertions.Expect(
                page.GetByText("Use this service to explore what DfE delivers. Build on existing work, avoid duplication, and work more effectively across teams.")
            ).ToBeVisibleAsync();
        }

        public async Task VerifySearchButtonTextAsync()
        {
            await Assertions.Expect(SearchButton).ToHaveTextAsync(" Search products and services ");
        }

        public async Task ClickSearchButtonAsync()
        {
            await SearchButton.ClickAsync();
        }

        public async Task VerifyTilesVisibleAsync()
        {
            await Assertions.Expect(HomeTiles).ToBeVisibleAsync();
        }

        public async Task VerifyTileHeadingsAsync()
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "All products and services" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Keep information updated" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "About this service" })).ToBeVisibleAsync();
        }

        public async Task VerifyTileDescriptionsAsync()
        {
            await Assertions.Expect(page.GetByText("Search and filter the products and services.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Find products and services by how they are categorised", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("How to update information about products listed in this service.", new() { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Find out what this service is and how it works.", new() { Exact = true })).ToBeVisibleAsync();
        }

        public async Task ClickAllProductsAndServicesAsync()
        {
            await AllProductsLocator.ClickAsync();
        }

        public async Task ClickBrowseCategoriesAsync()
        {
            await BrowseCategoryLocator.ClickAsync();
        }

        public async Task ClickAboutThisServiceAsync()
        {
            await AboutServiceLocator.ClickAsync();
        }

        public async Task ClickKeepInfoUpdatedAsync()
        {
            await KeepInfoUpdateLocator.ClickAsync();
        }
    }
}
