using System.Threading.Tasks;
using Courier.Models.Tenants.DefaultPreferences.Items.ItemUpdateParamsProperties;

namespace Courier.Tests.Services.Tenants.DefaultPreferences.Items;

public class ItemServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Tenants.DefaultPreferences.Items.Update(
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
        await this.client.Tenants.DefaultPreferences.Items.Delete(
            new() { TenantID = "tenant_id", TopicID = "topic_id" }
        );
    }
}
