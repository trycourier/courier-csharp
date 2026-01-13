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
            Filters =
            [
                new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
            ],
            Operator = NestedFilterConfigOperator.EndsWith,
        };

        List<FilterConfig> expectedFilters =
        [
            new SingleFilterConfig()
            {
                Operator = SingleFilterConfigOperator.EndsWith,
                Path = "path",
                Value = "value",
            },
        ];
        ApiEnum<string, NestedFilterConfigOperator> expectedOperator =
            NestedFilterConfigOperator.EndsWith;

        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedOperator, model.Operator);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NestedFilterConfig
        {
            Filters =
            [
                new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
            ],
            Operator = NestedFilterConfigOperator.EndsWith,
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
            Filters =
            [
                new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
            ],
            Operator = NestedFilterConfigOperator.EndsWith,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NestedFilterConfig>(element);
        Assert.NotNull(deserialized);

        List<FilterConfig> expectedFilters =
        [
            new SingleFilterConfig()
            {
                Operator = SingleFilterConfigOperator.EndsWith,
                Path = "path",
                Value = "value",
            },
        ];
        ApiEnum<string, NestedFilterConfigOperator> expectedOperator =
            NestedFilterConfigOperator.EndsWith;

        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedOperator, deserialized.Operator);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NestedFilterConfig
        {
            Filters =
            [
                new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
            ],
            Operator = NestedFilterConfigOperator.EndsWith,
        };

        model.Validate();
    }
}

public class NestedFilterConfigOperatorTest : TestBase
{
    [Theory]
    [InlineData(NestedFilterConfigOperator.EndsWith)]
    [InlineData(NestedFilterConfigOperator.Eq)]
    [InlineData(NestedFilterConfigOperator.Exists)]
    [InlineData(NestedFilterConfigOperator.Gt)]
    [InlineData(NestedFilterConfigOperator.Gte)]
    [InlineData(NestedFilterConfigOperator.Includes)]
    [InlineData(NestedFilterConfigOperator.IsAfter)]
    [InlineData(NestedFilterConfigOperator.IsBefore)]
    [InlineData(NestedFilterConfigOperator.Lt)]
    [InlineData(NestedFilterConfigOperator.Lte)]
    [InlineData(NestedFilterConfigOperator.Neq)]
    [InlineData(NestedFilterConfigOperator.Omit)]
    [InlineData(NestedFilterConfigOperator.StartsWith)]
    [InlineData(NestedFilterConfigOperator.And)]
    [InlineData(NestedFilterConfigOperator.Or)]
    public void Validation_Works(NestedFilterConfigOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NestedFilterConfigOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NestedFilterConfigOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NestedFilterConfigOperator.EndsWith)]
    [InlineData(NestedFilterConfigOperator.Eq)]
    [InlineData(NestedFilterConfigOperator.Exists)]
    [InlineData(NestedFilterConfigOperator.Gt)]
    [InlineData(NestedFilterConfigOperator.Gte)]
    [InlineData(NestedFilterConfigOperator.Includes)]
    [InlineData(NestedFilterConfigOperator.IsAfter)]
    [InlineData(NestedFilterConfigOperator.IsBefore)]
    [InlineData(NestedFilterConfigOperator.Lt)]
    [InlineData(NestedFilterConfigOperator.Lte)]
    [InlineData(NestedFilterConfigOperator.Neq)]
    [InlineData(NestedFilterConfigOperator.Omit)]
    [InlineData(NestedFilterConfigOperator.StartsWith)]
    [InlineData(NestedFilterConfigOperator.And)]
    [InlineData(NestedFilterConfigOperator.Or)]
    public void SerializationRoundtrip_Works(NestedFilterConfigOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NestedFilterConfigOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NestedFilterConfigOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NestedFilterConfigOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NestedFilterConfigOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
