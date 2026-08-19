using System;
using TryCourier.Models.Journeys.Runs;

namespace TryCourier.Tests.Models.Journeys.Runs;

public class RunListStepsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunListStepsParams { RunID = "x" };

        string expectedRunID = "x";

        Assert.Equal(expectedRunID, parameters.RunID);
    }

    [Fact]
    public void Url_Works()
    {
        RunListStepsParams parameters = new() { RunID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/runs/x/steps"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunListStepsParams { RunID = "x" };

        RunListStepsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
