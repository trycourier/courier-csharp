using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class TenantServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var tenant = await this.client.Tenants.Retrieve("tenant_id");
        tenant.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var tenant = await this.client.Tenants.Update("tenant_id", new() { Name = "name" });
        tenant.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var tenants = await this.client.Tenants.List();
        tenants.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Tenants.Delete("tenant_id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListUsers_Works()
    {
        var response = await this.client.Tenants.ListUsers("tenant_id");
        response.Validate();
    }
}
