using Courier.Models;

namespace Courier.Tests.Models;

public class RuleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rule { Until = "until", Start = "start" };

        string expectedUntil = "until";
        string expectedStart = "start";

        Assert.Equal(expectedUntil, model.Until);
        Assert.Equal(expectedStart, model.Start);
    }
}
