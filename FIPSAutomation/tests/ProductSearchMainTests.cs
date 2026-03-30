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

    [Test, Order(1)]
    public async Task VerifyMainProductPageView_HeaderAndListUS103AC()
    {
        await Page.GetByRole(AriaRole.Link, new() { NameString = "Products" }).ClickAsync();
        await productsSearchPage.VerifyProductsPageHeadingAsync();
        await productsSearchPage.VerifyFilterOptionsBlockAsync();
        await productsSearchPage.FilterPanel.VerifyBusinessAreaVisibleAsync();
        await productsSearchPage.FilterPanel.VerifyChannelVisibleAsync();
        await productsSearchPage.FilterPanel.VerifyPhaseVisibleAsync();
        await productsSearchPage.FilterPanel.VerifyTypeVisibleAsync();
        await productsSearchPage.VerifyProductsListHeadingAsync();
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        ExtentTest?.Log(Status.Pass, "VerifyMainProductPageHeaderAndListUS103AC passed");
    }

    [Test, Order(2)]
    public async Task VerifySearchBoxFunctionality_UsingAcronymUS285AC1()
    {
        await productsSearchPage.SearchByKeywordAsync("GIAS");
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyAppliedFiltersPanelContainsAsync("your selected filters");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Search_FilterHeading, "Search term");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.GiasAcronym_FilterTag, "GIAS × Remove GIAS filter");
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.ClearAllFiltersAsync();

        ExtentTest?.Log(Status.Pass, "VerifySearchBoxFunctionality_UsingAcronymUS285AC1 passed");
    }

    [Test, Order(3)]
    public async Task VerifySearchBoxFunctionality_UsingAcronymUS285AC2()
    {
        await productsSearchPage.SearchByKeywordAsync("FIPS");
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyAppliedFiltersPanelContainsAsync("your selected filters");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Search_FilterHeading, "Search term");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.FipsAcronym_FilterTag, "FIPS × Remove FIPS filter");
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.ClearAllFiltersAsync();

        ExtentTest?.Log(Status.Pass, "VerifySearchBoxFunctionality_UsingAcronymUS285AC2 passed");
    }

    [Test, Order(4)]
    public async Task VerifySearchBoxFunctionality_UsingUserGroupTermUS285AC3()
    {
        await productsSearchPage.SearchByKeywordAsync("Early years workforce");
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyAppliedFiltersPanelContainsAsync("your selected filters");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Search_FilterHeading, "Search term");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.UGTermEYW_FilterTag, "Early years workforce × Remove Early years workforce filter");
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.ClearAllFiltersAsync();

        ExtentTest?.Log(Status.Pass, "VerifySearchBoxFunctionality_UsingUserGroupTermUS285AC3 passed");
    }

    [Test, Order(5)]
    public async Task VerifySearchBoxFunctionality_UsingUserGroupTermUS285AC4()
    {
        await productsSearchPage.SearchByKeywordAsync("Child or young person");
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyAppliedFiltersPanelContainsAsync("your selected filters");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Search_FilterHeading, "Search term");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.UGTermCYP_FilterTag, "Child or young person × Remove Child or young person filter");
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.ClearAllFiltersAsync();

        ExtentTest?.Log(Status.Pass, "VerifySearchBoxFunctionality_UsingUserGroupTermUS285AC4 passed");
    }

    [Test, Order(6)]
    public async Task VerifySearchBoxFunctionality_UsingNonPreferredTermsUS285AC5()
    {
        await productsSearchPage.SearchByKeywordAsync("DfE staff");
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyAppliedFiltersPanelContainsAsync("your selected filters");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Search_FilterHeading, "Search term");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.NonPreferTermDfEStaff_FilterTag, "DfE staff × Remove DfE staff filter");
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.ClearAllFiltersAsync();

        ExtentTest?.Log(Status.Pass, "VerifySearchBoxFunctionality_UsingNonPreferredTermsUS285AC5 passed");
    }

    [Test, Order(7)]
    public async Task VerifySearchBoxFunctionality_UsingNonPreferredTermsUS285AC6()
    {
        await productsSearchPage.SearchByKeywordAsync("HE workforce");
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyAppliedFiltersPanelContainsAsync("your selected filters");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Search_FilterHeading, "Search term");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.NonPreferTermHEWorkforce_FilterTag, "HE workforce × Remove HE workforce filter");
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.ClearAllFiltersAsync();

        ExtentTest?.Log(Status.Pass, "VerifySearchBoxFunctionality_UsingNonPreferredTermsUS285AC6 passed");
    }

    [Test, Order(8)]
    public async Task VerifySearchBoxFunctionality_CombinedWithCategoryFilterUS285AC7()
    {
        await productsSearchPage.SearchByKeywordAsync("CRM");
        await productsSearchPage.FilterPanel.OpenChannelAsync();
        await productsSearchPage.FilterPanel.CheckFilterAsync(productsSearchPage.FilterPanel.Channel_Web);
        await productsSearchPage.FilterPanel.ApplyFiltersAsync();
        await productsSearchPage.FilterTags.VerifyAppliedFiltersPanelContainsAsync("your selected filters");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Search_FilterHeading, "Search term");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.CrmAcronym_FilterTag, "CRM × Remove CRM filter");
        await productsSearchPage.FilterTags.VerifyFilterHeadingAsync(productsSearchPage.FilterTags.Channel_FilterHeading, "Channel");
        await productsSearchPage.FilterTags.VerifyFilterTagAsync(productsSearchPage.FilterTags.Channel_Web, "Web × Remove Web filter");
        await productsSearchPage.VerifyMissingProductSectionVisibleAsync();
        await productsSearchPage.VerifyProductListVisibleAsync();
        await productsSearchPage.FilterPanel.ClearAllFiltersAsync();

        ExtentTest?.Log(Status.Pass, "VerifySearchBoxFunctionality_CombinedWithCategoryFilterUS285AC7 passed");
    }


}
