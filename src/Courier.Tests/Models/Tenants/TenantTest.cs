using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
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
        Assert.NotNull(model.Properties);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.NotNull(model.UserProfile);
        Assert.Equal(expectedUserProfile.Count, model.UserProfile.Count);
        foreach (var item in expectedUserProfile)
        {
            Assert.True(model.UserProfile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.UserProfile[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tenant>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tenant>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedDefaultPreferences, deserialized.DefaultPreferences);
        Assert.Equal(expectedParentTenantID, deserialized.ParentTenantID);
        Assert.NotNull(deserialized.Properties);
        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(deserialized.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Properties[item.Key]));
        }
        Assert.NotNull(deserialized.UserProfile);
        Assert.Equal(expectedUserProfile.Count, deserialized.UserProfile.Count);
        foreach (var item in expectedUserProfile)
        {
            Assert.True(deserialized.UserProfile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.UserProfile[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tenant { ID = "id", Name = "name" };

        Assert.Null(model.BrandID);
        Assert.False(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.DefaultPreferences);
        Assert.False(model.RawData.ContainsKey("default_preferences"));
        Assert.Null(model.ParentTenantID);
        Assert.False(model.RawData.ContainsKey("parent_tenant_id"));
        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
        Assert.Null(model.UserProfile);
        Assert.False(model.RawData.ContainsKey("user_profile"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tenant { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Tenant
        {
            ID = "id",
            Name = "name",

            BrandID = null,
            DefaultPreferences = null,
            ParentTenantID = null,
            Properties = null,
            UserProfile = null,
        };

        Assert.Null(model.BrandID);
        Assert.True(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.DefaultPreferences);
        Assert.True(model.RawData.ContainsKey("default_preferences"));
        Assert.Null(model.ParentTenantID);
        Assert.True(model.RawData.ContainsKey("parent_tenant_id"));
        Assert.Null(model.Properties);
        Assert.True(model.RawData.ContainsKey("properties"));
        Assert.Null(model.UserProfile);
        Assert.True(model.RawData.ContainsKey("user_profile"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tenant
        {
            ID = "id",
            Name = "name",

            BrandID = null,
            DefaultPreferences = null,
            ParentTenantID = null,
            Properties = null,
            UserProfile = null,
        };

        model.Validate();
    }
}
