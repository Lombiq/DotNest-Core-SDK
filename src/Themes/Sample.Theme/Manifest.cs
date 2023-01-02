using Lombiq.Hosting.MediaTheme.Bridge.Constants;
using OrchardCore.DisplayManagement.Manifest;

[assembly: Theme(
    Name = "Sample Theme",
    Author = "Lombiq Technologies",
    Version = "0.0.1",
    Website = "https://github.com/Lombiq/DotNest-Core-SDK",
    Description = "A sample DotNest theme for local development. It must be packaged and used as a Media Theme on DotNest.",
    BaseTheme = "Lombiq.BaseTheme",
    Dependencies = new[]
    {
        FeatureNames.MediaThemeBridge
    }
)]
