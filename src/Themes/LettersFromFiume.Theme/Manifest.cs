using Lombiq.Hosting.MediaTheme.Bridge.Constants;
using OrchardCore.DisplayManagement.Manifest;

[assembly: Theme(
    Name = "Letters from Fiume Theme",
    Author = "Zoltán Lehóczky",
    Version = "0.0.1",
    Website = "https://lettersfromfiume.com/",
    Description = "Theme for the personal website Letters from Fiume.",
    BaseTheme = "TheBlogTheme",
    Dependencies = new[]
    {
        FeatureNames.MediaThemeBridge
    }
)]
