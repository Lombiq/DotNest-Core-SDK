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
        .ConfigureSmtpSettings(overrideAdminSettings: false);

    if (builder.Environment.IsDevelopment())
    {
        orchardCoreBuilder.AddSetupFeatures("OrchardCore.AutoSetup");
    }
});

var app = builder.Build();

app.UseStaticFiles();
app.UseOrchardCore();
app.Run();
