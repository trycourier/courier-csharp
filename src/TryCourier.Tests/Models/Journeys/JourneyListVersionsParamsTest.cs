using System;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyListVersionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JourneyListVersionsParams { TemplateID = "x" };

        string expectedTemplateID = "x";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
    }

    [Fact]
    public void Url_Works()
    {
        JourneyListVersionsParams parameters = new() { TemplateID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/x/versions"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JourneyListVersionsParams { TemplateID = "x" };

        JourneyListVersionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
