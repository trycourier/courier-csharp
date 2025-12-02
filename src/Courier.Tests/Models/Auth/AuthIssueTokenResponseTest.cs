using Courier.Models.Auth;

namespace Courier.Tests.Models.Auth;

public class AuthIssueTokenResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuthIssueTokenResponse { Token = "token" };

        string expectedToken = "token";

        Assert.Equal(expectedToken, model.Token);
    }
}
