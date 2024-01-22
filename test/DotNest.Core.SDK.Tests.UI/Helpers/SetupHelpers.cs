using DotNest.Core.SDK.Tests.UI.Constants;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Pages;
using Lombiq.Tests.UI.Services;
using OpenQA.Selenium;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotNest.Core.SDK.Tests.UI.Helpers;

public static class SetupHelpers
{
    public static async Task<Uri> RunSetupAsync(UITestContext context)
    {
        var homepageUri = await context.GoToSetupPageAndSetupOrchardCoreAsync(
            new OrchardCoreSetupParameters(context)
            {
                SiteName = "DotNest Core SDK",
                RecipeId = Recipes.DefaultRecipeId,
                SiteTimeZoneValue = "Europe/Budapest",
            });

        context.Get(By.ClassName("navbar-brand")).Text.ShouldBe("DotNest Core SDK");

        return homepageUri;
    }
}
