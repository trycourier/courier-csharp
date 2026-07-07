using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class AudienceFilterConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudienceFilterConfig
        {
            Filters =
            [
                new()
                {
                    Operator = "operator",
                    Filters = [],
                    Path = "path",
                    Value = "value",
                },
            ],
            Operator = AudienceFilterConfigOperator.And,
        };

        List<FilterConfig> expectedFilters =
        [
            new()
            {
                Operator = "operator",
                Filters = [],
                Path = "path",
                Value = "value",
            },
        ];
        ApiEnum<string, AudienceFilterConfigOperator> expectedOperator =
            AudienceFilterConfigOperator.And;

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
        var model = new AudienceFilterConfig
        {
            Filters =
            [
                new()
                {
                    Operator = "operator",
                    Filters = [],
                    Path = "path",
                    Value = "value",
                },
            ],
            Operator = AudienceFilterConfigOperator.And,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AudienceFilterConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudienceFilterConfig
        {
            Filters =
            [
                new()
                {
                    Operator = "operator",
                    Filters = [],
                    Path = "path",
                    Value = "value",
                },
            ],
            Operator = AudienceFilterConfigOperator.And,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AudienceFilterConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FilterConfig> expectedFilters =
        [
            new()
            {
                Operator = "operator",
                Filters = [],
                Path = "path",
                Value = "value",
            },
        ];
        ApiEnum<string, AudienceFilterConfigOperator> expectedOperator =
            AudienceFilterConfigOperator.And;

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
        var model = new AudienceFilterConfig
        {
            Filters =
            [
                new()
                {
                    Operator = "operator",
                    Filters = [],
                    Path = "path",
                    Value = "value",
                },
            ],
            Operator = AudienceFilterConfigOperator.And,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AudienceFilterConfig
        {
            Filters =
            [
                new()
                {
                    Operator = "operator",
                    Filters = [],
                    Path = "path",
                    Value = "value",
                },
            ],
        };

        Assert.Null(model.Operator);
        Assert.False(model.RawData.ContainsKey("operator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AudienceFilterConfig
        {
            Filters =
            [
                new()
                {
                    Operator = "operator",
                    Filters = [],
                    Path = "path",
                    Value = "value",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AudienceFilterConfig
        {
            Filters =
            [
                new()
                {
                    Operator = "operator",
                    Filters = [],
                    Path = "path",
                    Value = "value",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Operator = null,
        };

        Assert.Null(model.Operator);
        Assert.False(model.RawData.ContainsKey("operator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AudienceFilterConfig
        {
            Filters =
            [
                new()
                {
                    Operator = "operator",
                    Filters = [],
                    Path = "path",
                    Value = "value",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Operator = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AudienceFilterConfig
        {
            Filters =
            [
                new()
                {
                    Operator = "operator",
                    Filters = [],
                    Path = "path",
                    Value = "value",
                },
            ],
            Operator = AudienceFilterConfigOperator.And,
        };

        AudienceFilterConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AudienceFilterConfigOperatorTest : TestBase
{
    [Theory]
    [InlineData(AudienceFilterConfigOperator.And)]
    [InlineData(AudienceFilterConfigOperator.Or)]
    public void Validation_Works(AudienceFilterConfigOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudienceFilterConfigOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudienceFilterConfigOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AudienceFilterConfigOperator.And)]
    [InlineData(AudienceFilterConfigOperator.Or)]
    public void SerializationRoundtrip_Works(AudienceFilterConfigOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudienceFilterConfigOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AudienceFilterConfigOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudienceFilterConfigOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AudienceFilterConfigOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
