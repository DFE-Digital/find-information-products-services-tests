using System;

namespace find_information_products_services_tests.constants
{
    internal class FipsLocator
    {
        //Home page locators -
        public static readonly string HOME_SEARCH_LOCATOR = "[class=\"govuk-button govuk-button--start govuk-button--inverse home-cta-link\"]";
        public static readonly string HOME_PAGE_TILES = "(//div[@class='govuk-grid-column-full'])[1]";
        public static readonly string ABOUT_SERVICE_LOCATOR = "//*[@id=\"main-content\"]/div/div/div/div[2]/a[2]";
        public static readonly string ALL_PRODUCT_LOCATOR = "//h2[text() = 'All products and services']";
        public static readonly string BROWSE_CATEGORY_LOCATOR = "//h2[text() = 'Browse categories']";
        public static readonly string USE_DATA_LOCATOR = "//h2[text() = 'Use the data']";
        public static readonly string KEEP_INFO_UPDATE_LOCATOR = "//h2[text() = 'Keep information updated']";
        public static readonly string USER_GROUP_CHEVRON_LINK = ".dfe-chevron-card__link.category-link[href='/categories/user-group']";
        public static readonly string CATEGORY_CHANNEL_LINK = "a[href='/categories/channel']";
        //Phase description locators -
        //public static readonly string PHASE_REQUEST_LINK = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/h2/a";
        //public static readonly string PHASE_REQUEST_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
        //public static readonly string PHASE_EXPLORE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
        //public static readonly string PHASE_TRIAGE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
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
        public static readonly string SHOWING_RESULTS_MESSAGE = "//p[@class =\"govuk-body\" and contains(text(), \"Showing \")]"; //update
        public static readonly string REQUEST_CHECKBOX = "#phase-request";
        public static readonly string EXPLORE_CHECKBOX = "#phase-explore";

        //Channel description locators -
        public static readonly string CHANNEL_CHAT_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
        public static readonly string CHANNEL_EMAIL_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
        public static readonly string CHANNEL_FACETOFACE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
        public static readonly string CHANNEL_NATIVEAPP_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[4]/div/p";
        public static readonly string CHANNEL_OTHERDIGITALMEDIA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[5]/div/p";
        public static readonly string CHANNEL_PHONE_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[6]/div/p";
        public static readonly string CHANNEL_PRINTMEDIA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[7]/div/p";
        public static readonly string CHANNEL_SMS_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[8]/div/p";
        public static readonly string CHANNEL_WEB_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[9]/div/p";

        //Business area description locators -
        public static readonly string GROUP_FAMILIES_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
        public static readonly string GROUP_REGIONS_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
        public static readonly string GROUP_SCHOOLS_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
        public static readonly string GROUP_SKILLS_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[4]/div/p";
        public static readonly string GROUP_OPERATIONSANDINFRA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[5]/div/p";
        public static readonly string GROUP_STRATEGY_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[6]/div/p";

        //public static readonly string OPERATIONSANDINFRA_HEADING_DESC = "//*[@id=\"main-content\"]/div/div/div/h1";
        //public static readonly string OPERATIONSANDINFRA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul[1]/li/div/p";
        //public static readonly string OPERATIONSANDINFRA_CXD_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul[2]/li[1]/div/p";
        //public static readonly string OPERATIONSANDINFRA_ENTERPRISEDATA_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul[2]/li[2]/div/p";
        //public static readonly string OPERATIONSANDINFRA_FUNDING_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul[2]/li[3]/div/p";
        //public static readonly string OPERATIONSANDINFRA_SUBCATEGORIES_HEAD_LINK = "//*[@id=\"main-content\"]/div/div/div/h2";
        //public static readonly string OPERATIONSANDINFRA_SUBCATEGORIES_HEAD_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/p[2]";

        //Type description locators -
        public static readonly string TYPE_API_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[1]/div/p";
        public static readonly string TYPE_CAMPAIGN_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[2]/div/p";
        public static readonly string TYPE_INFORMATION_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[3]/div/p";
        public static readonly string TYPE_TRANSACTIONAL_LINK_DESC = "//*[@id=\"main-content\"]/div/div/div/ul/li[4]/div/p";

        //User group subcategories description locators -
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

        //Footer links and Feedback locators -
        public static readonly string SAVE_COOKIES_RADIO_OFF = "#analytics-off";
        public static readonly string SAVE_COOKIES_RADIO_ON = "#analytics-on";
        public static readonly string SAVE_COOKIES_ALERT = ".govuk-notification-banner.govuk-notification-banner--success";
        public static readonly string FEEDBACK_TEXTBOX = "textarea#feedback_form_input";
        public static readonly string FEEDBACK_FORM_ERROR_MSG = "#feedback_form_input-error";
        public static readonly string FEEDBACK_MAXCHARS_ERROR_MSG = "//*[@id=\"feedback_form_group\"]/div[3]";
        public static readonly string FEEDBACK_SUBMIT_ERROR_MSG = "//div[@id=\"feedback-error-summary\"]";

        //Products page locators -
        public static readonly string PRODUCTS_AND_SERVICES_LIST = "ul.dfe-chevron-card__list";
        public static readonly string PRODUCT_NAME_TEXTBOX = "#keywords";
        public static readonly string USER_GROUPS_LISTBOX = "#user-autocomplete";
        public static readonly string USER_GROUPS_OPTION1 = "#user-autocomplete__option--1";
        public static readonly string USER_GROUPS_OPTION2 = "#user-autocomplete__option--3";
        public static readonly string USER_GROUPS_OPTION3 = "#user-autocomplete__option--2";
        public static readonly string SELECTED_USERTYPES_CHECKBOX = "#user-0";
        public static readonly string BUSINESS_AREA_CATEGORY = "//button[@data-target=\"group-filter\"]";
        public static readonly string CHANNEL_CATEGORY = "//button[@data-target=\"channel-filter\"]";
        public static readonly string PHASE_CATEGORY = "//button[@data-target=\"phase-filter\"]";
        public static readonly string TYPE_CATEGORY = "//button[@data-target=\"type-filter\"]";

        //Business area checkboxes locators -
        public static readonly string BA_COMMERCIAL_CHECKBOX = "label[for='group-commercial']";
        public static readonly string BA_CUST_EXP_DESIGN_CHECKBOX = "label[for='group-customer-experience-and-design']";
        public static readonly string BA_CHILD_AND_FAMILIES_CHECKBOX = "label[for='group-children-and-families']";
        public static readonly string BA_ENTERPRISE_DATA_CHECKBOX = "label[for='group-enterprise-data']";
        public static readonly string BA_FUND_FINANCIAL_OS_CHECKBOX = "label[for='group-funding-and-financial-oversight']";
        public static readonly string BA_OPS_AND_INFRA_CHECKBOX = "label[for='group-operations-and-infrastructure']";
        public static readonly string BA_REGION_DIGI_SERVICES_CHECKBOX = "label[for='group-regional-digital-services']";
        public static readonly string BA_SCHOOLS_DIGI_CHECKBOX = "label[for='group-schools-digital']";
        public static readonly string BA_SECTOR_FACING_SERVICES_CHECKBOX = "label[for='group-sector-facing-services']";
        public static readonly string BA_SKILLS_AND_GROWTH_CHECKBOX = "label[for='group-skills-and-growth']";
        public static readonly string BA_STRATEGY_CHECKBOX = "label[for='group-strategy']";
        public static readonly string BA_NOT_CATEGORISED_CHECKBOX = "label[for='group-not-categorised']";

        //Channel checkboxes locators -
        public static readonly string CHANNEL_CHAT_CHECKBOX = "label[for='channel-chat']";
        public static readonly string CHANNEL_EMAIL_CHECKBOX = "label[for='channel-email']";
        public static readonly string CHANNEL_FACETOFACE_CHECKBOX = "label[for='channel-face-to-face']";
        public static readonly string CHANNEL_NATIVE_APP_CHECKBOX = "label[for='channel-native-app']";
        public static readonly string CHANNEL_OTHER_DIGI_MEDIA_CHECKBOX = "label[for='channel-other-digital-media']";
        public static readonly string CHANNEL_PHONE_CHECKBOX = "label[for='channel-phone']";
        public static readonly string CHANNEL_PRINT_MEDIA_CHECKBOX = "label[for='channel-print-media']";
        public static readonly string CHANNEL_SMS_CHECKBOX = "label[for='channel-sms']";
        public static readonly string CHANNEL_WEB_CHECKBOX = "label[for='channel-web']";
        public static readonly string CHANNEL_NOT_CATEGORISED_CHECKBOX = "label[for='channel-not-categorised']";

        //Phase checkboxes locators -
        public static readonly string PHASE_DISCOVERY_CHECKBOX = "label[for='phase-discovery']";
        public static readonly string PHASE_ALPHA_CHECKBOX = "label[for='phase-alpha']";
        public static readonly string PHASE_DID_NOT_PROGRESS_CHECKBOX = "label[for='phase-did-not-progress']";
        public static readonly string PHASE_PRIVATE_BETA_CHECKBOX = "label[for='phase-private-beta']";
        public static readonly string PHASE_PUBLIC_BETA_CHECKBOX = "label[for='phase-public-beta']";
        public static readonly string PHASE_LIVE_CHECKBOX = "label[for='phase-live']";
        public static readonly string PHASE_DECOMMISSIONING_CHECKBOX = "label[for= 'phase-decommissioning']";
        public static readonly string PHASE_DECOMMISSIONED_CHECKBOX = "label[for='phase-decommissioned']";
        public static readonly string PHASE_NOT_CATEGORISED_CHECKBOX = "label[for='phase-not-categorised']";

        //Type checkboxes locators -
        public static readonly string TYPE_CHECKBOX1_SELECTED = "label[for='type-campaign']";
        public static readonly string TYPE_CHECKBOX2_SELECTED = "label[for='type-information']";

        //Product results page locators - for business area
        public static readonly string APPLIED_FILTERED_PANEL = "div.applied-filters-panel";   //new
        public static readonly string BA_FILTER_HEADING = "//h3[normalize-space()='Business area']";   //new
        //public static readonly string BUSINESS_AREA_FILTERTAG1 = "ul.moj-filter-tags li a:has-text(' Enterprise Data')";
        public static readonly string BA_COMMERCIAL_FILTERTAG = "a.filter-badge:has(span:text-is('Commercial'))";  //new
        public static readonly string BA_CUST_EXP_DESIGN_FILTERTAG = "a.filter-badge:has(span:text-is('Customer Experience and Design'))";
        public static readonly string BA_CHILD_AND_FAMILIES_FILTERTAG = "a.filter-badge:has(span:text-is('Children and Families'))";
        public static readonly string BA_ENTERPRISE_DATA_FILTERTAG = "a.filter-badge:has(span:text-is('Enterprise Data'))";
        public static readonly string BA_FUND_FINANCIAL_OS_FILTERTAG = "a.filter-badge:has(span:text-is('Funding and Financial Oversight'))";
        public static readonly string BA_OPS_AND_INFRA_FILTERTAG = "a.filter-badge:has(span:text-is('Operations and Infrastructure'))";
        public static readonly string BA_REGION_DIGI_SERVICES_FILTERTAG = "a.filter-badge:has(span:text-is('Regional Digital Services'))";
        public static readonly string BA_SCHOOLS_DIGI_FILTERTAG = "a.filter-badge:has(span:text-is('Schools Digital'))";
        public static readonly string BA_SECTOR_FACING_SERVICES_FILTERTAG = "a.filter-badge:has(span:text-is('Sector Facing Services'))";
        public static readonly string BA_SKILLS_AND_GROWTH_FILTERTAG = "a.filter-badge:has(span:text-is('Skills and Growth'))";
        public static readonly string BA_STRATEGY_FILTERTAG = "a.filter-badge:has(span:text-is('Strategy'))";
        public static readonly string BA_NOT_CATEGORISED_FILTERTAG = "a.filter-badge:has(span:text-is('Not categorised'))";
        // for Channel -
        public static readonly string CHANNEL_FILTER_HEADING = "//h3[normalize-space()='Channel']";
        public static readonly string CHANNEL_CHAT_FILTERTAG = "a.filter-badge:has(span:text-is('Chat'))";
        public static readonly string CHANNEL_EMAIL_FILTERTAG = "a.filter-badge:has(span:text-is('Email'))";
        public static readonly string CHANNEL_FACETOFACE_FILTERTAG = "a.filter-badge:has(span:text-is('Face-to-face'))";
        public static readonly string CHANNEL_NATIVE_APP_FILTERTAG = "a.filter-badge:has(span:text-is('Native app'))";
        public static readonly string CHANNEL_OTHER_DIGI_MEDIA_FILTERTAG = "a.filter-badge:has(span:text-is('Other digital media'))";
        public static readonly string CHANNEL_PHONE_FILTERTAG = "a.filter-badge:has(span:text-is('Phone'))";
        public static readonly string CHANNEL_PRINT_MEDIA_FILTERTAG = "a.filter-badge:has(span:text-is('Print media'))";
        public static readonly string CHANNEL_SMS_FILTERTAG = "a.filter-badge:has(span:text-is('SMS'))";
        public static readonly string CHANNEL_WEB_FILTERTAG = "a.filter-badge:has(span:text-is('Web'))";
        public static readonly string CHANNEL_NOT_CATEGORISED_FILTERTAG = "a.filter-badge:has(span:text-is('Not categorised'))";
        // for Phase -
        public static readonly string PHASE_FILTER_HEADING = "//h3[normalize-space()='Phase']";
        public static readonly string PHASE_DISCOVERY_FILTERTAG = "a.filter-badge:has(span:text-is('Discovery'))";
        public static readonly string PHASE_ALPHA_FILTERTAG = "a.filter-badge:has(span:text-is('Alpha'))";
        public static readonly string PHASE_DID_NOT_PROGRESS_FILTERTAG = "a.filter-badge:has(span:text-is('Did not progress'))";
        public static readonly string PHASE_PRIVATE_BETA_FILTERTAG = "a.filter-badge:has(span:text-is('Private beta'))";
        public static readonly string PHASE_PUBLIC_BETA_FILTERTAG = "a.filter-badge:has(span:text-is('Public beta'))";
        public static readonly string PHASE_LIVE_FILTERTAG = "a.filter-badge:has(span:text-is('Live'))";
        public static readonly string PHASE_DECOMMISSIONING_FILTERTAG = "a.filter-badge:has(span:text-is('Decommissioning'))";
        public static readonly string PHASE_DECOMMISSIONED_FILTERTAG = "a.filter-badge:has(span:text-is('Decommissioned'))";
        public static readonly string PHASE_NOT_CATEGORISED_FILTERTAG = "a.filter-badge:has(span:text-is('Not categorised'))";
        // for Type -
        public static readonly string TYPE_FILTERTAG1 = "ul.moj-filter-tags li a:has-text('Campaign')";
        public static readonly string TYPE_FILTERTAG2 = "ul.moj-filter-tags li a:has-text('Information')";

        public static readonly string PAGE_2_LINK = "a[aria-label = \"Page 2\"]";
        public static readonly string PAGE_3_LINK = "a[aria-label = \"Page 3\"]";
        public static readonly string PAGE_6_LINK = "a[aria-label = \"Page 6\"]";
        public static readonly string NEXT_PAGE_LINK = "//span[@class ='govuk-pagination__link-title' and contains(text(), 'Next')]";
        public static readonly string MISSING_PROD_SERVICE_DESC = "//details[@class='govuk-details']";
        public static readonly string MISSING_PROD_SERVICE_LINK = ".govuk-details__summary-text";
        public static readonly string REQUEST_NEW_PRODUCT_DESC = ".govuk-details__text";
        public static readonly string CLEAR_ALL_FILTERS_DESC = "//*[@id=\"main-content\"]/div/div/div[2]/div[3]/p[2]"; // No Products found case
        public static readonly string CLEAR_ALL_FILTERS_LINK = "div[class='govuk-inset-text'] a[class='govuk-link']";  // No Products found case
        public static readonly string CONTACT_US_EMAIL_DESC = "//*[@id=\"main-content\"]/div/div/div[1]/div/p[1]";

        //Product details page locators -
        public static readonly string PRODUCT_LINK = "//a[contains(text(), \"Accessibility and inclusion manual\")]";
        public static readonly string FIPS_ID_LINK = ".govuk-caption-m";
        public static readonly string PHASE_COLUMN = "//th[normalize-space()='Phase']";
        public static readonly string BUSINESS_AREA_COLUMN = "//th[normalize-space()='Business area']";
        public static readonly string CONTACTS_COLUMN = "//th[normalize-space()='Contacts']";
        public static readonly string VIEW_PRODUCT_COLUMN = "//th[normalize-space()='View product']";
        public static readonly string OVERVIEW_LINK = "//*[@id=\"side-navigation\"]/li[1]/a";
        public static readonly string CATEGORIES_LINK = "//*[@id=\"side-navigation\"]/li[2]/a";
        public static readonly string PROPOSE_A_CHANGE_LINK = "//*[@id=\"side-navigation\"]/li[3]/a";
        public static readonly string RESPONSIBILITIES_AND_CONTACTS_HEADER = "#contacts";
        public static readonly string CONTACTS_NAME_LINK = ".govuk-link[href='mailto:andy.jones@education.gov.uk']";
        public static readonly string SERVICE_OWNER_LOCATOR = "(//dt[@class = \"govuk-summary-list__key\"])[1]";
        public static readonly string CATEGORIES_TABLE = "//main[@id='main-content']//table[1]";
        public static readonly string USERS_OF_PRODUCT_TABLE = "//main[@id='main-content']//table[2]";
        public static readonly string PROPOSED_FORM = "//form[@method='post']";
        public static readonly string PRODUCT_DETAIL_TABLE = "(//table[@class = \"govuk-table\"])[1]";
        public static readonly string CATEGORIES_DETAIL_TABLE = "(//table[@class = \"govuk-table\"])[2]";
        public static readonly string USER_PRODUCT_TABLE = "(//table[@class = \"govuk-table\"])[3]";
        public static readonly string PHASE_SELECTED_FILTERTAG = "ul.moj-filter-tags li a:has-text('Live')";
        public static readonly string TYPE_SELECTED_FILTERTAG = "ul.moj-filter-tags li a:has-text('Information')";
        public static readonly string USER_GROUPS_FILTERTAG = "ul.moj-filter-tags li a:has-text('Department for Education workforce')";

        // Propose a change form locators -
        public static readonly string PRODUCT_TITLE_TEXTBOX = "#ProposedTitle";
        public static readonly string SHORT_DESCRIPTION_TEXTBOX = "#ProposedShortDescription";
        public static readonly string PRODUCT_URL_TEXTBOX = "#ProposedProductUrl";
        public static readonly string PRODUCT_CLASSIFICATION_PHASE = "legend:has-text(\"Phase\")";
        public static readonly string PRODUCT_CLASSIFICATION_BUSINESSAREA = "legend:has-text(\"Business area\")";
        public static readonly string PRODUCT_CLASSIFICATION_CHANNELS = "legend:has-text(\"Channels\")";
        public static readonly string PRODUCT_CLASSIFICATION_TYPES = "legend:has-text(\"Types\")";
        public static readonly string SELECTED_PHASE_RADIOBUTTON = "#ProposedPhaseId_389";
        public static readonly string SELECTED_BUSINESSAREA_RADIOBUTTON = "#ProposedGroupId_445";
        public static readonly string SELECTED_CHANNEL_CHECKBOXES = "#ProposedChannelIds_375";
        public static readonly string SELECTED_TYPES_CHECKBOXES = "#ProposedTypeIds_393";
        public static readonly string ADDITIONAL_INFO_TEXTBOX = "#ProposedUserDescription";
        public static readonly string DELIVERY_MANAGER_TEXTBOX = "#ProposedDeliveryManager";
        public static readonly string INFO_ASSET_OWNER_TEXTBOX = "#ProposedInformationAssetOwner";
        public static readonly string PRODUCT_MANAGER_TEXTBOX = "#ProposedProductManager";
        public static readonly string SENIOR_RESP_OFFICER_TEXTBOX = "#ProposedServiceOwner";
        public static readonly string REASON_HINT_TEXT = "#Reason-hint";
        public static readonly string REASON_FOR_CHANGE_TEXTBOX = "#Reason";
        public static readonly string SUBMIT_CHANGE_BUTTON = "#submit-changes-btn";
        public static readonly string CHANGED_PHASE_RADIOBUTTON = "#ProposedPhaseId_388";
        public static readonly string CHANGED_BUSINESSAREA_RADIOBUTTON = "#ProposedGroupId_429";
        public static readonly string ADDED_CHANNEL_CHECKBOXES = "#ProposedChannelIds_379";
        public static readonly string ADDED_TYPES_CHECKBOXES = "#ProposedTypeIds_418";
        public static readonly string SUCCESS_MESSAGE_ALERT = ".govuk-notification-banner.govuk-notification-banner--success"; //after submission of proposed change
        public static readonly string BETA_PHASE_BANNER_DESC = "div[class='govuk-phase-banner'] div[class='govuk-width-container']";

        //Survey/feedback link locators -
        public static readonly string FEEDBACK_BANNER = "//div[@class='dfe-feedback-banner--flex']";
        public static readonly string SURVEY_LINK_TEXT = "//*[@id=\"feedback-link-text\"]/a[1]";
        public static readonly string SURVEY_FIRST_PAGE = "//div[@class='QuestionText BorderColor']";

        //Request a new product page locators -
        public static readonly string REQUEST_NEW_PRODUCT_FORM = "//form[@method='post']";
        public static readonly string ADD_PRODUCT_TITLE = "#Title";
        public static readonly string ADD_PRODUCT_DESCRIPTION = "#Description";
        public static readonly string ADD_PRODUCT_URL = "#ServiceUrl";
        public static readonly string CHECK_PHASE_TEXT = "legend:has-text('Phase')";
        public static readonly string CHECK_BUSINESSAREA_TEXT = "legend:has-text('Business area')";
        public static readonly string CHECK_CHANNELS_TEXT = "legend:has-text('Channels (optional)')";
        public static readonly string CHECK_TYPES_TEXT = "legend:has-text('Types (optional)')";
        public static readonly string ADD_PRODUCT_PHASE1 = "#PhaseId_387";
        public static readonly string ADD_PRODUCT_PHASE2 = "#PhaseId_389";
        public static readonly string ADD_PRODUCT_BUSINESSAREA1 = "#BusinessAreaId_445";
        public static readonly string ADD_PRODUCT_BUSINESSAREA2 = "#BusinessAreaId_439";
        public static readonly string ADD_PRODUCT_CHANNELS_CB1 = "#ChannelIds_380";
        public static readonly string ADD_PRODUCT_CHANNELS_CB2 = "#ChannelIds_379";
        public static readonly string ADD_PRODUCT_CHANNELS_CB3 = "#ChannelIds_377";
        public static readonly string ADD_PRODUCT_CHANNELS_CB4 = "#ChannelIds_376";
        public static readonly string ADD_PRODUCT_CHANNELS_CB5 = "#ChannelIds_382";
        public static readonly string ADD_PRODUCT_CHANNELS_CB6 = "#ChannelIds_378";
        public static readonly string ADD_PRODUCT_CHANNELS_CB7 = "#ChannelIds_381";
        public static readonly string ADD_PRODUCT_CHANNELS_CB8 = "#ChannelIds_415";
        public static readonly string ADD_PRODUCT_CHANNELS_CB9 = "#ChannelIds_375";
        public static readonly string ADD_PRODUCT_TYPES_CB1 = "#TypeIds_416";
        public static readonly string ADD_PRODUCT_TYPES_CB2 = "#TypeIds_394";
        public static readonly string ADD_PRODUCT_TYPES_CB3 = "#TypeIds_418";
        public static readonly string ADD_PRODUCT_TYPES_CB4 = "#TypeIds_393";
        public static readonly string ADD_PRODUCT_TYPES_CB5 = "#TypeIds_392";
        public static readonly string ADD_ADDITIONAL_INFO = "#Users";
        public static readonly string ADD_DELIVERY_MANAGER = "#DeliveryManager";
        public static readonly string ADD_PRODUCT_MANAGER = "#ProductManager";
        public static readonly string ADD_SENIOR_RESP_OFFICER = "#SeniorResponsibleOfficer";
        public static readonly string ADD_NOTES_TEXTBOX = "#Notes";
        public static readonly string NOTES_HINT_TEXT = "#Notes-hint";
        public static readonly string SUBMIT_REQUEST_BUTTON = "#submit-request-btn";
        public static readonly string ADD_PRODUCT_SUCCESS_ALERT = "div[aria-labelledby = \"govuk-notification-banner-title\"]";
        public static readonly string ERROR_MESSAGE_BOX = "//div[@aria-labelledby='error-summary-title']";
        public static readonly string TITLE_ERROR_MESSAGE = "(//span[@class='govuk-error-message'])[1]";
        public static readonly string DESCRIPTION_ERROR_MESSAGE = "(//span[@class='govuk-error-message'])[2]";
        public static readonly string NOTES_ERROR_MESSAGE = "(//span[@class='govuk-error-message'])[3]";
    }
}
