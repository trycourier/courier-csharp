using Courier.Models.Tenants.Preferences.Items;

namespace Courier.Tests.Models.Tenants.Preferences.Items;

public class ItemDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemDeleteParams { TenantID = "tenant_id", TopicID = "topic_id" };

        string expectedTenantID = "tenant_id";
        string expectedTopicID = "topic_id";

        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedTopicID, parameters.TopicID);
    }
}
