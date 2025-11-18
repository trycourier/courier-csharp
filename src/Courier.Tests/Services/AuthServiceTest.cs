using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class AuthServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task IssueToken_Works()
    {
        var response = await this.client.Auth.IssueToken(
            new()
            {
                ExpiresIn = "$YOUR_NUMBER days",
                Scope =
                    "user_id:$YOUR_USER_ID write:user-tokens inbox:read:messages inbox:write:events read:preferences write:preferences read:brands",
            }
        );
        response.Validate();
    }
}
