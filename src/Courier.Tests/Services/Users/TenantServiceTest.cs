using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Tenants;

namespace Courier.Tests.Services.Users;

public class TenantServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var tenants = await this.client.Users.Tenants.List(new() { UserID = "user_id" });
        tenants.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddMultiple_Works()
    {
        await this.client.Users.Tenants.AddMultiple(
            new()
            {
                UserID = "user_id",
                Tenants =
                [
                    new()
                    {
                        TenantID = "tenant_id",
                        Profile = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Type = Type.User,
                        UserID = "user_id",
                    },
                ],
            }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddSingle_Works()
    {
        await this.client.Users.Tenants.AddSingle(
            new() { UserID = "user_id", TenantID = "tenant_id" }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RemoveAll_Works()
    {
        await this.client.Users.Tenants.RemoveAll(new() { UserID = "user_id" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RemoveSingle_Works()
    {
        await this.client.Users.Tenants.RemoveSingle(
            new() { UserID = "user_id", TenantID = "tenant_id" }
        );
    }
}
