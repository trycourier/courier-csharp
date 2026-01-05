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
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawQueryData.ContainsKey("notes"));
    }
}
