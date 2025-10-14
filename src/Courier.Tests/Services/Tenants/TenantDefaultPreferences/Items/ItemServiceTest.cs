using System.Threading.Tasks;
using Courier.Models.Tenants.TenantDefaultPreferences.Items.ItemUpdateParamsProperties;

namespace Courier.Tests.Services.Tenants.TenantDefaultPreferences.Items;

public class ItemServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Tenants.TenantDefaultPreferences.Items.Update(
            new()
            {
                TenantID = "tenant_id",
                TopicID = "topic_id",
                Status = Status.OptedIn,
            }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Tenants.TenantDefaultPreferences.Items.Delete(
            new() { TenantID = "tenant_id", TopicID = "topic_id" }
        );
    }
}
