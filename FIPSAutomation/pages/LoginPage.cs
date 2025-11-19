using Microsoft.Playwright;

namespace find_information_products_services_tests.pages
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
        //    await _page.GotoAsync("https://find-products-services-test.azurewebsites.net/login");
        //}

        //public async Task LoginAsync(string username, string password)
        //{
        //    await _page.FillAsync("#username", username);
        //    await _page.FillAsync("#password", password);
        //    await _page.ClickAsync("#login-button");
        //}
    }
}
