using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using find_information_products_services_tests.constants;
using find_information_products_services_tests.utilities;
using FiPSAutomation;
using Microsoft.Playwright;
using static find_information_products_services_tests.utilities.ExcelReader;

namespace find_information_products_services_tests
{
    internal class FastTest : BaseTest
    {

        [Test, Order(1), Category("smoke")]
        public async Task LoginWithUsernameAndPassword()
        {
            await loginWithUsernameAndPasswordAndAcceptAndHideCookies();
        }

        [Test, Order(2), Category("functional")]
        public async Task VerifyRequestNewProductEntryForm_AddingProductUS141AC()
        {
            goToLink("products");
            await page.GetByRole(AriaRole.Link, new() { NameString = "make a request" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Request a new product entry" })).
                                                                             ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.REQUEST_NEW_PRODUCT_FORM)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Use this form to request a new product to be added to FIPS. An administrator will review your request before it is added.", new()
                                                                           { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("This form should only be submitted by a permanent member of DfE staff.", new()
                                                                           { Exact = true })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Product details" })).
                                                                                              ToBeVisibleAsync();
            await Assertions.Expect(page.GetByLabel("Product title")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TITLE).FillAsync("Automation - Test Product Title");
            await Assertions.Expect(page.GetByLabel("Description")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_DESCRIPTION).
                FillAsync("Automation Test - Adding description of more than 1000 characters - Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE. Standards and guidance for designing and building accessible and inclusive products and services in DfE - Test description ends.");
            await Assertions.Expect(page.GetByLabel("Product URL (optional)")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_URL).FillAsync("https://automation-test-product.education.gov.uk/");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Product classification" })).
                                                                                             ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHECK_PHASE_TEXT)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_PHASE1).CheckAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHECK_BUSINESSAREA_TEXT)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_BUSINESSAREA1).CheckAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHECK_CHANNELS_TEXT)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB1).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB2).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB3).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB4).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB5).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB6).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB7).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB8).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB9).CheckAsync();
            await Assertions.Expect(page.Locator(FipsLocator.CHECK_TYPES_TEXT)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB1).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB2).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB3).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB4).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TYPES_CB5).CheckAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Additional information" })).
                                                                                              ToBeVisibleAsync();
            await Assertions.Expect(page.GetByLabel("Tell us in your own words who the users of the product are (optional)")).
                                                                                              ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_ADDITIONAL_INFO).
                FillAsync("Additional information - adding automation test case for new product entry form. This product can be used by teachers, school leaders and responsible bodies.");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { NameString = "Team roles (optional)" })).
                                                                                              ToBeVisibleAsync();
            await Assertions.Expect(page.GetByLabel("Delivery Manager")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_DELIVERY_MANAGER).FillAsync("Automation test Delivery Manager");
            await Assertions.Expect(page.GetByLabel("Product Manager")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_MANAGER).FillAsync("Automation test Product Manager");
            await Assertions.Expect(page.GetByLabel("Senior Responsible Officer")).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_SENIOR_RESP_OFFICER).FillAsync("Automation test Senior Resp Officer");
            await Assertions.Expect(page.GetByLabel("Notes")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(FipsLocator.NOTES_HINT_TEXT)).
                ToHaveTextAsync("Provide any additional information that would help the FIPS team understand this request.");
            await page.Locator(FipsLocator.ADD_NOTES_TEXTBOX).
                FillAsync("Automation test - providing additional information that would help the FIPS team understand this request.");
            await Assertions.Expect(page.Locator(FipsLocator.SUBMIT_REQUEST_BUTTON)).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Cancel" })).ToBeVisibleAsync();
            await Task.Delay(2000);
            await page.Locator(FipsLocator.SUBMIT_REQUEST_BUTTON).ClickAsync();
            await Task.Delay(1000);
            bool successMsg = await page.Locator(FipsLocator.ADD_PRODUCT_SUCCESS_ALERT).IsVisibleAsync();
            Assert.That(successMsg, Is.True);
            await Assertions.Expect(page.Locator(FipsLocator.ADD_PRODUCT_SUCCESS_ALERT)).
                ToContainTextAsync("Your new product entry request has been submitted. The FIPS team will review your request and may contact you if additional information is needed.");

            extentTest?.Log(Status.Pass, "VerifyRequestNewProductEntryForm_AddingProductUS141AC passed");
        }

        [Test, Order(2), Category("functional")]
        public async Task ValidateRequestNewProductForm_SubmitBlankFormUS141AC()
        {
            await Assertions.Expect(page.Locator(FipsLocator.REQUEST_NEW_PRODUCT_FORM)).ToBeVisibleAsync();

            //Clicking on Submit button without entering any details -
            await page.Locator(FipsLocator.SUBMIT_REQUEST_BUTTON).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.ERROR_MESSAGE_BOX)).ToContainTextAsync("There is a problem");
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Please provide a product title" })).
                                                                          ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Please provide a description" })).
                                                                          ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { NameString = "Please provide notes about this request" })).
                                                                          ToBeVisibleAsync();

            //Clicking on error messages links -
            await page.GetByRole(AriaRole.Link, new() { NameString = "Please provide a product title" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.ADD_PRODUCT_TITLE)).ToBeFocusedAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TITLE).FillAsync("Automation test - Product Title A");
            await Assertions.Expect(page.Locator(FipsLocator.TITLE_ERROR_MESSAGE)).
                             ToHaveTextAsync("Error:\r\n                        Please provide a product title");

            await page.GetByRole(AriaRole.Link, new() { NameString = "Please provide a description" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.ADD_PRODUCT_DESCRIPTION)).ToBeFocusedAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_DESCRIPTION).
                       FillAsync("Automation test - Submitted blank form and then verifying all error messages for mandatory fields.");
            await Assertions.Expect(page.Locator(FipsLocator.DESCRIPTION_ERROR_MESSAGE)).
                             ToHaveTextAsync("Error:\r\n                        Please provide a description");

            await page.GetByRole(AriaRole.Link, new() { NameString = "Please provide notes about this request" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.ADD_NOTES_TEXTBOX)).ToBeFocusedAsync();
            await page.Locator(FipsLocator.ADD_NOTES_TEXTBOX).
                         FillAsync("Automation test -  Submitting form after entering only mandatory details");
            await Assertions.Expect(page.Locator(FipsLocator.NOTES_ERROR_MESSAGE)).
                             ToHaveTextAsync("Error:\r\n                        Please provide notes about this request");
            await Task.Delay(2000);
            await page.Locator(FipsLocator.SUBMIT_REQUEST_BUTTON).ClickAsync();
            await Task.Delay(1000);
            bool successMsg = await page.Locator(FipsLocator.ADD_PRODUCT_SUCCESS_ALERT).IsVisibleAsync();
            Assert.That(successMsg, Is.True);
            await Assertions.Expect(page.Locator(FipsLocator.ADD_PRODUCT_SUCCESS_ALERT)).
                ToContainTextAsync("Your new product entry request has been submitted. The FIPS team will review your request and may contact you if additional information is needed.");

            extentTest?.Log(Status.Pass, "ValidateRequestNewProductForm_SubmitBlankFormUS141AC passed");
        }

        [Test, Order(3), Category("functional")]
        public async Task VerifyRequestNewProductForm_AddDetailsAndClickCancelUS141AC()
        {
            //goToLink("products");
            //await page.GetByRole(AriaRole.Link, new() { NameString = "make a request" }).ClickAsync();
            await Assertions.Expect(page.Locator(FipsLocator.REQUEST_NEW_PRODUCT_FORM)).ToBeVisibleAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_TITLE).FillAsync("Automation test - Product Title B");
            await page.Locator(FipsLocator.ADD_PRODUCT_DESCRIPTION).
                                                 FillAsync("Automation test - Adding description for new product");
            await page.Locator(FipsLocator.ADD_PRODUCT_PHASE2).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_BUSINESSAREA2).CheckAsync();
            await page.Locator(FipsLocator.ADD_PRODUCT_CHANNELS_CB5).CheckAsync();
            await page.Locator(FipsLocator.ADD_ADDITIONAL_INFO).
                                                FillAsync("Additional information - validating Cancel button functionality");
            await page.Locator(FipsLocator.ADD_DELIVERY_MANAGER).FillAsync("Automation - DfE Delivery Manager");
            await page.Locator(FipsLocator.ADD_NOTES_TEXTBOX).
                                                 FillAsync("Automation test - adding all necessary details and then clicking on Cancel");
            await page.GetByRole(AriaRole.Link, new() { NameString = "Cancel" }).ClickAsync();
            await Assertions.Expect(page).ToHaveTitleAsync("Search and filter products and services - FIPS");
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new()
            { NameString = "Search and filter products and services" })).ToBeVisibleAsync();

            extentTest?.Log(Status.Pass, "VerifyRequestNewProductForm_AddDetailsAndClickCancelUS141AC passed");
        }

    }
}
