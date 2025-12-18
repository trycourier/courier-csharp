using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class FilterConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FilterConfig
        {
            Operator = FilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        ApiEnum<string, FilterConfigOperator> expectedOperator = FilterConfigOperator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FilterConfig
        {
            Operator = FilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FilterConfig
        {
            Operator = FilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, FilterConfigOperator> expectedOperator = FilterConfigOperator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FilterConfig
        {
            Operator = FilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        model.Validate();
    }
}

public class FilterConfigOperatorTest : TestBase
{
    [Theory]
    [InlineData(FilterConfigOperator.EndsWith)]
    [InlineData(FilterConfigOperator.Eq)]
    [InlineData(FilterConfigOperator.Exists)]
    [InlineData(FilterConfigOperator.Gt)]
    [InlineData(FilterConfigOperator.Gte)]
    [InlineData(FilterConfigOperator.Includes)]
    [InlineData(FilterConfigOperator.IsAfter)]
    [InlineData(FilterConfigOperator.IsBefore)]
    [InlineData(FilterConfigOperator.Lt)]
    [InlineData(FilterConfigOperator.Lte)]
    [InlineData(FilterConfigOperator.Neq)]
    [InlineData(FilterConfigOperator.Omit)]
    [InlineData(FilterConfigOperator.StartsWith)]
    [InlineData(FilterConfigOperator.And)]
    [InlineData(FilterConfigOperator.Or)]
    public void Validation_Works(FilterConfigOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FilterConfigOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FilterConfigOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FilterConfigOperator.EndsWith)]
    [InlineData(FilterConfigOperator.Eq)]
    [InlineData(FilterConfigOperator.Exists)]
    [InlineData(FilterConfigOperator.Gt)]
    [InlineData(FilterConfigOperator.Gte)]
    [InlineData(FilterConfigOperator.Includes)]
    [InlineData(FilterConfigOperator.IsAfter)]
    [InlineData(FilterConfigOperator.IsBefore)]
    [InlineData(FilterConfigOperator.Lt)]
    [InlineData(FilterConfigOperator.Lte)]
    [InlineData(FilterConfigOperator.Neq)]
    [InlineData(FilterConfigOperator.Omit)]
    [InlineData(FilterConfigOperator.StartsWith)]
    [InlineData(FilterConfigOperator.And)]
    [InlineData(FilterConfigOperator.Or)]
    public void SerializationRoundtrip_Works(FilterConfigOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FilterConfigOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FilterConfigOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FilterConfigOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FilterConfigOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
