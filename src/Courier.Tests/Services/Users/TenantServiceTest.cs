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
        var tenants = await this.client.Users.Tenants.List(
            "user_id",
            new(),
            TestContext.Current.CancellationToken
        );
        tenants.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddMultiple_Works()
    {
        await this.client.Users.Tenants.AddMultiple(
            "user_id",
            new()
            {
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
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddSingle_Works()
    {
        await this.client.Users.Tenants.AddSingle(
            "tenant_id",
            new() { UserID = "user_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RemoveAll_Works()
    {
        await this.client.Users.Tenants.RemoveAll(
            "user_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RemoveSingle_Works()
    {
        await this.client.Users.Tenants.RemoveSingle(
            "tenant_id",
            new() { UserID = "user_id" },
            TestContext.Current.CancellationToken
        );
    }
}
