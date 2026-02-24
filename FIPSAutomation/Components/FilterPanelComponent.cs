using Microsoft.Playwright;

namespace FiPSAutomation.Components
{
    public class FilterPanelComponent
    {
        private readonly IPage page;

        // Category accordion buttons
        private ILocator BusinessAreaButton => page.Locator("//button[@data-target=\"group-filter\"]");
        private ILocator ChannelButton => page.Locator("//button[@data-target=\"channel-filter\"]");
        private ILocator PhaseButton => page.Locator("//button[@data-target=\"phase-filter\"]");
        private ILocator TypeButton => page.Locator("//button[@data-target=\"type-filter\"]");

        // Business Area checkboxes
        public string BA_Commercial => "label[for='group-commercial']";
        public string BA_CustomerExpAndDesign => "label[for='group-customer-experience-and-design']";
        public string BA_ChildrenAndFamilies => "label[for='group-children-and-families']";
        public string BA_EnterpriseData => "label[for='group-enterprise-data']";
        public string BA_FundingAndFinancialOversight => "label[for='group-funding-and-financial-oversight']";
        public string BA_OperationsAndInfra => "label[for='group-operations-and-infrastructure']";
        public string BA_RegionalDigitalServices => "label[for='group-regional-digital-services']";
        public string BA_SchoolsDigital => "label[for='group-schools-digital']";
        public string BA_SectorFacingServices => "label[for='group-sector-facing-services']";
        public string BA_SkillsAndGrowth => "label[for='group-skills-and-growth']";
        public string BA_Strategy => "label[for='group-strategy']";
        public string BA_NotCategorised => "label[for='group-not-categorised']";

        // Channel checkboxes
        public string Channel_Chat => "label[for='channel-chat']";
        public string Channel_Email => "label[for='channel-email']";
        public string Channel_FaceToFace => "label[for='channel-face-to-face']";
        public string Channel_NativeApp => "label[for='channel-native-app']";
        public string Channel_OtherDigitalMedia => "label[for='channel-other-digital-media']";
        public string Channel_Phone => "label[for='channel-phone']";
        public string Channel_PrintMedia => "label[for='channel-print-media']";
        public string Channel_SMS => "label[for='channel-sms']";
        public string Channel_Web => "label[for='channel-web']";
        public string Channel_NotCategorised => "label[for='channel-not-categorised']";

        // Phase checkboxes
        public string Phase_Discovery => "label[for='phase-discovery']";
        public string Phase_Alpha => "label[for='phase-alpha']";
        public string Phase_DidNotProgress => "label[for='phase-did-not-progress']";
        public string Phase_PrivateBeta => "label[for='phase-private-beta']";
        public string Phase_PublicBeta => "label[for='phase-public-beta']";
        public string Phase_Live => "label[for='phase-live']";
        public string Phase_Decommissioning => "label[for= 'phase-decommissioning']";
        public string Phase_Decommissioned => "label[for='phase-decommissioned']";
        public string Phase_NotCategorised => "label[for='phase-not-categorised']";

        // Type checkboxes
        public string Type_API => "label[for='type-api']";
        public string Type_Campaign => "label[for='type-campaign']";
        public string Type_Data => "label[for='type-data']";
        public string Type_Information => "label[for='type-information']";
        public string Type_Transactional => "label[for='type-transactional']";
        public string Type_NotCategorised => "label[for='type-not-categorised']";

        // User groups
        private ILocator UserGroupsListbox => page.Locator("#user-autocomplete");
        private ILocator UserGroupsOption1 => page.Locator("#user-autocomplete__option--1");
        private ILocator UserGroupsOption2 => page.Locator("#user-autocomplete__option--3");
        private ILocator UserGroupsOption3 => page.Locator("#user-autocomplete__option--2");
        private ILocator KeywordSearchTextbox => page.Locator("#keywords");
        private ILocator SelectedUserTypesCheckbox => page.Locator("#user-0");

        public FilterPanelComponent(IPage page)
        {
            this.page = page;
        }

        public async Task OpenBusinessAreaAsync()
        {
            await BusinessAreaButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await BusinessAreaButton.ClickAsync();
        }

        public async Task OpenChannelAsync()
        {
            await ChannelButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await ChannelButton.ClickAsync();
        }

        public async Task OpenPhaseAsync()
        {
            await PhaseButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await PhaseButton.ClickAsync();
        }

        public async Task OpenTypeAsync()
        {
            await TypeButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await TypeButton.ClickAsync();
        }

        public async Task CheckFilterAsync(string checkboxLocator)
        {
            await page.Locator(checkboxLocator).CheckAsync();
        }

        public async Task ApplyFiltersAsync()
        {
            await page.GetByRole(AriaRole.Button, new() { NameString = "Apply filters" }).ClickAsync();
        }

        public async Task ClearFiltersAsync()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear filters" }).ClickAsync();
        }

        public async Task ClearAllFiltersAsync()
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = "Clear all filters" }).ClickAsync();
        }

        public async Task SearchByKeywordAsync(string keyword)
        {
            await KeywordSearchTextbox.FillAsync(keyword);
        }

        public async Task ClearKeywordSearchAsync()
        {
            await KeywordSearchTextbox.FillAsync(string.Empty);
        }

        public async Task SearchUserGroupAsync(string text)
        {
            await UserGroupsListbox.FillAsync(text);
        }

        public async Task SelectUserGroupOption1Async()
        {
            await UserGroupsOption1.ClickAsync();
        }

        public async Task SelectUserGroupOption2Async()
        {
            await UserGroupsOption2.ClickAsync();
        }

        public async Task SelectUserGroupOption3Async()
        {
            await UserGroupsOption3.ClickAsync();
        }

        public async Task ClickUserGroupsListboxAsync()
        {
            await UserGroupsListbox.ClickAsync();
        }

        public async Task VerifyBusinessAreaVisibleAsync()
        {
            await Assertions.Expect(BusinessAreaButton).ToBeVisibleAsync();
        }

        public async Task VerifyChannelVisibleAsync()
        {
            await Assertions.Expect(ChannelButton).ToBeVisibleAsync();
        }

        public async Task VerifyPhaseVisibleAsync()
        {
            await Assertions.Expect(PhaseButton).ToBeVisibleAsync();
        }

        public async Task VerifyTypeVisibleAsync()
        {
            await Assertions.Expect(TypeButton).ToBeVisibleAsync();
        }
    }
}
