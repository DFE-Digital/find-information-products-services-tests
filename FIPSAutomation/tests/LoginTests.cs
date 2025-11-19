//using find_information_products_services_tests.pages;
//using FiPSAutomation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace find_information_products_services_tests.tests
//{
//    public class LoginTests : BaseTest
//    {
//        [Test]
//        public async Task UserCanLoginWithValidCredentials()
//        {
//            await loginPage.NavigateToLoginAsync();
//            await loginPage.LoginAsync("testuser", "password123");
//            var welcomeMessage = await homePage.GetWelcomeMessageAsync();
//            Assert.AreEqual("Welcome, testuser!", welcomeMessage);
//        }
//    }
//}
