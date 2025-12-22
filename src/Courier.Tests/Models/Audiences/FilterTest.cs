using System.Text.Json;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class FilterTest : TestBase
{
    [Fact]
    public void SingleFilterConfigValidationWorks()
    {
        Filter value = new(
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
    public void NestedFilterConfigValidationWorks()
    {
        Filter value = new(
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
    public void SingleFilterConfigSerializationRoundtripWorks()
    {
        Filter value = new(
            new SingleFilterConfig()
            {
                Operator = SingleFilterConfigOperator.EndsWith,
                Path = "path",
                Value = "value",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Filter>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NestedFilterConfigSerializationRoundtripWorks()
    {
        Filter value = new(
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
        var deserialized = JsonSerializer.Deserialize<Filter>(element);

        Assert.Equal(value, deserialized);
    }
}
