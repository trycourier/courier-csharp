using System;
using Courier.Models.Auth;

namespace Courier.Tests.Models.Auth;

public class AuthIssueTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AuthIssueTokenParams
        {
            ExpiresIn = "$YOUR_NUMBER days",
            Scope =
                "user_id:$YOUR_USER_ID write:user-tokens inbox:read:messages inbox:write:events read:preferences write:preferences read:brands",
        };

        string expectedExpiresIn = "$YOUR_NUMBER days";
        string expectedScope =
            "user_id:$YOUR_USER_ID write:user-tokens inbox:read:messages inbox:write:events read:preferences write:preferences read:brands";

        Assert.Equal(expectedExpiresIn, parameters.ExpiresIn);
        Assert.Equal(expectedScope, parameters.Scope);
    }

    [Fact]
    public void Url_Works()
    {
        AuthIssueTokenParams parameters = new()
        {
            ExpiresIn = "$YOUR_NUMBER days",
            Scope =
                "user_id:$YOUR_USER_ID write:user-tokens inbox:read:messages inbox:write:events read:preferences write:preferences read:brands",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/auth/issue-token"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AuthIssueTokenParams
        {
            ExpiresIn = "$YOUR_NUMBER days",
            Scope =
                "user_id:$YOUR_USER_ID write:user-tokens inbox:read:messages inbox:write:events read:preferences write:preferences read:brands",
        };

        AuthIssueTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
