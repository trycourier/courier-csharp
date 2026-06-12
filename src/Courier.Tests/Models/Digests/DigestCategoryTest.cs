using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Digests;

namespace Courier.Tests.Models.Digests;

public class DigestCategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigestCategory
        {
            CategoryKey = "category_key",
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        string expectedCategoryKey = "category_key";
        ApiEnum<string, Retain> expectedRetain = Retain.First;
        string expectedSortKey = "sort_key";

        Assert.Equal(expectedCategoryKey, model.CategoryKey);
        Assert.Equal(expectedRetain, model.Retain);
        Assert.Equal(expectedSortKey, model.SortKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigestCategory
        {
            CategoryKey = "category_key",
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigestCategory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigestCategory
        {
            CategoryKey = "category_key",
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigestCategory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCategoryKey = "category_key";
        ApiEnum<string, Retain> expectedRetain = Retain.First;
        string expectedSortKey = "sort_key";

        Assert.Equal(expectedCategoryKey, deserialized.CategoryKey);
        Assert.Equal(expectedRetain, deserialized.Retain);
        Assert.Equal(expectedSortKey, deserialized.SortKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigestCategory
        {
            CategoryKey = "category_key",
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigestCategory { CategoryKey = "category_key", Retain = Retain.First };

        Assert.Null(model.SortKey);
        Assert.False(model.RawData.ContainsKey("sort_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigestCategory { CategoryKey = "category_key", Retain = Retain.First };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigestCategory
        {
            CategoryKey = "category_key",
            Retain = Retain.First,

            // Null should be interpreted as omitted for these properties
            SortKey = null,
        };

        Assert.Null(model.SortKey);
        Assert.False(model.RawData.ContainsKey("sort_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigestCategory
        {
            CategoryKey = "category_key",
            Retain = Retain.First,

            // Null should be interpreted as omitted for these properties
            SortKey = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigestCategory
        {
            CategoryKey = "category_key",
            Retain = Retain.First,
            SortKey = "sort_key",
        };

        DigestCategory copied = new(model);

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
