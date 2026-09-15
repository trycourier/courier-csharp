using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class TopicDigestCategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopicDigestCategory
        {
            CategoryKey = "category_key",
            Limit = 1,
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        string expectedCategoryKey = "category_key";
        long expectedLimit = 1;
        ApiEnum<string, Retain> expectedRetain = Retain.First;
        string expectedSortKey = "sort_key";

        Assert.Equal(expectedCategoryKey, model.CategoryKey);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedRetain, model.Retain);
        Assert.Equal(expectedSortKey, model.SortKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopicDigestCategory
        {
            CategoryKey = "category_key",
            Limit = 1,
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestCategory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopicDigestCategory
        {
            CategoryKey = "category_key",
            Limit = 1,
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestCategory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCategoryKey = "category_key";
        long expectedLimit = 1;
        ApiEnum<string, Retain> expectedRetain = Retain.First;
        string expectedSortKey = "sort_key";

        Assert.Equal(expectedCategoryKey, deserialized.CategoryKey);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedRetain, deserialized.Retain);
        Assert.Equal(expectedSortKey, deserialized.SortKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopicDigestCategory
        {
            CategoryKey = "category_key",
            Limit = 1,
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TopicDigestCategory { CategoryKey = "category_key" };

        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Retain);
        Assert.False(model.RawData.ContainsKey("retain"));
        Assert.Null(model.SortKey);
        Assert.False(model.RawData.ContainsKey("sort_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TopicDigestCategory { CategoryKey = "category_key" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TopicDigestCategory
        {
            CategoryKey = "category_key",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Retain = null,
            SortKey = null,
        };

        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Retain);
        Assert.False(model.RawData.ContainsKey("retain"));
        Assert.Null(model.SortKey);
        Assert.False(model.RawData.ContainsKey("sort_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TopicDigestCategory
        {
            CategoryKey = "category_key",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Retain = null,
            SortKey = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopicDigestCategory
        {
            CategoryKey = "category_key",
            Limit = 1,
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        TopicDigestCategory copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RetainTest : TestBase
{
    [Theory]
    [InlineData(Retain.First)]
    [InlineData(Retain.Last)]
    [InlineData(Retain.Highest)]
    [InlineData(Retain.Lowest)]
    [InlineData(Retain.None)]
    public void Validation_Works(Retain rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Retain> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Retain>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Retain.First)]
    [InlineData(Retain.Last)]
    [InlineData(Retain.Highest)]
    [InlineData(Retain.Lowest)]
    [InlineData(Retain.None)]
    public void SerializationRoundtrip_Works(Retain rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Retain> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Retain>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Retain>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Retain>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
