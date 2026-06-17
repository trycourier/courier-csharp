using System;
using TryCourier.Models.Journeys.Templates;

namespace TryCourier.Tests.Models.Journeys.Templates;

public class TemplatePublishParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplatePublishParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Version = "v321669910225",
        };

        string expectedTemplateID = "x";
        string expectedNotificationID = "x";
        string expectedVersion = "v321669910225";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedNotificationID, parameters.NotificationID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplatePublishParams { TemplateID = "x", NotificationID = "x" };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplatePublishParams
        {
            TemplateID = "x",
            NotificationID = "x",

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplatePublishParams parameters = new() { TemplateID = "x", NotificationID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/journeys/x/templates/x/publish"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplatePublishParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Version = "v321669910225",
        };

        TemplatePublishParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
