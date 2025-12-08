using System.Threading.Tasks;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Services.Users;

public class TokenServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var token = await this.client.Users.Tokens.Retrieve("token", new() { UserID = "user_id" });
        token.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Users.Tokens.Update(
            "token",
            new()
            {
                UserID = "user_id",
                Patch =
                [
                    new()
                    {
                        Op = "op",
                        Path = "path",
                        Value = "value",
                    },
                ],
            }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var tokens = await this.client.Users.Tokens.List("user_id");
        tokens.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Users.Tokens.Delete("token", new() { UserID = "user_id" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddMultiple_Works()
    {
        await this.client.Users.Tokens.AddMultiple("user_id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddSingle_Works()
    {
        await this.client.Users.Tokens.AddSingle(
            "token",
            new()
            {
                UserID = "user_id",
                TokenValue = "token",
                ProviderKey = ProviderKey.FirebaseFcm,
            }
        );
    }
}
