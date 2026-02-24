using AventStack.ExtentReports;
using FiPSAutomation.Pages;
using FiPSAutomation.Components;
using Microsoft.Playwright;

namespace FiPSAutomation;

[TestFixture, Order(9)]
[Category("Functional")]
public class CookiesAndFooterTests : BaseTest
{
    private CookiesPage cookiesPage = null!;
    private FooterComponent footer = null!;
    private AccessibilityStatementPage accessibilityPage = null!;
    private HeaderComponent header = null!;
    private HomePage homePage = null!;

    [OneTimeSetUp]
    public void InitPages()
    {
        cookiesPage = new CookiesPage(Page);
        footer = new FooterComponent(Page);
        accessibilityPage = new AccessibilityStatementPage(Page);
        header = new HeaderComponent(Page);
        homePage = new HomePage(Page);
    }

    [Test, Order(41)]
    public async Task VerifyFooterCookiesLinkUS13AC()
    {
        await footer.ClickCookiesLinkAsync();
        await cookiesPage.VerifyCookiePreferencesVisibleAsync();
        await cookiesPage.VerifySaveButtonVisibleAsync();
        await cookiesPage.VerifyCancelLinkVisibleAsync();
        await cookiesPage.VerifyChangeCookiePreferencesLinkAsync();
        await cookiesPage.VerifyBackToHomeLinkAsync();
        ExtentTest?.Log(Status.Pass, "VerifyFooterCookiesLinkUS13AC passed");
    }

    [Test, Order(42)]       
    public async Task VerifyCookiesPageFunctionalitiesUS13AC()
    {
        await NavigateToAsync("cookies");
        await cookiesPage.SelectAnalyticsOffAsync();
        await cookiesPage.SaveCookiePreferencesAsync();
        await cookiesPage.VerifySuccessBannerAsync();
        await cookiesPage.SelectAnalyticsOnAsync();
        await cookiesPage.ClickCancelAsync();
        await homePage.VerifyMainHeadingAsync();
        ExtentTest?.Log(Status.Pass, "VerifyCookiesPageFunctionalitiesUS13AC passed");
    }

    [Test, Order(43)]
    public async Task VerifyCookiesPageBackToHomeFunctionalityUS13AC()
    {
        await NavigateToAsync("cookies");
        await cookiesPage.ClickBackToHomeAsync();
        await homePage.VerifyMainHeadingAsync();
        ExtentTest?.Log(Status.Pass, "VerifyCookiesPageBackToHomeFunctionalityUS13AC passed");
    }

    [Test, Order(44)]
    public async Task VerifyAccessibilityLinkUS16AC()
    {
        await footer.ClickAccessibilityStatementAsync();
        await accessibilityPage.VerifyAccessibilityStatementVisibleAsync();
        await header.ClickServiceNameLinkAsync();
        await homePage.VerifyMainHeadingAsync();
        ExtentTest?.Log(Status.Pass, "VerifyAccessibilityLinkUS16AC passed");
    }
}
