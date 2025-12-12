using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class TenantServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var tenant = await this.client.Tenants.Retrieve(
            "tenant_id",
            new(),
            TestContext.Current.CancellationToken
        );
        tenant.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var tenant = await this.client.Tenants.Update(
            "tenant_id",
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        tenant.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var tenants = await this.client.Tenants.List(new(), TestContext.Current.CancellationToken);
        tenants.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Tenants.Delete("tenant_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListUsers_Works()
    {
        var response = await this.client.Tenants.ListUsers(
            "tenant_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
