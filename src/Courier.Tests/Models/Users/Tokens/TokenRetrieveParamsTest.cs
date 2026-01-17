using System;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class TokenRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TokenRetrieveParams { UserID = "user_id", Token = "token" };

        string expectedUserID = "user_id";
        string expectedToken = "token";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedToken, parameters.Token);
    }

    [Fact]
    public void Url_Works()
    {
        TokenRetrieveParams parameters = new() { UserID = "user_id", Token = "token" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/users/user_id/tokens/token"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TokenRetrieveParams { UserID = "user_id", Token = "token" };

        TokenRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
