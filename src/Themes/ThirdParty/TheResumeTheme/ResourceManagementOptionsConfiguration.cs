using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace TheResumeTheme
{


    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static readonly ResourceManifest _manifest = new ResourceManifest();

        static ResourceManagementOptionsConfiguration()
        {
            _manifest
               .DefineScript("Resume")
               .SetDependencies("bootstrap", "jQuery.easing")
               .SetUrl("~/TheResumeTheme/js/scripts.min.js", "~/TheResumeTheme/js/scripts.js")
               .SetVersion("6.0.0");

            _manifest
                .DefineStyle("Resume")
                .SetUrl("~/TheResumeTheme/css/styles.min.css", "~/TheResumeTheme/css/styles.css")
                .SetVersion("6.0.0");

        }

        public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(_manifest);
    }
}
