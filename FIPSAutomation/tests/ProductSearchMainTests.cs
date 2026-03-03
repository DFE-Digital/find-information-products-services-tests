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
        await productsSearchPage.VerifyProductsPageHeadingAsync();
        await productsSearchPage.VerifyProductsListHeadingAsync();
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.FilterTags.VerifyShowingResultsAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        ExtentTest?.Log(Status.Pass, "VerifyMainProductPageHeaderAndListUS103AC passed");
    }

    [Test, Order(48)]
    public async Task VerifySearchBoxFunctionality_UsingAcronymUS285AC1()
    {
        await productsSearchPage.SearchByKeywordAsync("GIAS");
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyAppliedFiltersPanelContainsAsync("your selected filters");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Search_FilterHeading, "Search term");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.GiasAcronym_FilterTag, "GIAS × Remove GIAS filter");
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.FilterTags.VerifyShowingResultsAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.ClearAllFiltersAsync();

        ExtentTest?.Log(Status.Pass, "VerifySearchBoxFunctionality_UsingAcronymUS285AC1 passed");
    }

    [Test, Order(49)]
    public async Task VerifySearchBoxFunctionality_UsingAcronymUS285AC2()
    {
        await productsSearchPage.SearchByKeywordAsync("FIPS");
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyAppliedFiltersPanelContainsAsync("your selected filters");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Search_FilterHeading, "Search term");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.GiasAcronym_FilterTag, "FIPS × Remove FIPS filter");
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.FilterTags.VerifyShowingResultsAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.ClearAllFiltersAsync();

        ExtentTest?.Log(Status.Pass, "VerifySearchBoxFunctionality_UsingAcronymUS285AC2 passed");
    }
}
