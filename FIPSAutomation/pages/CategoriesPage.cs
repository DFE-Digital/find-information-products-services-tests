using Microsoft.Playwright;

namespace find_information_products_services_tests.pages
{
    public class CategoriesPage
    {
        private readonly IPage _page;

        public CategoriesPage(IPage page)
        {
            _page = page;
        }

        //public async Task NavigateToProductsAsync()
        //{
        //    await _page.GotoAsync("https://find-products-services-test.azurewebsites.net/products");
        //}

        //public async Task<int> GetProductCountAsync()
        //{
        //    return await _page.Locator(".product-item").CountAsync();
        //}
    }
}
