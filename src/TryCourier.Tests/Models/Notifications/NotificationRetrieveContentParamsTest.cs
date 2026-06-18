using System;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationRetrieveContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationRetrieveContentParams { ID = "id", Version = "version" };

        string expectedID = "id";
        string expectedVersion = "version";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationRetrieveContentParams { ID = "id" };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationRetrieveContentParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationRetrieveContentParams parameters = new() { ID = "id", Version = "version" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/notifications/id/content?version=version"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationRetrieveContentParams { ID = "id", Version = "version" };

        NotificationRetrieveContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
