using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_information_products_services_tests.HomePageTestCases.constants
{
    internal class URLConstant
    {
        public static readonly String ENVIRONMENT = "test";//dev, test

        public static readonly string LOGIN_URL = "https://login.microsoftonline.com/common/login";

        //DEV ENV DETAILS
        public static readonly string DEV_LOGIN_OAUTH_URL =  "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?response_type=code+id_token&redirect_uri=https%3A%2F%2Ffind-products-services-dev.education.gov.uk%2F.auth%2Flogin%2Faad%2Fcallback&client_id=31ff7feb-28d4-450b-9eef-0d79bb8edb1f&scope=openid+profile+email&response_mode=form_post&nonce=47d64632ccef4060980eed87c512efee_20250915055830&state=redir%3D%252F";
        public static readonly string DEV_LOGIN_SSO_URL = DEV_LOGIN_OAUTH_URL + "&sso_reload=true";
        public static readonly string DEV_FIPS_URL = "https://find-products-services-dev.education.gov.uk/";

        //TEST ENV DETAILS
        public static readonly string TEST_LOGIN_OAUTH_URL = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?response_type=code+id_token&redirect_uri=https%3A%2F%2Ffind-products-services-test.azurewebsites.net%2F.auth%2Flogin%2Faad%2Fcallback&client_id=31ff7feb-28d4-450b-9eef-0d79bb8edb1f&scope=openid+profile+email&response_mode=form_post&nonce=1daa62ddcfd944c394bc77ec9fc5648a_20251022211602&state=redir%3D%252F";
        public static readonly string TEST_LOGIN_SSO_URL = TEST_LOGIN_OAUTH_URL + "&sso_reload=true";
        public static readonly string TEST_FIPS_URL = "https://find-products-services-test.azurewebsites.net/";
    }
}
