# find-information-products-services-tests

### Build the project
dotnet build

### Onetime installation: Install required browsers.
pwsh bin/Debug/net8.0/playwright.ps1 install

### Onetime installation: If the pwsh command does not work (throws TypeNotFound) from PowerShell.
dotnet tool update --global PowerShell
pwsh bin/Debug/net8.0/playwright.ps1 install

### To execute testcases run
dotnet test

## To execute specific category testcases run
dotnet test --filter "TestCategory=functional"


### Important link:
https://playwright.dev/dotnet/

Update https://github.com/DFE-Digital/find-information-products-services-tests/blob/main/env.json file with Base64Encoded username and password and correct env. It picks env based on activeEnv value. Currently, it supports dev and test env.  If login is not required for dev/test/prod environment then set false for loginRequired field in json file.

To encode username/password use base64-encode-utility.html.
