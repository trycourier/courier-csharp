using System.Text.Json;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class FilterConfigTest : TestBase
{
    [Fact]
    public void SingleValidationWorks()
    {
        FilterConfig value = new(
            new SingleFilterConfig()
            {
                Operator = SingleFilterConfigOperator.EndsWith,
                Path = "path",
                Value = "value",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NestedValidationWorks()
    {
        FilterConfig value = new(
            new NestedFilterConfig()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void SingleSerializationRoundtripWorks()
    {
        FilterConfig value = new(
            new SingleFilterConfig()
            {
                Operator = SingleFilterConfigOperator.EndsWith,
                Path = "path",
                Value = "value",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NestedSerializationRoundtripWorks()
    {
        FilterConfig value = new(
            new NestedFilterConfig()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(element);

        Assert.Equal(value, deserialized);
    }
}
