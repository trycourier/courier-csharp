using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class FilterConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FilterConfig
        {
            Operator = "operator",
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
            Path = "path",
            Value = "value",
        };

        string expectedOperator = "operator";
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
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.NotNull(model.Filters);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FilterConfig
        {
            Operator = "operator",
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
            Path = "path",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FilterConfig
        {
            Operator = "operator",
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
            Path = "path",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedOperator = "operator";
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
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.NotNull(deserialized.Filters);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FilterConfig
        {
            Operator = "operator",
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
            Path = "path",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FilterConfig { Operator = "operator" };

        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FilterConfig { Operator = "operator" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FilterConfig
        {
            Operator = "operator",

            // Null should be interpreted as omitted for these properties
            Filters = null,
            Path = null,
            Value = null,
        };

        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FilterConfig
        {
            Operator = "operator",

            // Null should be interpreted as omitted for these properties
            Filters = null,
            Path = null,
            Value = null,
        };

        model.Validate();
    }
}
