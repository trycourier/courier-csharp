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
}
