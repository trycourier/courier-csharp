using System.Text.Json;
using Courier.Core;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class FilterConfigTest : TestBase
{
    [Fact]
    public void SingleValidationWorks()
    {
        FilterConfig value = new SingleFilterConfig()
        {
            Operator = SingleFilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };
        value.Validate();
    }

    [Fact]
    public void NestedValidationWorks()
    {
        FilterConfig value = new NestedFilterConfig()
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
        value.Validate();
    }

    [Fact]
    public void SingleSerializationRoundtripWorks()
    {
        FilterConfig value = new SingleFilterConfig()
        {
            Operator = SingleFilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NestedSerializationRoundtripWorks()
    {
        FilterConfig value = new NestedFilterConfig()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
