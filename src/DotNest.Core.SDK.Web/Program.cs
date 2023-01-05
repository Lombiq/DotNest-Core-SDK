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
            .AllowMiniProfilerOnAdmin()
            .AddDatabaseShellsConfigurationIfAvailable(configuration)
            .ConfigureSmtpSettings(overrideAdminSettings: false);

        if (builder.Environment.IsDevelopment())
        {
            orchardCoreBuilder
                .AddSetupFeatures("OrchardCore.AutoSetup")
                .HideRecipesByTagsFromSetup("test", "HideFromSetupScreen");
        }
    });

var app = builder.Build();

app.UseStaticFiles();
app.UseOrchardCore();
app.Run();
