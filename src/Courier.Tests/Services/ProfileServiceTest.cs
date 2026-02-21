using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class ProfileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var profile = await this.client.Profiles.Create(
            "user_id",
            new()
            {
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TestContext.Current.CancellationToken
        );
        profile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var profile = await this.client.Profiles.Retrieve(
            "user_id",
            new(),
            TestContext.Current.CancellationToken
        );
        profile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Profiles.Update(
            "user_id",
            new()
            {
                Patch =
                [
                    new()
                    {
                        Op = "op",
                        Path = "path",
                        Value = "value",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Profiles.Delete("user_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var response = await this.client.Profiles.Replace(
            "user_id",
            new()
            {
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
