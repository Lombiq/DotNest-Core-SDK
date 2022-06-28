using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace TheClassLessTheme.OrchardCore
{

    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static readonly ResourceManifest _manifest = new();

        static ResourceManagementOptionsConfiguration() =>
            _manifest
                .DefineStyle("marx")
                .SetUrl("~/TheClassLessTheme/css/marx.min.css", "~/TheClassLessTheme/css/marx.css")
                .SetVersion("3.0.7");

        public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(_manifest);
    }
}
