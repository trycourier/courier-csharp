using System.Threading.Tasks;
using Courier.Models.Tenants.Preferences.Items;

namespace Courier.Tests.Services.Tenants.Preferences;

public class ItemServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Tenants.Preferences.Items.Update(
            "topic_id",
            new() { TenantID = "tenant_id", Status = Status.OptedIn }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Tenants.Preferences.Items.Delete(
            "topic_id",
            new() { TenantID = "tenant_id" }
        );
    }
}
