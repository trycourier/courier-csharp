using System.Threading.Tasks;

namespace Courier.Tests.Services.Auth;

public class AuthServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task IssueToken_Works()
    {
        var response = await this.client.Auth.IssueToken(
            new() { ExpiresIn = "expires_in", Scope = "scope" }
        );
        response.Validate();
    }
}
