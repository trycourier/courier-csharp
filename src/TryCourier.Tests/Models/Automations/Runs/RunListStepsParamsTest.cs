using System;
using TryCourier.Models.Automations.Runs;

namespace TryCourier.Tests.Models.Automations.Runs;

public class RunListStepsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunListStepsParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        RunListStepsParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/automations/runs/x/steps"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunListStepsParams { ID = "x" };

        RunListStepsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
