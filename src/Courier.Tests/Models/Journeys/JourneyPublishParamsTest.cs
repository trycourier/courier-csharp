using System;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyPublishParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JourneyPublishParams { TemplateID = "x", Version = "v321669910225" };

        string expectedTemplateID = "x";
        string expectedVersion = "v321669910225";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new JourneyPublishParams { TemplateID = "x" };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new JourneyPublishParams
        {
            TemplateID = "x",

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        JourneyPublishParams parameters = new() { TemplateID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/x/publish"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JourneyPublishParams { TemplateID = "x", Version = "v321669910225" };

        JourneyPublishParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
