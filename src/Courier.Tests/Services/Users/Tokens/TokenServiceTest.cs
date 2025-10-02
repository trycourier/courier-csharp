using System.Threading.Tasks;
using Courier.Models.Users.Tokens.TokenAddSingleParamsProperties;

namespace Courier.Tests.Services.Users.Tokens;

public class TokenServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var token = await this.client.Users.Tokens.Retrieve(
            new() { UserID = "user_id", Token = "token" }
        );
        token.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Users.Tokens.Update(
            new()
            {
                UserID = "user_id",
                Token = "token",
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
        var userTokens = await this.client.Users.Tokens.List(new() { UserID = "user_id" });
        foreach (var item in userTokens)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Users.Tokens.Delete(new() { UserID = "user_id", Token = "token" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddMultiple_Works()
    {
        await this.client.Users.Tokens.AddMultiple(new() { UserID = "user_id" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddSingle_Works()
    {
        await this.client.Users.Tokens.AddSingle(
            new()
            {
                UserID = "user_id",
                Token = "token",
                ProviderKey = ProviderKey.FirebaseFcm,
            }
        );
    }
}
