using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

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

        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
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

        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
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
        };

        model.Validate();
    }
}
