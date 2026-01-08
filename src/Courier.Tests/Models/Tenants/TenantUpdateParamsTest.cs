using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantUpdateParams
        {
            TenantID = "tenant_id",
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

        string expectedTenantID = "tenant_id";
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

        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDefaultPreferences, parameters.DefaultPreferences);
        Assert.Equal(expectedParentTenantID, parameters.ParentTenantID);
        Assert.NotNull(parameters.Properties);
        Assert.Equal(expectedProperties.Count, parameters.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(parameters.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Properties[item.Key]));
        }
        Assert.NotNull(parameters.UserProfile);
        Assert.Equal(expectedUserProfile.Count, parameters.UserProfile.Count);
        foreach (var item in expectedUserProfile)
        {
            Assert.True(parameters.UserProfile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.UserProfile[item.Key]));
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TenantUpdateParams { TenantID = "tenant_id", Name = "name" };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.DefaultPreferences);
        Assert.False(parameters.RawBodyData.ContainsKey("default_preferences"));
        Assert.Null(parameters.ParentTenantID);
        Assert.False(parameters.RawBodyData.ContainsKey("parent_tenant_id"));
        Assert.Null(parameters.Properties);
        Assert.False(parameters.RawBodyData.ContainsKey("properties"));
        Assert.Null(parameters.UserProfile);
        Assert.False(parameters.RawBodyData.ContainsKey("user_profile"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TenantUpdateParams
        {
            TenantID = "tenant_id",
            Name = "name",

            BrandID = null,
            DefaultPreferences = null,
            ParentTenantID = null,
            Properties = null,
            UserProfile = null,
        };

        Assert.Null(parameters.BrandID);
        Assert.True(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.DefaultPreferences);
        Assert.True(parameters.RawBodyData.ContainsKey("default_preferences"));
        Assert.Null(parameters.ParentTenantID);
        Assert.True(parameters.RawBodyData.ContainsKey("parent_tenant_id"));
        Assert.Null(parameters.Properties);
        Assert.True(parameters.RawBodyData.ContainsKey("properties"));
        Assert.Null(parameters.UserProfile);
        Assert.True(parameters.RawBodyData.ContainsKey("user_profile"));
    }

    [Fact]
    public void Url_Works()
    {
        TenantUpdateParams parameters = new() { TenantID = "tenant_id", Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/tenants/tenant_id"), url);
    }
}
