using System;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class TokenListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TokenListParams { UserID = "user_id" };

        string expectedUserID = "user_id";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        TokenListParams parameters = new() { UserID = "user_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/users/user_id/tokens"), url);
    }
}
