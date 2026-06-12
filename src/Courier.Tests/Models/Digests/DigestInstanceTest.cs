using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Digests;

namespace Courier.Tests.Models.Digests;

public class DigestInstanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigestInstance
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
        };

        string expectedDigestInstanceID = "digest_instance_id";
        long expectedEventCount = 0;
        ApiEnum<string, Status> expectedStatus = Status.InProgress;
        string expectedUserID = "user_id";
        List<DigestCategory> expectedCategories =
        [
            new()
            {
                CategoryKey = "category_key",
                Retain = Retain.First,
                SortKey = "sort_key",
            },
        ];
        Dictionary<string, long> expectedCategoryKeyCounts = new() { { "foo", 0 } };
        string expectedCreatedAt = "created_at";
        bool expectedDisabled = true;
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedDigestInstanceID, model.DigestInstanceID);
        Assert.Equal(expectedEventCount, model.EventCount);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.NotNull(model.Categories);
        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.NotNull(model.CategoryKeyCounts);
        Assert.Equal(expectedCategoryKeyCounts.Count, model.CategoryKeyCounts.Count);
        foreach (var item in expectedCategoryKeyCounts)
        {
            Assert.True(model.CategoryKeyCounts.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.CategoryKeyCounts[item.Key]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisabled, model.Disabled);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigestInstance
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigestInstance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigestInstance
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigestInstance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDigestInstanceID = "digest_instance_id";
        long expectedEventCount = 0;
        ApiEnum<string, Status> expectedStatus = Status.InProgress;
        string expectedUserID = "user_id";
        List<DigestCategory> expectedCategories =
        [
            new()
            {
                CategoryKey = "category_key",
                Retain = Retain.First,
                SortKey = "sort_key",
            },
        ];
        Dictionary<string, long> expectedCategoryKeyCounts = new() { { "foo", 0 } };
        string expectedCreatedAt = "created_at";
        bool expectedDisabled = true;
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedDigestInstanceID, deserialized.DigestInstanceID);
        Assert.Equal(expectedEventCount, deserialized.EventCount);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.NotNull(deserialized.Categories);
        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.NotNull(deserialized.CategoryKeyCounts);
        Assert.Equal(expectedCategoryKeyCounts.Count, deserialized.CategoryKeyCounts.Count);
        foreach (var item in expectedCategoryKeyCounts)
        {
            Assert.True(deserialized.CategoryKeyCounts.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.CategoryKeyCounts[item.Key]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisabled, deserialized.Disabled);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigestInstance
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigestInstance
        {
            DigestInstanceID = "digest_instance_id",
            EventCount = 0,
            Status = Status.InProgress,
            UserID = "user_id",
            TenantID = "tenant_id",
        };

        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.CategoryKeyCounts);
        Assert.False(model.RawData.ContainsKey("category_key_counts"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigestInstance
        {
            DigestInstanceID = "digest_instance_id",
            EventCount = 0,
            Status = Status.InProgress,
            UserID = "user_id",
            TenantID = "tenant_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigestInstance
        {
            DigestInstanceID = "digest_instance_id",
            EventCount = 0,
            Status = Status.InProgress,
            UserID = "user_id",
            TenantID = "tenant_id",

            // Null should be interpreted as omitted for these properties
            Categories = null,
            CategoryKeyCounts = null,
            CreatedAt = null,
            Disabled = null,
        };

        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.CategoryKeyCounts);
        Assert.False(model.RawData.ContainsKey("category_key_counts"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigestInstance
        {
            DigestInstanceID = "digest_instance_id",
            EventCount = 0,
            Status = Status.InProgress,
            UserID = "user_id",
            TenantID = "tenant_id",

            // Null should be interpreted as omitted for these properties
            Categories = null,
            CategoryKeyCounts = null,
            CreatedAt = null,
            Disabled = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigestInstance
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
        };

        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigestInstance
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DigestInstance
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

            TenantID = null,
        };

        Assert.Null(model.TenantID);
        Assert.True(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigestInstance
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

            TenantID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigestInstance
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
        };

        DigestInstance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Completed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Completed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
