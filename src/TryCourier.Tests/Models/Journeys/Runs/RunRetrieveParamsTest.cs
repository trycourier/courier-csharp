using System;
using TryCourier.Models.Journeys.Runs;

namespace TryCourier.Tests.Models.Journeys.Runs;

public class RunRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunRetrieveParams { RunID = "x" };

        string expectedRunID = "x";

        Assert.Equal(expectedRunID, parameters.RunID);
    }

    [Fact]
    public void Url_Works()
    {
        RunRetrieveParams parameters = new() { RunID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/runs/x"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunRetrieveParams { RunID = "x" };

        RunRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
