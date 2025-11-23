using DotNest.Core.SDK.Tests.UI.Constants;
using Lombiq.Tests.UI.BasicOrchardFeaturesTesting;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Models;
using Shouldly;
using System.Linq;
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
    public Task BasicOrchardFeaturesShouldWork() =>
        ExecuteTestAsync(
            context => context.TestBasicOrchardFeaturesAsync(new OrchardCoreSetupParameters(context)
            {
                RecipeId = Recipes.DefaultRecipeId,
                SkipFrontend = true,
                SkipRegistration = true,
            }),
            configuration =>
            {
                configuration.HtmlValidationConfiguration.AssertHtmlValidationResultAsync =
                    validationResult =>
                    {
                        // Error filtering due to https://github.com/OrchardCMS/OrchardCore/issues/18510. Can be removed
                        // once resolved.
                        var errors = validationResult.GetParsedErrors()
                            .Where(error => error.RuleId is not "aria-label-misuse");
                        errors.ShouldBeEmpty(HtmlValidationResultExtensions.GetParsedErrorMessageString(errors));
                        return Task.CompletedTask;
                    };

                return Task.CompletedTask;
            });
}
