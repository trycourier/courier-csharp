using System;
using Courier.Models.Profiles;

namespace Courier.Tests.Models.Profiles;

public class ProfileDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileDeleteParams { UserID = "user_id" };

        string expectedUserID = "user_id";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        ProfileDeleteParams parameters = new() { UserID = "user_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/profiles/user_id"), url);
    }
}
