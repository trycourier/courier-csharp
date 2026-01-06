using System;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Tests.Models.Lists.Subscriptions;

public class SubscriptionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionListParams { ListID = "list_id", Cursor = "cursor" };

        string expectedListID = "list_id";
        string expectedCursor = "cursor";

        Assert.Equal(expectedListID, parameters.ListID);
        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams { ListID = "list_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionListParams
        {
            ListID = "list_id",

            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionListParams parameters = new() { ListID = "list_id", Cursor = "cursor" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/lists/list_id/subscriptions?cursor=cursor"),
            url
        );
    }
}
