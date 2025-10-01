using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Courier.Tests.Services.Profiles;

public class ProfileServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var profile = await this.client.Profiles.Create(
            new()
            {
                UserID = "user_id",
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            }
        );
        profile.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var profile = await this.client.Profiles.Retrieve(new() { UserID = "user_id" });
        profile.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Profiles.Update(
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
    public async Task Delete_Works()
    {
        await this.client.Profiles.Delete(new() { UserID = "user_id" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Replace_Works()
    {
        var response = await this.client.Profiles.Replace(
            new()
            {
                UserID = "user_id",
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            }
        );
        response.Validate();
    }
}
