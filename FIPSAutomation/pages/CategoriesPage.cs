using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_information_products_services_tests.HomePageTestCases.pages
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
        //    await _page.GotoAsync("https://www.example.com/products");
        //}

        //public async Task<int> GetProductCountAsync()
        //{
        //    return await _page.Locator(".product-item").CountAsync();
        //}
    }
}
