using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Digests;

namespace Courier.Tests.Models.Digests;

public class DigestInstanceListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Cursor = "cursor",
            NextUrl = "next_url",
            Url = "url",
        };

        bool expectedHasMore = true;
        List<DigestInstance> expectedItems =
        [
            new()
            {
                DigestInstanceID = "digest_instance_id",
                EventCount = 0,
                Status = Status.InProgress,
                UserID = "user_id",
                Categories =
                [
                    new()
                    {
                        CategoryKey = "category_key",
                        Retain = Retain.First,
                        SortKey = "sort_key",
                    },
                ],
                CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                CreatedAt = "created_at",
                Disabled = true,
                TenantID = "tenant_id",
            },
        ];
        ApiEnum<string, Type> expectedType = Type.List;
        string expectedCursor = "cursor";
        string expectedNextUrl = "next_url";
        string expectedUrl = "url";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCursor, model.Cursor);
        Assert.Equal(expectedNextUrl, model.NextUrl);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Cursor = "cursor",
            NextUrl = "next_url",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigestInstanceListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Cursor = "cursor",
            NextUrl = "next_url",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigestInstanceListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        List<DigestInstance> expectedItems =
        [
            new()
            {
                DigestInstanceID = "digest_instance_id",
                EventCount = 0,
                Status = Status.InProgress,
                UserID = "user_id",
                Categories =
                [
                    new()
                    {
                        CategoryKey = "category_key",
                        Retain = Retain.First,
                        SortKey = "sort_key",
                    },
                ],
                CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                CreatedAt = "created_at",
                Disabled = true,
                TenantID = "tenant_id",
            },
        ];
        ApiEnum<string, Type> expectedType = Type.List;
        string expectedCursor = "cursor";
        string expectedNextUrl = "next_url";
        string expectedUrl = "url";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCursor, deserialized.Cursor);
        Assert.Equal(expectedNextUrl, deserialized.NextUrl);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Cursor = "cursor",
            NextUrl = "next_url",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Cursor = "cursor",
            NextUrl = "next_url",
        };

        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Cursor = "cursor",
            NextUrl = "next_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Cursor = "cursor",
            NextUrl = "next_url",

            // Null should be interpreted as omitted for these properties
            Url = null,
        };

        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Cursor = "cursor",
            NextUrl = "next_url",

            // Null should be interpreted as omitted for these properties
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
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
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
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
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Url = "url",

            Cursor = null,
            NextUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigestInstanceListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    DigestInstanceID = "digest_instance_id",
                    EventCount = 0,
                    Status = Status.InProgress,
                    UserID = "user_id",
                    Categories =
                    [
                        new()
                        {
                            CategoryKey = "category_key",
                            Retain = Retain.First,
                            SortKey = "sort_key",
                        },
                    ],
                    CategoryKeyCounts = new Dictionary<string, long>() { { "foo", 0 } },
                    CreatedAt = "created_at",
                    Disabled = true,
                    TenantID = "tenant_id",
                },
            ],
            Type = Type.List,
            Cursor = "cursor",
            NextUrl = "next_url",
            Url = "url",
        };

        DigestInstanceListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.List)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.List)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
