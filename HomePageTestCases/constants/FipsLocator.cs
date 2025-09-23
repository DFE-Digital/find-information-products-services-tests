using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
