using System;

namespace find_information_products_services_tests.HomePageTestCases.constants
{
    internal class FipsLocator
    {
        public static readonly string HOME_SEARCH_LOCATOR = "[class=\"govuk-button govuk-button--start govuk-button--inverse home-cta-link\"]";
        public static readonly string ABOUT_SERVICE_LOCATOR = "//*[@id=\"main-content\"]/div/div/div/div[2]/a[2]";
        public static readonly string ALL_PRODUCT_LOCATOR = "//h2[text() = 'All products and services']";
        public static readonly string BROWSE_CATEGORY_LOCATOR = "//h2[text() = 'Browse categories']";
        public static readonly string USE_DATA_LOCATOR = "//h2[text() = 'Use the data']";
        public static readonly string KEEP_INFO_UPDATE_LOCATOR = "//h2[text() = 'Keep information updated']";
        public static readonly string USER_GROUP_CHEVRON_LINK = ".dfe-chevron-card__link.category-link[href='/categories/user-group']";
        public static readonly string CATEGORY_CHANNEL_LINK = "a[href='/categories/channel']";

       // public static readonly string PHASE_REQUEST_LINK = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/h2/a";
       // public static readonly string PHASE_REQUEST_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
       // public static readonly string PHASE_EXPLORE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
      //  public static readonly string PHASE_TRIAGE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
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
        public static readonly string SHOWING_PRODUCTS_MESSAGE = "//p[@class =\"govuk-body\" and contains(text(), \"products and services\")]";
        public static readonly string REQUEST_CHECKBOX = "#phase-request";
        public static readonly string EXPLORE_CHECKBOX = "#phase-explore";
        public static readonly string CHANNEL_CHAT_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
        public static readonly string CHANNEL_EMAIL_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
        public static readonly string CHANNEL_FACETOFACE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
        public static readonly string CHANNEL_NATIVEAPP_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[4]/div/p";
        public static readonly string CHANNEL_OTHERDIGITALMEDIA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[5]/div/p";
        public static readonly string CHANNEL_PHONE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[6]/div/p";
        public static readonly string CHANNEL_PRINTMEDIA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[7]/div/p";
        public static readonly string CHANNEL_SMS_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[8]/div/p";
        public static readonly string CHANNEL_WEB_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[9]/div/p";

        public static readonly string GROUP_FAMILIES_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
        public static readonly string GROUP_REGIONS_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
        public static readonly string GROUP_SCHOOLS_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
        public static readonly string GROUP_SKILLS_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[4]/div/p";
        public static readonly string GROUP_OPERATIONSANDINFRA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[5]/div/p";
        public static readonly string GROUP_STRATEGY_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[6]/div/p";

        public static readonly string OPERATIONSANDINFRA_HEADING_DESC = "//*[@id=\"main-content\"]/div/div/div/h1";
        public static readonly string OPERATIONSANDINFRA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul[1]/li/div/p";
        public static readonly string OPERATIONSANDINFRA_CXD_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul[2]/li[1]/div/p";
        public static readonly string OPERATIONSANDINFRA_ENTERPRISEDATA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul[2]/li[2]/div/p";
        public static readonly string OPERATIONSANDINFRA_FUNDING_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul[2]/li[3]/div/p";
        public static readonly string OPERATIONSANDINFRA_SUBCATEGORIES_HEAD_LINK = "//*[@id=\"main-content\"]/div/div/div/h2";
        public static readonly string OPERATIONSANDINFRA_SUBCATEGORIES_HEAD_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/p[2]";

        public static readonly string TYPE_API_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
        public static readonly string TYPE_CAMPAIGN_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
        public static readonly string TYPE_INFORMATION_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
        public static readonly string TYPE_TRANSACTIONAL_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[4]/div/p";

        public static readonly string USERGROUP_ADULTLEARNER_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
        public static readonly string USERGROUP_CAREERSADVISER_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
        public static readonly string USERGROUP_CHILDORYOUNGPERSON_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
        public static readonly string USERGROUP_DFEWORKFORCE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[4]/div/p";
        public static readonly string USERGROUP_EPANDEYWORKFORCE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[5]/div/p";
        public static readonly string USERGROUP_EMPLOYER_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[6]/div/p";
        public static readonly string USERGROUP_LAWORKFORCE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[7]/div/p";
        public static readonly string USERGROUP_NEETORCS_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[8]/div/p";
        public static readonly string USERGROUP_PARENTORCARER_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[9]/div/p";
        public static readonly string USERGROUP_PROFEXTERUSERDFE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[10]/div/p";
        public static readonly string USERGROUP_SCWORKFORCE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[11]/div/p";
    }
}
