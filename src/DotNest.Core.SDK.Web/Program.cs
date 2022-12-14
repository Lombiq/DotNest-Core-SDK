using Lombiq.Hosting.Tenants.Management.Extensions;
using OrchardCore.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLogHost();

var configuration = builder.Configuration;

builder.Services
    .AddSingleton(configuration)
    .AddOrchardCms(orchardCoreBuilder =>
    {
        orchardCoreBuilder
            .AuthorizeApiRequestsIfEnabled(builder.Configuration)
            .AllowMiniProfilerOnAdmin()
            .AddDatabaseShellsConfigurationIfAvailable(configuration)
            .ConfigureSmtpSettings(overrideAdminSettings: false);

        if (builder.Environment.IsDevelopment())
        {
            orchardCoreBuilder
                .AddSetupFeatures("OrchardCore.AutoSetup")
                .HideRecipesByTagsFromSetup("test", "HideFromSetupScreen");
        }

        // Dependencies need to be added to AddTenantFeatures() explicitly.
        orchardCoreBuilder.AddTenantFeatures(
            "DotNest.Hosting.Tenants",
            Lombiq.Hosting.Tenants.Admin.Login.Constants.FeatureNames.SubTenant,
            Lombiq.Hosting.Tenants.FeaturesGuard.Constants.FeatureNames.FeaturesGuard,
            Lombiq.Hosting.Tenants.IdleTenantManagement.Constants.FeatureNames.ShutDownIdleTenants);
    });

var app = builder.Build();

app.UseStaticFiles();
app.UseOrchardCore();
app.Run();
