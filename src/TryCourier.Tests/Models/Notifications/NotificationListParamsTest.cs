using System;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationListParams
        {
            Cursor = "cursor",
            EventID = "event_id",
            Notes = true,
        };

        string expectedCursor = "cursor";
        string expectedEventID = "event_id";
        bool expectedNotes = true;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEventID, parameters.EventID);
        Assert.Equal(expectedNotes, parameters.Notes);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationListParams { Cursor = "cursor", Notes = true };

        Assert.Null(parameters.EventID);
        Assert.False(parameters.RawQueryData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationListParams
        {
            Cursor = "cursor",
            Notes = true,

            // Null should be interpreted as omitted for these properties
            EventID = null,
        };

        Assert.Null(parameters.EventID);
        Assert.False(parameters.RawQueryData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationListParams { EventID = "event_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawQueryData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new NotificationListParams
        {
            EventID = "event_id",

            Cursor = null,
            Notes = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawQueryData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationListParams parameters = new()
        {
            Cursor = "cursor",
            EventID = "event_id",
            Notes = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.courier.com/notifications?cursor=cursor&event_id=event_id&notes=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationListParams
        {
            Cursor = "cursor",
            EventID = "event_id",
            Notes = true,
        };

        NotificationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
