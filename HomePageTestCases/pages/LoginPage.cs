using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_information_products_services_tests.HomePageTestCases.pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        //public async Task NavigateToLoginAsync()
        //{
        //    await _page.GotoAsync("https://www.example.com/login");
        //}

        //public async Task LoginAsync(string username, string password)
        //{
        //    await _page.FillAsync("#username", username);
        //    await _page.FillAsync("#password", password);
        //    await _page.ClickAsync("#login-button");
        //}
    }
}
