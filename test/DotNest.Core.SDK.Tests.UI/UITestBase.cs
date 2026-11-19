using DotNest.Core.SDK.Tests.UI.Helpers;
using Lombiq.Tests.UI;
using Xunit;

namespace DotNest.Core.SDK.Tests.UI;

public class UITestBase : OrchardCoreUITestBase<Program>
{
    protected UITestBase(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper) =>
        UseSetup(SetupHelpers.RunSetupAsync);
}
