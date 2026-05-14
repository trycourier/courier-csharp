using System;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JourneyRetrieveParams { TemplateID = "x", Version = "published" };

        string expectedTemplateID = "x";
        string expectedVersion = "published";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new JourneyRetrieveParams { TemplateID = "x" };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new JourneyRetrieveParams
        {
            TemplateID = "x",

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        JourneyRetrieveParams parameters = new() { TemplateID = "x", Version = "published" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/x?version=published"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JourneyRetrieveParams { TemplateID = "x", Version = "published" };

        JourneyRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
