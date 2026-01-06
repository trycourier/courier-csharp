using System;
using Courier.Models.Profiles.Lists;

namespace Courier.Tests.Models.Profiles.Lists;

public class ListDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListDeleteParams { UserID = "user_id" };

        string expectedUserID = "user_id";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        ListDeleteParams parameters = new() { UserID = "user_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/profiles/user_id/lists"), url);
    }
}
