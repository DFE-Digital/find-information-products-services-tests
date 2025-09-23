//using AventStack.ExtentReports;
//using find_information_products_services_tests.HomePageTestCases.constants;
//using FiPSAutomation.HomePageTestCases;
//using Microsoft.Playwright;
//using NUnit.Framework.Interfaces;
////using Microsoft.Playwright.Assertions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Channels;
//using System.Threading.Tasks;

//namespace find_information_products_services_tests.HomePageTestCases
//{
//    internal class CategoriesPageTests : BaseTest
//    {

//        [Test, Order(1), Category("smoke")]
//        public async Task loginWithUsernameAndPassword()
//        {
//            await page.GotoAsync(URLConstant.LOGIN_OAUTH_URL);
//            await page.GetByPlaceholder("Email or phone").ClickAsync();

//            await page.GetByPlaceholder("Email or phone").FillAsync(LoginConstant.USERNAME);

//            await page.GetByRole(AriaRole.Button, new() { NameString = "Next" }).ClickAsync();
//            await page.WaitForURLAsync(URLConstant.LOGIN_SSO_URL);

//            await page.GetByPlaceholder("Password").ClickAsync();

//            await page.GetByPlaceholder("Password").FillAsync(LoginConstant.PASSWORD);

//            await page.GetByRole(AriaRole.Button, new() { NameString = "Sign in" }).ClickAsync();
//            await page.WaitForURLAsync(URLConstant.LOGIN_URL);

//            await page.GetByRole(AriaRole.Button, new() { NameString = "Yes" }).ClickAsync();
//            await page.WaitForURLAsync(URLConstant.FIPS_URL);
//            extentTest?.Log(Status.Pass, "Pressed Enter");
//        }

//        [Test, Order(2), Category("functional")]
//        public async Task ClickBrowseCategoriesAC6()
//        {
//            await page.Locator(FipsLocator.BROWSE_CATEGORY_LOCATOR).ClickAsync();
//            //await Assertions.Expect(page.GetByText("Browse categories")).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
//            extentTest?.Log(Status.Pass, "ClickBrowseCategoriesAC6 passed");
//        }

//        [Test, Order(3), Category("functional")]
//        public async Task CheckPageDescriptionAC2()
//        {
//            await Assertions.Expect(page.GetByText("Find products and services by how they are categorised", new() { Exact = true })).ToBeVisibleAsync();
//            extentTest?.Log(Status.Pass, "CheckPageDescriptionAC2 passed");
//        }

//        [Test, Order(4), Category("functional")]
//        public async Task CheckCategoriesListAndDescriptionAC3()
//        {
//            //verifying Channel link -
//            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Channel"})).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("The delivery channel through which a product or service is provided to users.", new() { Exact = true })).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("9 options", new() { Exact = true })).ToBeVisibleAsync();

//            //verifying Group Link -
//            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Group" })).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("The business area or portfolio responsible for a product or service.", new() { Exact = true })).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("5 main categories", new() { Exact = true })).ToBeVisibleAsync();

//            //verifying Phase Link -
//            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Phase" })).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("The stage a product or service is at in the service delivery lifecycle.", new() { Exact = true })).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("10 options", new() { Exact = true })).ToBeVisibleAsync();

//            //verifying Type Link -
//            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Type" })).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("The type of service delivery and functionality provided.", new() { Exact = true })).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("4 options", new() { Exact = true })).ToBeVisibleAsync();

//            //verifying User group Link -
//            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "User group" })).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("The users of the product or service.", new() { Exact = true })).ToBeVisibleAsync();
//            await Assertions.Expect(page.GetByText("11 main categories", new() { Exact = true })).ToBeVisibleAsync();
//            extentTest?.Log(Status.Pass, "CheckCategoriesListAC3");
//        }

//        [Test, Order(5), Category("functional")]
//        public async Task ClickCategoriesLinksAC4()
//        {
//            await page.GotoAsync(URLConstant.FIPS_URL+"categories/channel");
//            await Assertions.Expect(page.GetByText("The delivery channel through which a product or service is provided to users.", new() { Exact = true })).ToBeVisibleAsync();
//            //await page.Locator("a").Filter(new() { HasTextString = "Channel" }).Nth(1).ClickAsync();
//            ///await page.GetByText("The delivery channel through which a product or service is provided to users.").ClickAsync();
//            //await page.Locator("a[href='/categories/channel']").Nth(1).ClickAsync();
//            ///await Task.Delay(5000);
//            //await page.GetByRole(AriaRole.Link, new() { NameString = "Channel" }).ClickAsync();
//            ///await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Channel" })).ToBeVisibleAsync();
//            //await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync();

//            //await page.GetByRole(AriaRole.Link, new() { NameString = "Group" }).ClickAsync();
//            //await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Group" })).ToBeVisibleAsync();
//            //await page.GoBackAsync();

//            //await page.GetByText("The stage a product or service is at in the service delivery lifecycle.").ClickAsync();
//            //await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Phase" })).ToBeVisibleAsync();
//            //await page.GoBackAsync();

//            //await page.GetByText("4 options").ClickAsync();
//            //await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Type" })).ToBeVisibleAsync();
//            //await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync();

//            //await page.Locator(FipsLocator.USER_GROUP_CHEVRON_LINK).ClickAsync();
//            //await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Type" })).ToBeVisibleAsync();
//            //await page.GetByRole(AriaRole.Link, new() { NameString = "Back to all categories" }).ClickAsync();

//        }
//    }
//}
