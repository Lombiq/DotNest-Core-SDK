using DotNest.Core.SDK.Tests.UI.Constants;
using Lombiq.Tests.UI.BasicOrchardFeaturesTesting;
using Lombiq.Tests.UI.Models;
using System.Threading.Tasks;
using Xunit;

namespace DotNest.Core.SDK.Tests.UI.Tests;

public class BasicOrchardFeaturesTests : UITestBase
{
    public BasicOrchardFeaturesTests(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    [Fact]
    public Task BasicOrchardFeaturesShouldWork() => TestBuilder
        .WithoutSetup()
        .RunAsync(context => context.TestBasicOrchardFeaturesAsync(new OrchardCoreSetupParameters(context)
        {
            RecipeId = Recipes.DefaultRecipeId,
            SkipFrontend = true,
            SkipRegistration = true,
        }));
}
