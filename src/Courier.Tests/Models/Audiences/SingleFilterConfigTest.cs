using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class SingleFilterConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SingleFilterConfig
        {
            Operator = SingleFilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        ApiEnum<string, SingleFilterConfigOperator> expectedOperator =
            SingleFilterConfigOperator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SingleFilterConfig
        {
            Operator = SingleFilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SingleFilterConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SingleFilterConfig
        {
            Operator = SingleFilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SingleFilterConfig>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, SingleFilterConfigOperator> expectedOperator =
            SingleFilterConfigOperator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SingleFilterConfig
        {
            Operator = SingleFilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        model.Validate();
    }
}

public class SingleFilterConfigOperatorTest : TestBase
{
    [Theory]
    [InlineData(SingleFilterConfigOperator.EndsWith)]
    [InlineData(SingleFilterConfigOperator.Eq)]
    [InlineData(SingleFilterConfigOperator.Exists)]
    [InlineData(SingleFilterConfigOperator.Gt)]
    [InlineData(SingleFilterConfigOperator.Gte)]
    [InlineData(SingleFilterConfigOperator.Includes)]
    [InlineData(SingleFilterConfigOperator.IsAfter)]
    [InlineData(SingleFilterConfigOperator.IsBefore)]
    [InlineData(SingleFilterConfigOperator.Lt)]
    [InlineData(SingleFilterConfigOperator.Lte)]
    [InlineData(SingleFilterConfigOperator.Neq)]
    [InlineData(SingleFilterConfigOperator.Omit)]
    [InlineData(SingleFilterConfigOperator.StartsWith)]
    [InlineData(SingleFilterConfigOperator.And)]
    [InlineData(SingleFilterConfigOperator.Or)]
    public void Validation_Works(SingleFilterConfigOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SingleFilterConfigOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SingleFilterConfigOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SingleFilterConfigOperator.EndsWith)]
    [InlineData(SingleFilterConfigOperator.Eq)]
    [InlineData(SingleFilterConfigOperator.Exists)]
    [InlineData(SingleFilterConfigOperator.Gt)]
    [InlineData(SingleFilterConfigOperator.Gte)]
    [InlineData(SingleFilterConfigOperator.Includes)]
    [InlineData(SingleFilterConfigOperator.IsAfter)]
    [InlineData(SingleFilterConfigOperator.IsBefore)]
    [InlineData(SingleFilterConfigOperator.Lt)]
    [InlineData(SingleFilterConfigOperator.Lte)]
    [InlineData(SingleFilterConfigOperator.Neq)]
    [InlineData(SingleFilterConfigOperator.Omit)]
    [InlineData(SingleFilterConfigOperator.StartsWith)]
    [InlineData(SingleFilterConfigOperator.And)]
    [InlineData(SingleFilterConfigOperator.Or)]
    public void SerializationRoundtrip_Works(SingleFilterConfigOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SingleFilterConfigOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SingleFilterConfigOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SingleFilterConfigOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SingleFilterConfigOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
