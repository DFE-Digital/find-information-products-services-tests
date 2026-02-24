using AventStack.ExtentReports;
using FiPSAutomation.Pages;
using FiPSAutomation.Components;
using Microsoft.Playwright;

namespace FiPSAutomation;

[TestFixture, Order(11)]
[Category("Functional")]
public class ProductSearchMainTests : BaseTest
{
    private ProductsSearchPage productsSearchPage = null!;

    [OneTimeSetUp]
    public void InitPages()
    {
        productsSearchPage = new ProductsSearchPage(Page);
    }

    [Test, Order(47)]
    public async Task VerifyMainProductPageHeaderAndListUS103AC()
    {
        await Page.GetByRole(AriaRole.Link, new() { NameString = "Products" }).ClickAsync();
        await productsSearchPage.VerifySearchHeadingAsync();
        await productsSearchPage.FilterTags.VerifyShowingResultsAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        ExtentTest?.Log(Status.Pass, "VerifyMainProductPageHeaderAndListUS103AC passed");
    }

    [Test, Order(48)]
    public async Task VerifyUserGroupsSearchFunctionalityUS103AC()
    {
        await productsSearchPage.FilterPanel.SearchUserGroupAsync("Ac");
        await productsSearchPage.FilterPanel.SelectUserGroupOption1Async();
        await Assertions.Expect(Page.GetByLabel("Academy and trust workforce  (Education provider and early years workforce)")).ToBeCheckedAsync();
        await productsSearchPage.FilterPanel.ClickUserGroupsListboxAsync();
        await Task.Delay(1000);
        await productsSearchPage.FilterPanel.SearchUserGroupAsync("Ac");
        await Task.Delay(1000);
        await productsSearchPage.FilterPanel.SelectUserGroupOption2Async();
        await Assertions.Expect(Page.GetByLabel("Academy headteacher (secondary)  (Academy and trust workforce)")).ToBeCheckedAsync();
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyShowingResultsAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.SearchUserGroupAsync("DFE");
        await productsSearchPage.FilterPanel.SelectUserGroupOption3Async();
        await Assertions.Expect(Page.GetByLabel("Colleague supporting DfE users  (Department for Education workforce)")).ToBeCheckedAsync();
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyShowingResultsAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await Task.Delay(1000);
        await productsSearchPage.FilterPanel.ClearFiltersAsync();
        ExtentTest?.Log(Status.Pass, "VerifyUserGroupsSearchFunctionalityUS103AC passed");
    }

    [Test, Order(49)]
    public async Task VerifyProductNameSearchboxFunctionalityUS103AC()
    {
        await productsSearchPage.FilterPanel.SearchByKeywordAsync("app");
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyShowingResultsAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await Task.Delay(1000);
        await productsSearchPage.FilterPanel.ClearKeywordSearchAsync();
        ExtentTest?.Log(Status.Pass, "VerifyProductNameSearchboxFunctionalityUS103AC passed");
    }
}
