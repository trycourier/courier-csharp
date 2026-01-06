using System;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Tests.Models.Lists.Subscriptions;

public class SubscriptionUnsubscribeUserParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUnsubscribeUserParams
        {
            ListID = "list_id",
            UserID = "user_id",
        };

        string expectedListID = "list_id";
        string expectedUserID = "user_id";

        Assert.Equal(expectedListID, parameters.ListID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUnsubscribeUserParams parameters = new()
        {
            ListID = "list_id",
            UserID = "user_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/lists/list_id/subscriptions/user_id"), url);
    }
}
