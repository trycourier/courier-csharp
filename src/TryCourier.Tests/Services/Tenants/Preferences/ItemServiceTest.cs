using System.Threading.Tasks;
using TryCourier.Models.Tenants.Preferences.Items;

namespace TryCourier.Tests.Services.Tenants.Preferences;

public class ItemServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Tenants.Preferences.Items.Update(
            "topic_id",
            new() { TenantID = "tenant_id", Status = Status.OptedIn },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Tenants.Preferences.Items.Delete(
            "topic_id",
            new() { TenantID = "tenant_id" },
            TestContext.Current.CancellationToken
        );
    }
}
