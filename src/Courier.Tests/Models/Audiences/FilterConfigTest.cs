using System.Text.Json;
using Courier.Core;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class FilterConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FilterConfig
        {
            Operator = FilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        ApiEnum<string, FilterConfigOperator> expectedOperator = FilterConfigOperator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FilterConfig
        {
            Operator = FilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FilterConfig
        {
            Operator = FilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FilterConfig>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, FilterConfigOperator> expectedOperator = FilterConfigOperator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FilterConfig
        {
            Operator = FilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        model.Validate();
    }
}
