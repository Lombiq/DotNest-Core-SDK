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
            context => context.TestBasicOrchardFeaturesExceptRegistrationAsync(Recipes.DefaultRecipeId));
}
