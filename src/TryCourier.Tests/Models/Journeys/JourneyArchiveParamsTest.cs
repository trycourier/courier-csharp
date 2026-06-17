using System;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JourneyArchiveParams { TemplateID = "x" };

        string expectedTemplateID = "x";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
    }

    [Fact]
    public void Url_Works()
    {
        JourneyArchiveParams parameters = new() { TemplateID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/x"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JourneyArchiveParams { TemplateID = "x" };

        JourneyArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
