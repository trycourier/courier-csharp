using System;
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

    [Fact]
    public void Url_Works()
    {
        ItemDeleteParams parameters = new() { TenantID = "tenant_id", TopicID = "topic_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/tenants/tenant_id/default_preferences/items/topic_id"),
            url
        );
    }
}
