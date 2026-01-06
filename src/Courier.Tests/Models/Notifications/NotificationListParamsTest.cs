using System;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationListParams { Cursor = "cursor", Notes = true };

        string expectedCursor = "cursor";
        bool expectedNotes = true;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedNotes, parameters.Notes);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawQueryData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new NotificationListParams { Cursor = null, Notes = null };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawQueryData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationListParams parameters = new() { Cursor = "cursor", Notes = true };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/notifications?cursor=cursor&notes=true"),
            url
        );
    }
}
