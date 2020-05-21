# GrandEventCentral
Project is stuctured so that Server is using ASP.NET to host Client WASM. Publishing or running Server should also pull up Client. 

Supportive project like FacebookCore wrap Facebook API requests, there is Steve Anderson started Blazor Components Testing helping project that will be later replaced by bunit. 

There is offline-list-generator.ps1 is atm a baby, therefore needs proper path setting for it to be of some use. 

# Project prerequisites
VS2019, .NET Core 3.1 or latest package, SQL Server, Azure Storage Emulator

# Featureset
* Create Events
    * Get Locations from Facebook API
* Attend to event on site
* Post to Facebook about event
* Using Azure Function to do sth

# Testing
Testing is highly experimental here, read more from  https://blog.stevensanderson.com/2019/08/29/blazor-unit-testing-prototype/
and follow this bug in github https://github.com/dotnet/aspnetcore/issues/5458

* Authors Twitter: https://twitter.com/stevensanderson
* Test examples: https://github.com/SteveSandersonMS/BlazorUnitTestingPrototype/tree/master/SampleApp.Tests

Migration should be done towards: https://bunit.egilhansen.com/

# Other notes
For Facebook event integration is available only to Facebook Marketing Partners. One can register on this page for this: https://developers.facebook.com/products/official-events-api/