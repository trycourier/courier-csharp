using Courier.Models.Automations;

namespace Courier.Tests.Models.Automations;

public class AutomationInvokeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationInvokeResponse { RunID = "runId" };

        string expectedRunID = "runId";

        Assert.Equal(expectedRunID, model.RunID);
    }
}
