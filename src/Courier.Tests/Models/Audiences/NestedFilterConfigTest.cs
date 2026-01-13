using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class NestedFilterConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NestedFilterConfig
        {
            Operator = Operator.EndsWith,
            Rules =
            [
                new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
            ],
        };

        ApiEnum<string, Operator> expectedOperator = Operator.EndsWith;
        List<Filter> expectedRules =
        [
            new SingleFilterConfig()
            {
                Operator = SingleFilterConfigOperator.EndsWith,
                Path = "path",
                Value = "value",
            },
        ];

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedRules.Count, model.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], model.Rules[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NestedFilterConfig
        {
            Operator = Operator.EndsWith,
            Rules =
            [
                new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NestedFilterConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NestedFilterConfig
        {
            Operator = Operator.EndsWith,
            Rules =
            [
                new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NestedFilterConfig>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Operator> expectedOperator = Operator.EndsWith;
        List<Filter> expectedRules =
        [
            new SingleFilterConfig()
            {
                Operator = SingleFilterConfigOperator.EndsWith,
                Path = "path",
                Value = "value",
            },
        ];

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedRules.Count, deserialized.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], deserialized.Rules[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NestedFilterConfig
        {
            Operator = Operator.EndsWith,
            Rules =
            [
                new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
            ],
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
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
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
            JsonSerializer.SerializeToElement("invalid value"),
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
