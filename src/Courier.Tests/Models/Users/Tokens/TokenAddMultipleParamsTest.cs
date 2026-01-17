using System;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class TokenAddMultipleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TokenAddMultipleParams { UserID = "user_id" };

        string expectedUserID = "user_id";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        TokenAddMultipleParams parameters = new() { UserID = "user_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/users/user_id/tokens"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TokenAddMultipleParams { UserID = "user_id" };

        TokenAddMultipleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
