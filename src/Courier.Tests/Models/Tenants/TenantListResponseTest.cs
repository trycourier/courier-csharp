using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
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
            Url = "url",
            Cursor = "cursor",
            NextUrl = "next_url",
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
        string expectedUrl = "url";
        string expectedCursor = "cursor";
        string expectedNextUrl = "next_url";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedCursor, model.Cursor);
        Assert.Equal(expectedNextUrl, model.NextUrl);
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
            Url = "url",
            Cursor = "cursor",
            NextUrl = "next_url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenantListResponse>(
            json,
            ModelBase.SerializerOptions
        );

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
            Url = "url",
            Cursor = "cursor",
            NextUrl = "next_url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenantListResponse>(
            element,
            ModelBase.SerializerOptions
        );
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
        string expectedUrl = "url";
        string expectedCursor = "cursor";
        string expectedNextUrl = "next_url";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedCursor, deserialized.Cursor);
        Assert.Equal(expectedNextUrl, deserialized.NextUrl);
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
            Url = "url",
            Cursor = "cursor",
            NextUrl = "next_url",
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
            Url = "url",
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.NextUrl);
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
            Url = "url",
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
            Url = "url",

            Cursor = null,
            NextUrl = null,
        };

        Assert.Null(model.Cursor);
        Assert.True(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.NextUrl);
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
            Url = "url",

            Cursor = null,
            NextUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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
            Url = "url",
            Cursor = "cursor",
            NextUrl = "next_url",
        };

        TenantListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TenantListResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(TenantListResponseType.List)]
    public void Validation_Works(TenantListResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TenantListResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TenantListResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TenantListResponseType.List)]
    public void SerializationRoundtrip_Works(TenantListResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TenantListResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TenantListResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TenantListResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TenantListResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
