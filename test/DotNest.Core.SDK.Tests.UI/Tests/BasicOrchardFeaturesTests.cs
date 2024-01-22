using DotNest.Core.SDK.Tests.UI.Constants;
using Lombiq.Tests.UI.Extensions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DotNest.Core.SDK.Tests.UI.Tests;

public class BasicOrchardFeaturesTests : UITestBase
{
    public BasicOrchardFeaturesTests(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    [Fact]
    public Task BasicOrchardFeaturesShouldWork() =>
        ExecuteTestAsync(
            context => context.TestBasicOrchardFeaturesExceptRegistrationAsync(Recipes.DefaultRecipeId),
            configuration =>
            {
                configuration.SetDisableColorContrastRuleAccessibilityCheckingConfiguration();

                // Should be deleted once https://github.com/OrchardCMS/OrchardCore/pull/14523 is merged and released in
                // new OC version.
                configuration.SetTemporaryAccessibilityAndHtmlConfiguration();

                return Task.CompletedTask;
            });
}
