using System;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationRetrieveParams { ID = "id", Version = "version" };

        string expectedID = "id";
        string expectedVersion = "version";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationRetrieveParams { ID = "id" };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationRetrieveParams
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
        NotificationRetrieveParams parameters = new() { ID = "id", Version = "version" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/notifications/id?version=version"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationRetrieveParams { ID = "id", Version = "version" };

        NotificationRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
