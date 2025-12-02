using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tenant
        {
            ID = "id",
            Name = "name",
            BrandID = "brand_id",
            DefaultPreferences = new()
            {
                Items =
                [
                    new()
                    {
                        Status = Status.OptedOut,
                        CustomRouting = [ChannelClassification.DirectMessage],
                        HasCustomRouting = true,
                        ID = "id",
                    },
                ],
            },
            ParentTenantID = "parent_tenant_id",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UserProfile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedID = "id";
        string expectedName = "name";
        string expectedBrandID = "brand_id";
        DefaultPreferences expectedDefaultPreferences = new()
        {
            Items =
            [
                new()
                {
                    Status = Status.OptedOut,
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    ID = "id",
                },
            ],
        };
        string expectedParentTenantID = "parent_tenant_id";
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedUserProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedDefaultPreferences, model.DefaultPreferences);
        Assert.Equal(expectedParentTenantID, model.ParentTenantID);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.Equal(expectedUserProfile.Count, model.UserProfile.Count);
        foreach (var item in expectedUserProfile)
        {
            Assert.True(model.UserProfile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.UserProfile[item.Key]));
        }
    }
}
