using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter
        {
            Operator = Operator.EndsWith,
            Path = "path",
            Value = "value",
        };

        ApiEnum<string, Operator> expectedOperator = Operator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Filter
        {
            Operator = Operator.EndsWith,
            Path = "path",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter
        {
            Operator = Operator.EndsWith,
            Path = "path",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Operator> expectedOperator = Operator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Filter
        {
            Operator = Operator.EndsWith,
            Path = "path",
            Value = "value",
        };

        model.Validate();
    }
}

public class OperatorTest : TestBase
{
    [Theory]
    [InlineData(Operator.EndsWith)]
    [InlineData(Operator.Eq)]
    [InlineData(Operator.Exists)]
    [InlineData(Operator.Gt)]
    [InlineData(Operator.Gte)]
    [InlineData(Operator.Includes)]
    [InlineData(Operator.IsAfter)]
    [InlineData(Operator.IsBefore)]
    [InlineData(Operator.Lt)]
    [InlineData(Operator.Lte)]
    [InlineData(Operator.Neq)]
    [InlineData(Operator.Omit)]
    [InlineData(Operator.StartsWith)]
    [InlineData(Operator.And)]
    [InlineData(Operator.Or)]
    public void Validation_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operator.EndsWith)]
    [InlineData(Operator.Eq)]
    [InlineData(Operator.Exists)]
    [InlineData(Operator.Gt)]
    [InlineData(Operator.Gte)]
    [InlineData(Operator.Includes)]
    [InlineData(Operator.IsAfter)]
    [InlineData(Operator.IsBefore)]
    [InlineData(Operator.Lt)]
    [InlineData(Operator.Lte)]
    [InlineData(Operator.Neq)]
    [InlineData(Operator.Omit)]
    [InlineData(Operator.StartsWith)]
    [InlineData(Operator.And)]
    [InlineData(Operator.Or)]
    public void SerializationRoundtrip_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
