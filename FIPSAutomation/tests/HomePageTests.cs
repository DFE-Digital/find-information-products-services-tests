using AventStack.ExtentReports;
using FiPSAutomation.Pages;
using FiPSAutomation.Components;
using Microsoft.Playwright;

namespace FiPSAutomation;

[TestFixture, Order(1)]
[Category("Functional")]
public class HomePageTests : BaseTest
{
    private HomePage homePage = null!;
    private KeepInfoUpdatedPage keepInfoUpdatedPage = null!;
    private HeaderComponent header = null!;

    [OneTimeSetUp]
    public void InitPages()
    {
        homePage = new HomePage(Page);
        keepInfoUpdatedPage = new KeepInfoUpdatedPage(Page);
        header = new HeaderComponent(Page);
    }

    [Test, Order(1)]
    [Description("Login using username/password")]
    public async Task LoginWithUsernameAndPasswordUS231AC2()
    {
        // Login handled by GlobalSetup
        ExtentTest?.Log(Status.Pass, "LoginWithUsernameAndPasswordUS231AC2 passed");
    }

    [Test, Order(2), Category("functional")]
    public async Task HomePageVerificationUS12AC1()
    {
        await homePage.VerifyPageTitleAsync();
        await homePage.VerifyMainHeadingAsync();
        await homePage.VerifyServiceDescriptionAsync();
        await homePage.VerifySearchButtonTextAsync();
        ExtentTest?.Log(Status.Pass, "HomePageVerificationUS12AC1 assertion passed");
    }

    [Test, Order(3), Category("functional")]
    public async Task ClickSearchButtonUS12AC2()
    {
        await homePage.ClickSearchButtonAsync();
        await Assertions.Expect(Page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
        await Page.GoBackAsync();
        ExtentTest?.Log(Status.Pass, "ClickSearchButtonUS12AC2 passed");
    }

    [Test, Order(4), Category("functional")]
    public async Task VerifyTilesAreVisibleUS12AC4()
    {
        await homePage.VerifyTilesVisibleAsync();
        await homePage.VerifyTileHeadingsAsync();
        await homePage.VerifyTileDescriptionsAsync();
        ExtentTest?.Log(Status.Pass, "VerifyTilesAreVisibleUS12AC4 passed");
    }

    [Test, Order(5), Category("functional")]
    public async Task ClickAllProductsAndServicesUS12AC5()
    {
        await homePage.ClickAllProductsAndServicesAsync();
        await Assertions.Expect(Page.GetByText("Search and filter products and services")).ToBeVisibleAsync();
        await Page.GoBackAsync();
        ExtentTest?.Log(Status.Pass, "ClickAllProductsAndServicesUS12AC5 passed");
    }

    [Test, Order(6), Category("functional")]
    public async Task ClickBrowseCategoriesUS12AC6()
    {
        await homePage.ClickBrowseCategoriesAsync();
        await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "Browse categories" })).ToBeVisibleAsync();
        await Page.GoBackAsync();
        ExtentTest?.Log(Status.Pass, "ClickBrowseCategoriesUS12AC6 passed");
    }

    [Test, Order(7), Category("functional")]
    public async Task ClickAboutThisServiceTileUS12AC()
    {
        await homePage.ClickAboutThisServiceAsync();
        await Assertions.Expect(Page.GetByText("About this service", new() { Exact = true })).ToBeVisibleAsync();
        await Page.GoBackAsync();
        ExtentTest?.Log(Status.Pass, "ClickAboutThisServiceTileUS12AC passed");
    }

    [Test, Order(8), Category("functional")]
    public async Task ClickKeepInformationUpdatedTileUS12AC8()
    {
        await homePage.ClickKeepInfoUpdatedAsync();
        await keepInfoUpdatedPage.VerifyHeadingAsync();
        await keepInfoUpdatedPage.ClickSearchLinkAsync();
        await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "Search and filter products and services" })).ToBeVisibleAsync();
        await Page.GoBackAsync();
        await keepInfoUpdatedPage.ClickRequestNewProductEntryLinkAsync();
        await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "Request a new product entry" })).ToBeVisibleAsync();
        await Page.GoBackAsync();
        await keepInfoUpdatedPage.ClickAboutThisServiceLinkAsync();
        await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "About this service" })).ToBeVisibleAsync();
        await Page.GoBackAsync();
        await keepInfoUpdatedPage.ClickContactUsLinkAsync();
        await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "Contact us" })).ToBeVisibleAsync();
        await Assertions.Expect(Page.Locator("//*[@id=\"main-content\"]/div/div/div[1]/div/p[1]")).ToBeVisibleAsync();
        await Page.GoBackAsync();
        await header.ClickServiceNameLinkAsync();
        await homePage.VerifyMainHeadingAsync();
        ExtentTest?.Log(Status.Pass, "ClickKeepInformationUpdatedTileUS12AC8 passed");
    }
}
