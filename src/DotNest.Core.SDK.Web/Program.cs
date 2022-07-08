using Lombiq.Hosting.Tenants.Admin.Login.Constants;
using Lombiq.Hosting.Tenants.Management.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var configuration = builder.Configuration;

builder.Services.AddOrchardCms(orchardCoreBuilder =>
{
    orchardCoreBuilder
        .AuthorizeApiRequestsIfEnabled(builder.Configuration)
        .AllowMiniProfilerOnAdmin()
        .AddDatabaseShellsConfigurationIfAvailable(configuration)
        .ConfigureSmtpSettings(overrideAdminSettings: false)
        .ConfigureUITesting(configuration, enableShortcutsDuringUITesting: true);

    if (!configuration.IsUITesting())
    {
        orchardCoreBuilder.AddSetupFeatures("OrchardCore.AutoSetup").HideRecipesByTagsFromSetup();
    }

    // Dependencies need to be added to AddTenantFeatures() explicitly.
    orchardCoreBuilder.AddTenantFeatures("DotNest.Hosting.Tenants", FeatureNames.SubTenant);

    if (configuration.IsAzureHosting())
    {
        orchardCoreBuilder.AddTenantFeatures(
            "Lombiq.Hosting.Azure.ApplicationInsights",
            "OrchardCore.DataProtection.Azure");

        // Azure Media Storage and its dependencies. It's always enabled for now but should rather only be enabled if
        // OrchardCore.Media is.
        orchardCoreBuilder.AddTenantFeatures(
            "OrchardCore.Contents",
            "OrchardCore.ContentTypes",
            "OrchardCore.Liquid",
            "OrchardCore.Media",
            "OrchardCore.Media.Azure.Storage",
            "OrchardCore.Media.Cache",
            "OrchardCore.Settings");
    }
});

var app = builder.Build();

app.UseForwardedHeadersForCloudflareAndAzure();

app.UseStaticFiles();
app.UseOrchardCore();
app.Run();
