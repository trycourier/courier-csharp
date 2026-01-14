using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class RuleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rule { Until = "until", Start = "start" };

        string expectedUntil = "until";
        string expectedStart = "start";

        Assert.Equal(expectedUntil, model.Until);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rule { Until = "until", Start = "start" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rule>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rule { Until = "until", Start = "start" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rule>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedUntil = "until";
        string expectedStart = "start";

        Assert.Equal(expectedUntil, deserialized.Until);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rule { Until = "until", Start = "start" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rule { Until = "until" };

        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rule { Until = "until" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Rule
        {
            Until = "until",

            Start = null,
        };

        Assert.Null(model.Start);
        Assert.True(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rule
        {
            Until = "until",

            Start = null,
        };

        model.Validate();
    }
}
