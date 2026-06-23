using System;
using TryCourier.Models.Journeys.Templates;

namespace TryCourier.Tests.Models.Journeys.Templates;

public class TemplateRetrieveContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateRetrieveContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Version = "version",
        };

        string expectedTemplateID = "x";
        string expectedNotificationID = "x";
        string expectedVersion = "version";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedNotificationID, parameters.NotificationID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateRetrieveContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateRetrieveContentParams
        {
            TemplateID = "x",
            NotificationID = "x",

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateRetrieveContentParams parameters = new()
        {
            TemplateID = "x",
            NotificationID = "x",
            Version = "version",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/journeys/x/templates/x/content?version=version"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateRetrieveContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Version = "version",
        };

        TemplateRetrieveContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
