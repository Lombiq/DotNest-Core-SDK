using OrchardCore.DisplayManagement.Manifest;
using Lombiq.Hosting.MediaTheme.Bridge.Constants;

[assembly: Theme(
    Name = "DotNest Core SDK Theme",
    Author = "Lombiq Technologies",
    Version = "0.0.1",
    Website = "https://github.com/Lombiq/DotNest-Core-SDK",
    Description = "A DotNest theme for local development. It must be packaged and used as a Media Theme on DotNest.",
    BaseTheme = "Lombiq.BaseTheme",
    Dependencies = new[]
    {
        FeatureNames.MediaThemeBridge
    }
)]
