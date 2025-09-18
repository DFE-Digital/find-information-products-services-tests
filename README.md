"# find-information-products-services-tests" 

# Build the project
dotnet build
# Install required browsers - replace netX with actual output folder name, e.g. net8.0.
pwsh bin/Debug/net9.0/playwright.ps1 install

# If the pwsh command does not work (throws TypeNotFound), make sure to use an up-to-date version of PowerShell.
dotnet tool update --global PowerShell

pwsh bin/Debug/net9.0/playwright.ps1 install


# To execute testcases run
dotnet test

# Important link:
https://playwright.dev/dotnet/