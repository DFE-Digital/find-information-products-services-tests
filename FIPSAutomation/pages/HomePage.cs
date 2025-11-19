using Microsoft.Playwright;

namespace find_information_products_services_tests.pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        //public async Task<string?> GetWelcomeMessageAsync()
        //{
        //    return await _page.TextContentAsync("h1");
        //}
    }
}
