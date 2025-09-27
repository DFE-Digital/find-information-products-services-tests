using System;

namespace find_information_products_services_tests.HomePageTestCases.constants
{
    internal class FipsLocator
    {
        public static readonly string HOME_SEARCH_LOCATOR = "[class=\"govuk-button govuk-button--start govuk-button--inverse home-cta-link\"]";
        public static readonly string ABOUT_SERVICE_LOCATOR = "//*[contains(text(),'About this service')]";
        public static readonly string ALL_PRODUCT_LOCATOR = "//h2[text() = 'All products and services']";
        public static readonly string BROWSE_CATEGORY_LOCATOR = "//h2[text() = 'Browse categories']";
        public static readonly string USE_DATA_LOCATOR = "//h2[text() = 'Use the data']";
        public static readonly string KEEPING_INFO_UPDATE_LOCATOR = "//h2[text() = 'Keeping information updated']";
        public static readonly string USER_GROUP_CHEVRON_LINK = ".dfe-chevron-card__link.category-link[href='/categories/user-group']";
        public static readonly string CATEGORY_CHANNEL_LINK = "a[href='/categories/channel']";

       // public static readonly string PHASE_REQUEST_LINK = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/h2/a";
        public static readonly string PHASE_REQUEST_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
        public static readonly string PHASE_EXPLORE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
        public static readonly string PHASE_TRIAGE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
        public static readonly string PHASE_DISCOVERY_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[4]/div/p";
        public static readonly string PHASE_ALPHA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[5]/div/p";
        public static readonly string PHASE_PRIVATEBETA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[6]/div/p";
        public static readonly string PHASE_PUBLICBETA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[7]/div/p";
        public static readonly string PHASE_LIVE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[8]/div/p";
        public static readonly string PHASE_DECOMMISSIONING_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[9]/div/p";
        public static readonly string PHASE_DECOMMISSIONED_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[10]/div/p";

        public static readonly string PHASE_FILTER_REQUEST_TAG = "ul.moj-filter-tags li a:has-text('Request')";
        public static readonly string PHASE_FILTER_EXPLORE_TAG = "ul.moj-filter-tags li a:has-text('Explore')";

        public static readonly string PHASE_FILTER_TEXT = "//h3[normalize-space()='Phase']";
        public static readonly string SHOWING_PRODUCTS_MESSAGE = "div[class='govuk-!-margin-bottom-4'] p[class='govuk-body']";
        public static readonly string REQUEST_CHECKBOX = "#phase-request";
        public static readonly string EXPLORE_CHECKBOX = "#phase-explore";
        public static readonly string TRIAGE_CHECKBOX = "";
        public static readonly string DISCOVERY_CHECKBOX = "";
        public static readonly string ALPHA_CHECKBOX = "";
        public static readonly string PRIVATE_BETA_CHECKBOX = "";
        public static readonly string PUBLIC_BETA_CHECKBOX = "";
        public static readonly string LIVE_CHECKBOX = "";
        public static readonly string DECOMMISSIONING_CHECKBOX = "";
        public static readonly string DECOMMISSIONED_CHECKBOX = "";
    }
}
