# find-information-products-services-tests

### Build the project
dotnet build

### Install required browsers - replace netX with actual output folder name, e.g. net8.0.
pwsh bin/Debug/net8.0/playwright.ps1 install

### If the pwsh command does not work (throws TypeNotFound), make sure to use an up-to-date version of PowerShell.
dotnet tool update --global PowerShell
pwsh bin/Debug/net8.0/playwright.ps1 install

### To execute testcases run
dotnet test

## To execute specific category testcases run
dotnet test --filter "TestCategory=functional"


### Important link:
https://playwright.dev/dotnet/

Update https://github.com/DFE-Digital/find-information-products-services-tests/blob/main/FIPS.env.json file with Base64Encoded username and password and correct env. It picks env based on activeEnv value. Currently, it supports dev and test env.  If login is not required for dev/test environment then set false for loginRequired field in json file.
