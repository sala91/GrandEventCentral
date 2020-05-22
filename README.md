# GrandEventCentral
Project is stuctured so that Server is using ASP.NET to host Client WASM. Publishing or running Server should also pull up Client. Supportive project like FacebookCore wrap Facebook API requests, there is Steve Anderson started Blazor Components Testing helping project that will be later replaced by bunit. 

There is offline-list-generator.ps1 is atm a baby, therefore needs proper path setting for it to be of some use. 

# Project prerequisites
VS2019, .NET Core 3.1 or latest package, SQL Server, Azure Storage Emulator

# Project sturcture
* GrandEventCentral.Client - WASM project, hosted by Server
* GrandEventCentral.Server - ASP.NET Core hosting WASM projecct
* GrandEventCentral.Shared - Components that are shared between projects
* GrandEventCentral.SQLServer - For keeping database up-to-date. This can alo include in future automatic data script to fill db.
* GrandEventCentral.Test - For doing unit testing for blazor components
* GrandEventCentral.Function - For image emotion analysis, an example for connecting rest of cognitive services
* FacebookCore - An API wrapper for communicating with Facebook
* FacebookCore.Test - Tests for FacebookCore to ensure API connection is working as intended
* Microsoft.AspNetCore.Components.Testing - In future gonna be removed and replaced with nuget package bunit

# Featureset
* Create Events, delete events, see event details, edit events (Done)
    * Get Locations from Facebook API (API project done, tests done, not integrated to client)
    * Post events to Facebook (requiers partnership, not yet done)
* Attend to event on site 
* Using Azure Function to measure people emotions on picture

# Testing
Testing is highly experimental here, read more from  https://blog.stevensanderson.com/2019/08/29/blazor-unit-testing-prototype/
and follow this bug in github https://github.com/dotnet/aspnetcore/issues/5458

* Authors Twitter: https://twitter.com/stevensanderson
* Test examples: https://github.com/SteveSandersonMS/BlazorUnitTestingPrototype/tree/master/SampleApp.Tests

Migration should be done towards: https://bunit.egilhansen.com/

# Other notes
For Facebook event integration is available only to Facebook Marketing Partners. One can register on this page for this: https://developers.facebook.com/products/official-events-api/

# Lessons learned
* Telerik components don't play well together with Blazorise components, probably due to namespace issues.
* The documentation for Identiy server can be a little bit off. Had to figure out on my own how to auhtenticate over web request
* Facebook Events api requers approval
* Uber api requiers approval
* Twitter api requers approval
* Trafi / Google Transit api no longer available, workaround is to use Google Maps api for directions


# Config files
You need appsettings.json file in FacebookCore.Test with following config
{
  "client_id": "<your-app-id-here>",
  "client_secret": "<your-secret-here>",
  "access_token": "<your-access-token-here>"
}

For cognitive services, you need to add local-settings.json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "AzureWebJobsDashboard": "UseDevelopmentStorage=true",
        "CognitiveServicesUrlBase": "endpointurl",
        "CognitiveServicesKey": "endpointsecretkey",
        "FUNCTIONS_V2_COMPATIBILITY_MODE": true,
        "AllowSynchronousIO": true
    }
}

And you also need in GrandEventCentral.Server appsettings.json with following contents
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=[yoursevernamehere];Database=GrandEventCentral;Trusted_Connection=True;MultipleActiveResultSets=true"
    },
    "IdentityServer": {
        "Clients": {
            "GrandEventCentral.Client": {
                "Profile": "IdentityServerSPA"
            }
        },
        "Key": {
            "Type": "Development"
        }
    },
    "AllowedHosts": "*"
}


NB! This is settings for development only, you should not use those settings in production.