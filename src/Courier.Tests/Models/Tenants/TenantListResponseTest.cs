using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenantListResponse
        {
            HasMore = true,
            Items =
            [
                new()
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
                },
            ],
            Type = TenantListResponseType.List,
            URL = "url",
            Cursor = "cursor",
            NextURL = "next_url",
        };

        bool expectedHasMore = true;
        List<Tenant> expectedItems =
        [
            new()
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
            },
        ];
        ApiEnum<string, TenantListResponseType> expectedType = TenantListResponseType.List;
        string expectedURL = "url";
        string expectedCursor = "cursor";
        string expectedNextURL = "next_url";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedCursor, model.Cursor);
        Assert.Equal(expectedNextURL, model.NextURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TenantListResponse
        {
            HasMore = true,
            Items =
            [
                new()
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
                },
            ],
            Type = TenantListResponseType.List,
            URL = "url",
            Cursor = "cursor",
            NextURL = "next_url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TenantListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TenantListResponse
        {
            HasMore = true,
            Items =
            [
                new()
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
                },
            ],
            Type = TenantListResponseType.List,
            URL = "url",
            Cursor = "cursor",
            NextURL = "next_url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TenantListResponse>(json);
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        List<Tenant> expectedItems =
        [
            new()
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
            },
        ];
        ApiEnum<string, TenantListResponseType> expectedType = TenantListResponseType.List;
        string expectedURL = "url";
        string expectedCursor = "cursor";
        string expectedNextURL = "next_url";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedURL, deserialized.URL);
        Assert.Equal(expectedCursor, deserialized.Cursor);
        Assert.Equal(expectedNextURL, deserialized.NextURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TenantListResponse
        {
            HasMore = true,
            Items =
            [
                new()
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
                },
            ],
            Type = TenantListResponseType.List,
            URL = "url",
            Cursor = "cursor",
            NextURL = "next_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TenantListResponse
        {
            HasMore = true,
            Items =
            [
                new()
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
                },
            ],
            Type = TenantListResponseType.List,
            URL = "url",
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.NextURL);
        Assert.False(model.RawData.ContainsKey("next_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TenantListResponse
        {
            HasMore = true,
            Items =
            [
                new()
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
                },
            ],
            Type = TenantListResponseType.List,
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TenantListResponse
        {
            HasMore = true,
            Items =
            [
                new()
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
                },
            ],
            Type = TenantListResponseType.List,
            URL = "url",

            Cursor = null,
            NextURL = null,
        };

        Assert.Null(model.Cursor);
        Assert.True(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.NextURL);
        Assert.True(model.RawData.ContainsKey("next_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TenantListResponse
        {
            HasMore = true,
            Items =
            [
                new()
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
                },
            ],
            Type = TenantListResponseType.List,
            URL = "url",

            Cursor = null,
            NextURL = null,
        };

        model.Validate();
    }
}
