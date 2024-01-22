using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DotNest.Core.SDK.Tests.UI.Constants;

public static class Configurations
{
    // We need this configuration temporary until the HTML validation errors in The Coming Soon theme aren't solved
    // https://github.com/OrchardCMS/OrchardCore/pull/11243
    public static readonly Func<OrchardCoreUITestExecutorConfiguration, Task> NoAccessibilityCheckingAndNoHtmlValidationConfiguration =
        configuration =>
        {
            configuration.SetNoAccessibilityCheckingConfiguration();
            configuration.HtmlValidationConfiguration.RunHtmlValidationAssertionOnAllPageChanges = false;

            return Task.CompletedTask;
        };

    public static OrchardCoreUITestExecutorConfiguration SetDisableColorContrastRuleAccessibilityCheckingConfiguration(
        this OrchardCoreUITestExecutorConfiguration configuration)
    {
        configuration.AccessibilityCheckingConfiguration.AxeBuilderConfigurator += axeBuilder =>
            AccessibilityCheckingConfiguration.ConfigureWcag21aa(axeBuilder)
                .DisableRules("color-contrast");

        return configuration;
    }

    public static OrchardCoreUITestExecutorConfiguration SetTemporaryAccessibilityAndHtmlConfiguration(
        this OrchardCoreUITestExecutorConfiguration configuration)
    {
        configuration.AccessibilityCheckingConfiguration.AxeBuilderConfigurator += axeBuilder =>
            axeBuilder.Exclude("#bd-theme");
        configuration.HtmlValidationConfiguration.AssertHtmlValidationResultAsync = async (validationResult) =>
        {
            var errors = (await validationResult.GetErrorsAsync())
                .Where(error =>
                    !error.ContainsOrdinalIgnoreCase("Class \"nav-item\" duplicated (no-dup-class) at") &&
                    !error.ContainsOrdinalIgnoreCase(
                        "\"target\" attribute cannot be used in this context: requires \"href\" attribute to be present"));
            errors.ShouldBeEmpty();
        };

        return configuration;
    }

    public static OrchardCoreUITestExecutorConfiguration SetNoAccessibilityCheckingConfiguration(
        this OrchardCoreUITestExecutorConfiguration configuration)
    {
        configuration
            .AccessibilityCheckingConfiguration
            .RunAccessibilityCheckingAssertionOnAllPageChanges = false;

        return configuration;
    }
}
